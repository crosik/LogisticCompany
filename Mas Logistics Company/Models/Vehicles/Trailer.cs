using System.Collections.Generic;
using Mas_Logistics_Company.Enums;

namespace Mas_Logistics_Company.Models.Vehicles
{
    public class Trailer : Vehicle
    {
        public Trailer()
        {
            
        }

        public Trailer(int sideNumber, string plateNumber, VehicleStatus vechicleStatus, int capacity, int lenght,
            TrailerType trailerType)
        {
            SideNumber = sideNumber;
            PlateNumber = plateNumber;
            VehicleStatus = vechicleStatus;
            Capacity = capacity;
            Length = lenght;
            TrailerType = trailerType;
            using (var ctx = new Context())
            {
                ctx.Vehicles.Add(this);
                ctx.SaveChanges();
            }
        }
        public int Capacity { get; set; }
        public int Length { get; set; }
        public TrailerType TrailerType { get; set; }
        public virtual ICollection<OrderTrailer> OrderTrailers { get; set; }
        public virtual ICollection<RepairTrailer> RepairTrailers { get; set; }
        public override string ToString()
        {
            return $"Capacity: {Capacity}, Lenght: {Length}, TrailerType: {TrailerType}";
        }
    }
}