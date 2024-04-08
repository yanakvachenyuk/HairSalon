using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HairSalon.Entities
{
   
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
    }
}
