using System.ComponentModel.DataAnnotations;

namespace Mas_Logistics_Company.Models.Warehouses
{
    public class Freight
    {
        public Freight()
        {
            
        }
        public int FreightId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual Order Order { get; set; }
        public virtual Dock Dock { get; set; }
    }
}