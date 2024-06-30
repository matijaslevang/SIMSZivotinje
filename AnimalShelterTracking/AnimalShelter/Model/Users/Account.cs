using AnimalShelter.Model.Enums;

namespace AnimalShelter.Model.Users
{
    public class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public Account() { }

        public Account(string email, string password, Role role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

    }
}
