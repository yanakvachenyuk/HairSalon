using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite;

namespace HairSalon.Entities
{
    [Table("Clients")]
    public class Client:User
    {
        
        public Client(string password, string firstName, string lastName, string email, string phoneNumber)
        {
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            
            
        }
        

        public Client()
        {

        }
        
        
    }
}
