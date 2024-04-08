
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HairSalon.Entities
{
    [Table("Admins")]
    public class Admin:User
    {
        public string Login { get; set; }
        public Admin(string login, string password, string firstName, string lastName, string email, string phoneNumber)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public Admin()
        {

        }
        
    }
}
