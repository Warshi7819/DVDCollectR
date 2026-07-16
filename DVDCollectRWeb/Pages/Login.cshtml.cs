using DVDCollectRWeb.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace DVDCollectRWeb.Pages
{
    public class LoginModel : PageModel
    {

        private readonly IOptions<UserConfiguration> _userOptions;
        private readonly ILogger<LoginModel> _logger;
        public LoginModel(IOptions<UserConfiguration> userOptions, ILogger<LoginModel> logger)
        {
            _userOptions = userOptions;
            _logger = logger;
        }

        [BindProperty]
        public string? Username { get; set; }
        
        [BindProperty]
        public string? Password { get; set; }

        public string? ErrorMessage { get; set; }

       

        public async Task<IActionResult> OnPost()
        {
            // Retrieve valid credentials from configuration
            var userConfig = _userOptions.Value;
            string? validUser = userConfig.Username;
            string? validPass = userConfig.Password;
            bool useHash = userConfig.UseSHA256;

            if (string.IsNullOrEmpty(validUser) || string.IsNullOrEmpty(validPass))
            {
                ErrorMessage = "Application user and pass not set. Contact admin.";
                _logger.LogCritical("Application user and password not configured");
                return Page();
            }

            // If given username or password is empty, return.
            if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Username))
            {
                ErrorMessage = "Invalid username or password";
                return Page();
            }

            var passwordProcessed = Password;
            if (useHash)
            {
                // Hash supplied password with SHA256 when configured to do so
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    var bytes = System.Text.Encoding.UTF8.GetBytes(Password);
                    var hash = sha256.ComputeHash(bytes);
                    passwordProcessed = Convert.ToBase64String(hash);
                }
            }


            if (Username == validUser && passwordProcessed == validPass)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username)
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);

                return RedirectToPage("/Index");
            }

            ErrorMessage = "Invalid username or password";
            _logger.LogWarning("Failed login attempt for user: {Username}", Username);
            return Page();
        }
    }
}
