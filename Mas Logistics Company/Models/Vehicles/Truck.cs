using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mas_Logistics_Company.Enums;

namespace Mas_Logistics_Company.Models.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck()
        {
            
        }

        public Truck(int sideNumber, string plateNumber, VehicleStatus vechicleStatus, string brand, string model, int maxCapacity, string state,TruckType truckType)
        {
            SideNumber = sideNumber;
            PlateNumber = plateNumber;
            VehicleStatus = vechicleStatus;
            Brand = brand;
            Model = model;
            MaxCapacity = maxCapacity;
            State = state;
            TruckType = truckType;
            using (var ctx = new Context())
            {
                ctx.Vehicles.Add(this);
                ctx.SaveChanges();
            }
        }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        public int MaxCapacity { get; set; }
        [Required]
        public string State { get; set; }
        public TruckType TruckType { get; set; }
        public virtual ICollection<OrderTrailer> OrderTrailers { get; set; }
        public virtual ICollection<RepairTruck> RepairTrucks { get; set; }
        public virtual ICollection<DriverTruck> DriverTruck { get; set; }

        public override string ToString()
        {
            return $"Brand: {Brand}, Model: {Model}, State: {State}, TruckType: {TruckType} ";
        }
    }
}