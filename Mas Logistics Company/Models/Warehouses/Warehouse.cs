using System.Collections.Generic;

namespace Mas_Logistics_Company.Models.Warehouses
{
    public class Warehouse
    {
        public Warehouse()
        {
            
        }
        public int WarehouseId { get; set; }
        public int Capacity { get; set; }
        public int NumberOfSectors { get; set; }
        public virtual ICollection<Sector> Sectors { get; set; }
    }
}