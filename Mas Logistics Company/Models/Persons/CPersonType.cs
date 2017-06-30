using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas_Logistics_Company.Models.Persons
{
    public class CPersonType
    {
        public CPersonType()
        {
            
        }
        public int CPersonTypeId { get; set; }
        public Enums.CarPersonType PersonType { get; set; }
        public virtual CarPerson CarPerson { get; set; }
    }
}
