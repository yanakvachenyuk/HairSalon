namespace HairSalon.Services;
using SQLite;
using HairSalon.Entities;
using System.Diagnostics;
using System.Data.Common;



public class SqLiteService: IDbService
{
    private SQLiteConnection? _database;

    public IEnumerable<Client>? GetClients()
    {
        return _database?.Table<Client>().ToList();
    }

    public IEnumerable<Admin>? GetAdmins()
    {
        return _database?.Table<Admin>().ToList();
    }

    public IEnumerable<ServiceType>? GetServiceTypes()
    {
        return _database?.Table<ServiceType>().ToList();
    }

    private bool TableExists(string tableName)
    {
        return _database?.GetTableInfo(tableName).Any() ?? false;
    }

    public IEnumerable<Service> GetServices(int serviceTypeId)
    {
        return _database.Table<Service>().Where(s => s.ServiceTypeId == serviceTypeId).ToList();
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _database.Table<Employee>().ToList();
    }

    public IEnumerable<EmployeeServiceType> GetEmployeeServiceTypes()
    {
        return _database.Table<EmployeeServiceType>().ToList();
    }

    public IEnumerable<ServiceType> GetEmployeeServiceTypes(int employeeId)
    {

        var query = _database.Table<EmployeeServiceType>()
                             .Where(est => est.EmployeeId == employeeId)
                             .Join(_database.Table<ServiceType>(),
                                   est => est.ServiceTypeId,
                                   st => st.Id,
                                   (est, st) => st);
        return query.ToList();
    }


    public void Init()
    {
       
        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string dataBasePath = Path.Combine(folderPath, "HairSalon.db");
        
        Debug.WriteLine(dataBasePath);
        if (File.Exists(dataBasePath))
        {
            Debug.WriteLine("Database already exists");
            
            _database = new SQLiteConnection(dataBasePath);
            //_database.DeleteAll<Client>();
            //_database.DeleteAll<ServiceType>();
            //_database.DeleteAll<Service>();
            //_database.DeleteAll<Employee>();
            //_database.DeleteAll<EmployeeServiceType>();
            if (!TableExists("Clients"))
            {
                Debug.WriteLine("Table for clients does not exist");
                _database.CreateTable<Client>();
            }
            if (!TableExists("ServiceTypes"))
            {
                Debug.WriteLine("Table for service types does not exist");
                _database.CreateTable<ServiceType>();
            }
            if (!TableExists("Services"))
            {
                Debug.WriteLine("Table for services does not exist");
                _database.CreateTable<Service>();
            }
            ServiceType serviceType = new ServiceType("WomanHaircut");
            ServiceType serviceType2 = new ServiceType("ManHaircut");
            Service service = new Service("1WomanHaircut", 20, serviceType.Id);
            Service service2 = new Service("2WomanHaircut", 30, serviceType.Id);
            Service service3 = new Service("1manHaircut", 40, serviceType2.Id);
            Service service4 = new Service("2manHaircut", 50, serviceType2.Id);
            //_database?.Insert(serviceType);
            //_database?.Insert(serviceType2);
            //_database?.Insert(service);
            //_database?.Insert(service2);
            //_database?.Insert(service3);
            //_database?.Insert(service4);
            if (!TableExists("Employees"))
            {
                Debug.WriteLine("Table for employees does not exist");
                _database.CreateTable<Employee>();
            }
            Employee employee = new Employee("emp1", "1", "email1", "number1", 100);
            Employee employee2 = new Employee("emp2", "2", "email2", "number2", 200);

            Employee employee3 = new Employee("emp3", "3", "email3", "number3", 300);
            Employee employee4 = new Employee("emp4", "4", "email4", "number4", 400);
            Employee employee5= new Employee("emp5", "5", "email5", "number5", 500);
            Employee employee6 = new Employee("emp6", "6", "email6", "number6", 600);
            //_database?.Insert(employee);
            //_database?.Insert(employee2);
            //_database?.Insert(employee3);
            //_database?.Insert(employee4);
            //_database?.Insert(employee5);
            //_database?.Insert(employee6);

            //var emp = GetEmployees().ToList();
            //var emp1 = emp.FirstOrDefault(e => e.FirstName == "emp1");
            //Debug.WriteLine($"emp1 id :  {emp1.Id}");
            //var emp2 = emp.FirstOrDefault(e => e.FirstName == "emp2");

            if (!TableExists("EmployeeServiceTypes"))
            {
                Debug.WriteLine("Table for employeeServiceTypes does not exist");
                _database.CreateTable<EmployeeServiceType>();
            }

            EmployeeServiceType employeeServiceType = new EmployeeServiceType(employee.Id, serviceType.Id);
            EmployeeServiceType employeeServiceType2 = new EmployeeServiceType(employee2.Id, serviceType.Id);
            EmployeeServiceType employeeServiceType3 = new EmployeeServiceType(employee2.Id, serviceType2.Id);

            //_database?.Insert(employeeServiceType);
            //_database?.Insert(employeeServiceType2);
            //_database?.Insert(employeeServiceType3);
            if (!TableExists("Admins"))
            {
                Debug.WriteLine("Table for admins does not exist");
                _database.CreateTable<Admin>();
                Admin admin = new Admin("admin", "admin", "Yana", "Kvachenyuk", "kvacenukana@gmail.com", "+375298668007");
                _database.Insert(admin);
            }

            return;
        }
        _database = new SQLiteConnection(dataBasePath);
        if (!TableExists("Clients"))
        {
            Debug.WriteLine("Table for clients does not exist");
            _database.CreateTable<Client>();
        }
        if (!TableExists("ServiceTypes"))
        {
            Debug.WriteLine("Table for service types does not exist");
            _database.CreateTable<ServiceType>();
        }
        if (!TableExists("Services"))
        {
            Debug.WriteLine("Table for services does not exist");
            _database.CreateTable<Service>();
        }
        if (!TableExists("Admins"))
        {
            Debug.WriteLine("Table for admins does not exist");
            _database.CreateTable<Admin>();
            Admin admin = new Admin("admin", "admin","Yana","Kvachenyuk","kvacenukana@gmail.com","+375298668007");
            _database.Insert(admin);
        }
        if (!TableExists("EmployeeServiceTypes"))
        {
            Debug.WriteLine("Table for employeeServiceTypes does not exist");
            _database.CreateTable<EmployeeServiceType>();
        }
        if (!TableExists("Employees"))
        {
            Debug.WriteLine("Table for employees does not exist");
            _database.CreateTable<Employee>();
        }
       
    }
    
    public void AddClient(Client client)
    {
        
        if (_database == null)
        {
            Debug.WriteLine("Database is not initialized");
            return;
        }

        if (!TableExists("Clients"))
        {
            Debug.WriteLine("Table for clients does not exist");
            _database.CreateTable<Client>();
        }
        
        _database?.Insert(client);
    }

    public  void DeleteClient(int selectedClientId)
    {
        if (TableExists("Clients"))
        {
            _database.Delete<Client>(selectedClientId);
        }
    }

    public void AddService(Service service)
    {
        if (!TableExists("Services"))
        {
            Debug.WriteLine("Table for services does not exist");
            _database.CreateTable<Service>();
        }

        _database?.Insert(service);
    }
    public void DeleteService(int selectedServiceId)
    {
        if (TableExists("Services"))
        {
            
            _database.Delete<Service>(selectedServiceId);
        }
    }
}