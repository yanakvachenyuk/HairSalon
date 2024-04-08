using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Entities
{
    public class GroupedServiceType
    {
        public ServiceType ServiceType { get; }
        public List<Service> Services { get; }

        public GroupedServiceType(ServiceType serviceType, List<Service> services)
        {
            ServiceType = serviceType;
            Services = services;
        }
    }
}
