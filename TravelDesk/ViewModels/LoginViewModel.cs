//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace TravelDesk.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string? RoleName { get; set; }
    }
}