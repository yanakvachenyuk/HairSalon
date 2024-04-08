using SQLite;
namespace HairSalon.Entities;

[Table("Employees")]
public class Employee : User
{
    public decimal Salary { get; set; }
   
    public Employee(string firstName,string lastName, string email, string phoneNumber,decimal salary)
    {
       
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Salary = salary;
       
    }

    public Employee()
    {
        
    }
    
}