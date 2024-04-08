using SQLite;
using System.ComponentModel.DataAnnotations.Schema;


namespace HairSalon.Entities;

[SQLite.Table("Services")]
public class Service : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    [ForeignKey(nameof(ServiceType))]
    public int ServiceTypeId { get; set; }
    

    public Service( string name, decimal price, int serviceTypeId)
    {
        
        Name = name;
        Price = price;
        ServiceTypeId = serviceTypeId;
    }

    public Service()
    {
        
    }
}