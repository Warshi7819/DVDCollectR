// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
  document.querySelectorAll('time[datetime]').forEach(function (el) {
    var d = new Date(el.getAttribute('datetime'));
    if (!isNaN(d.getTime())) {
      el.textContent = d.toLocaleString(undefined, { dateStyle: 'long', timeStyle: 'short' });
    }
  });

  document.querySelectorAll('.clickable-cover').forEach(function (img) {
    img.addEventListener('click', function () {
      document.getElementById('coverModalImage').src = this.src;
      var modal = new bootstrap.Modal(document.getElementById('coverModal'));
      modal.show();
    });
  });
});
