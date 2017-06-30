using System.ComponentModel.DataAnnotations;
using Mas_Logistics_Company.Enums;

namespace Mas_Logistics_Company.Models.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle()
        {
            
        }
        public int VehicleId { get; set; }
        public int SideNumber { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
    }
}