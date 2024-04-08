using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairSalon.Services;

namespace HairSalon.Entities
{
    public class MyHairSalon
    {
        private IDbService _dbService;
        public AccountsSystem accountsSystem { get; set; }
        public MyHairSalon(IDbService dbService)
        {
            _dbService = dbService;
            _dbService.Init();
            accountsSystem = new AccountsSystem(_dbService);
        }

        public void RegisterClient(string password, string firstName, string lastName, string email, string phoneNumber)
        {
            accountsSystem.RegisterClient(password, firstName, lastName, email, phoneNumber);

        }
        public void Login(string login, string password)
        {
            accountsSystem.Login(login, password);
        }
        public void Logout(string login)
        {
            accountsSystem.Logout();
        }


        public List<Client> GetClients()
        {
            return _dbService.GetClients().ToList();
        }

        public List<Admin> GetAdmins()
        {
            return _dbService.GetAdmins().ToList();
        }

        public List<ServiceType> GetServiceTypes()
        {
            return _dbService.GetServiceTypes().ToList();
        }

        public List<Service> GetServices(int serviceTypeId)
        {
            return _dbService.GetServices(serviceTypeId).ToList();
        }

        public List<Employee> GetEmployees()
        {
            return _dbService.GetEmployees().ToList();
        }

        public List<ServiceType> GetEmployeeServiceTypes(int employeeId)
        {
            return _dbService.GetEmployeeServiceTypes(employeeId).ToList();
        }

        public void DeleteClient(int selectedClientId)
        {
             _dbService.DeleteClient(selectedClientId);
        }

        public void AddService(Service service)
        {
            _dbService.AddService(service);
        }
        public void DeleteService(int selectedServiceId)
        {
            _dbService.DeleteService(selectedServiceId);
        }
    }
        

    
}
