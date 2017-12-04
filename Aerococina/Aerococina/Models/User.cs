using System;
namespace Aerococina.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserIdentityId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public string Photo { get; set; }

        public bool Status { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }
        public string StatusDescription { get; set; }

        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
