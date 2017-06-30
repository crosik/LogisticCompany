using System.ComponentModel.DataAnnotations;

namespace Mas_Logistics_Company.Models.Warehouses
{
    public class Dock
    {
        public Dock()
        {
            
        }
        public int DockId { get; set; }
        [Required]
        public string DockSymbol { get; set; }
        public virtual Freight Freight { get; set; }
        public virtual Sector Sector { get; set; }
        public void SetFreight(Freight freight)
        {
            Freight = freight;
        }
    }
}