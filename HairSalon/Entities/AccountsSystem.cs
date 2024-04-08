using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairSalon.Services;
using HairSalon.Pages;

namespace HairSalon.Entities
{
    public class AccountsSystem
    {
        private IDbService _dbService;
        private List<Client> Clients { get; set; }
        public User currentUser {  get; set; } 
        //List<Admin> Admins { get; set; }
        public AccountsSystem(IDbService dbService)
        {
            _dbService = dbService;
            _dbService.Init();
            Clients = new List<Client>();
            currentUser = new User();
            //Admins = new List<Admin>();
        }
        public void RegisterClient( string password, string firstName, string lastName, string email, string phoneNumber)
        {

            PersonalInfo personalInfo = new PersonalInfo(firstName, lastName, email, phoneNumber);
            Client client = new Client( password,firstName,lastName,email,phoneNumber);
            Clients.Add(client);
            _dbService.AddClient(client);
            
           
        }
        public void Login(string login, string password)
        {
            
            if(login == "admin" )
            {
                var admins = _dbService.GetAdmins().ToList<Admin>();
                Admin admin = admins.FirstOrDefault(a => a.Login == login && a.Password == password);
                if(admin != null)
                {
                    currentUser = new Admin(admin.Login, admin.Password, admin.FirstName, admin.LastName, admin.Email, admin.PhoneNumber);
                    Debug.WriteLine(currentUser.GetType());
                }
                else
                {
                    Debug.WriteLine("Invalid password");
                }
                

            }
            else
            {
                Clients = _dbService.GetClients().ToList();
                Client client = Clients.Find(c => c.PhoneNumber == login || c.Email == login);
                if(client != null)
                {
                    if(client.Password == password)
                    {
                        client.IsLoggedIn = true;
                        currentUser = new Client(client.Password, client.FirstName, client.LastName, client.Email, client.PhoneNumber);
                    }
                    else
                    {
                        Debug.WriteLine("Invalid password");
                    }
                }
                else
                {
                    Debug.WriteLine("User not found");
                }
            }
        }
        public void Logout()
        {
            if (currentUser.GetType() == typeof(Admin))
            {
                currentUser = null;
            }
            else if (currentUser.GetType() == typeof(Client))
            {
                currentUser.IsLoggedIn= false;
                currentUser = null;
                
            }
        }   

        public List<Client> GetClients()
        {
            Clients = _dbService.GetClients().ToList();
            return Clients;
        }
    }
}
