using System;
using Mas_Logistics_Company.Models.Persons;
using Mas_Logistics_Company.Models.Vehicles;

namespace Mas_Logistics_Company.Models
{
    public class RepairTruck
    {
        public RepairTruck()
        {
            
        }

        public RepairTruck(string description, CarPerson carPerson, DateTime startDate, DateTime endDate, Truck truck, Context ctx)
        {
            var repair = new Repair(description, carPerson, this);
            StartDate = startDate;
            EndDate = endDate;
            Truck = truck;
                ctx.Repairs.Add(repair);
                ctx.RepairTrucks.Add(this);
                ctx.SaveChanges();
        }
        public int RepairTruckId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Repair Repair { get; set; }
        public virtual Truck Truck { get; set; }
        public override string ToString()
        {
            return $"Description: {Repair.Description}, Mechanic: {Repair.CarPerson.Person.Name}, StartDate:{StartDate.Date.ToShortDateString()}, EndDate:{EndDate.Date.ToShortDateString()}";

        }
    }
}