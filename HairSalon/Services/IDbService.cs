using HairSalon.Entities;

namespace HairSalon.Services;

public interface IDbService
{
    public IEnumerable<Client>? GetClients();
    public IEnumerable<Admin>? GetAdmins();
    public IEnumerable<Employee>? GetEmployees();
    public IEnumerable<ServiceType> GetEmployeeServiceTypes(int id);
    public IEnumerable<EmployeeServiceType> GetEmployeeServiceTypes(); 
    public IEnumerable<ServiceType>? GetServiceTypes();
    public IEnumerable<Service> GetServices(int id);
    public void Init();
    void AddClient(Client client);
    void DeleteClient(int selectedClientId);
    void AddService(Service service);
    void DeleteService(int selectedServiceId);
}