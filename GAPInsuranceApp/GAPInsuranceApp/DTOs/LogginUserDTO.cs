using GAPInsuranceApp.Models;
using System.ComponentModel.DataAnnotations;

namespace GAPInsuranceApp.DTOs
{
    public class LogginUserDTO
    {
        [Required]
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
