using System.ComponentModel.DataAnnotations.Schema;

namespace GAPInsuranceApp.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }

    public enum Roles
    {
        Admin,
        Client
    }
}

