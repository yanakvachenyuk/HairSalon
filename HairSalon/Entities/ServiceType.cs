using SQLite;

namespace HairSalon.Entities;

[Table("ServiceTypes")]
public class ServiceType:BaseEntity
{
    public string Name { get; set; }

    public ServiceType(string name)
    {
        Name = name;
    }

    public ServiceType()
    {
        
    }
    
    public void UpdateName(string name)
    {
        Name = name;
    }
}