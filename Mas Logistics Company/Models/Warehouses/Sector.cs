using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mas_Logistics_Company.Models.Warehouses
{
    public class Sector
    {
        public Sector()
        {
            
        }
        public int SectorId { get; set; }
        [Required]
        public string SectorSymbol { get; set; }
        public virtual ICollection<Dock> Docks { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}