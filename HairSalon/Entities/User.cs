using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HairSalon.Entities
{
    public class User: BaseEntity
    {

        public string? Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsLoggedIn { get; set; } = false;

        protected void ChangePassword(string password, string newPassword)
        {
            if (Password == password)
            {
                Password = newPassword;
            }
            else
            {
                throw new Exception("Invalid password");
            }

        }
        protected void UpdatePersonalInfo(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;

        }
    }
}
