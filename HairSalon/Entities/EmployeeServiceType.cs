using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HairSalon.Entities
{
    [SQLite.Table("EmployeeServiceTypes")]
    public class EmployeeServiceType:BaseEntity
    {
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(ServiceType))]
        public int ServiceTypeId { get; set; }

        public EmployeeServiceType(int employeeId, int serviceTypeId)
        {
            EmployeeId = employeeId;
            ServiceTypeId = serviceTypeId;
        }

        public EmployeeServiceType()
        {
            
        }
    }
}
