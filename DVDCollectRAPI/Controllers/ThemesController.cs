using DVDCollectRAPI.Data;
using DVDCollectRShared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DVDCollectRAPI.Controllers;

[ApiController]
[Route("api/themes")]
public class ThemesController : ControllerBase
{
    private readonly DvdDbContext _db;

    public ThemesController(DvdDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<List<ThemeDto>>> GetAll()
    {
        return await _db.Themes
            .OrderBy(t => t.Id)
            .Select(t => ToDto(t))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ThemeDto>> Get(int id)
    {
        var theme = await _db.Themes.FirstOrDefaultAsync(t => t.Id == id);
        if (theme is null)
        {
            return NotFound();
        }

        return ToDto(theme);
    }

    [HttpPost]
    public async Task<ActionResult<ThemeDto>> Create(ThemeDto dto)
    {
        var theme = new ThemeEntity
        {
            Name = dto.Name,
            IsBuiltIn = false,
            BodyBg = dto.BodyBg,
            BodyColor = dto.BodyColor,
            CardBg = dto.CardBg,
            CardBorderColor = dto.CardBorderColor,
            PrimaryColor = dto.PrimaryColor,
            NavbarBg = dto.NavbarBg,
            NavbarTextColor = dto.NavbarTextColor,
            FooterBg = dto.FooterBg,
            MutedColor = dto.MutedColor
        };
        _db.Themes.Add(theme);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = theme.Id }, ToDto(theme));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ThemeDto dto)
    {
        var existing = await _db.Themes.FirstOrDefaultAsync(t => t.Id == id);
        if (existing is null)
        {
            return NotFound();
        }

        if (existing.IsBuiltIn)
        {
            return BadRequest("Cannot modify built-in themes");
        }

        existing.Name = dto.Name;
        existing.BodyBg = dto.BodyBg;
        existing.BodyColor = dto.BodyColor;
        existing.CardBg = dto.CardBg;
        existing.CardBorderColor = dto.CardBorderColor;
        existing.PrimaryColor = dto.PrimaryColor;
        existing.NavbarBg = dto.NavbarBg;
        existing.NavbarTextColor = dto.NavbarTextColor;
        existing.FooterBg = dto.FooterBg;
        existing.MutedColor = dto.MutedColor;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _db.Themes.FirstOrDefaultAsync(t => t.Id == id);
        if (existing is null)
        {
            return NotFound();
        }

        if (existing.IsBuiltIn)
        {
            return BadRequest("Cannot delete built-in themes");
        }

        _db.Themes.Remove(existing);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    private static ThemeDto ToDto(ThemeEntity t) => new()
    {
        Id = t.Id,
        Name = t.Name,
        IsBuiltIn = t.IsBuiltIn,
        BodyBg = t.BodyBg,
        BodyColor = t.BodyColor,
        CardBg = t.CardBg,
        CardBorderColor = t.CardBorderColor,
        PrimaryColor = t.PrimaryColor,
        NavbarBg = t.NavbarBg,
        NavbarTextColor = t.NavbarTextColor,
        FooterBg = t.FooterBg,
        MutedColor = t.MutedColor
    };
}
