using System;
using System.Linq;
using Mas_Logistics_Company.Enums;
using Mas_Logistics_Company.Models.Persons;
using Mas_Logistics_Company.Models.Vehicles;

namespace Mas_Logistics_Company.Models
{
    public class DriverTruck
    {
        public DriverTruck()
        {
            
        }

        public DriverTruck(CarPerson carPerson, DateTime startDate, DateTime endDate, Truck truck)
        {
            int counter = 0;
            using (var ctx = new Context())
            {
                foreach (var carPersonType in ctx.CarPersonTypes.Where(p=>p.CarPerson.Id == carPerson.Id))
                {
                    if (carPersonType.PersonType == CarPersonType.Mechanic)
                    {
                        CarPerson = carPerson;
                        StartDate = startDate;
                        EndDate = endDate;
                        Truck = truck;
                        counter++;
                        ctx.DriverTrucks.Add(this);
                        ctx.SaveChanges();
                    }
                }
                if (counter == 0)
                {
                    throw new Exception("Person is not mechanic");
                }
               
            }
        }
        public int DriverTruckId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Truck Truck { get; set; }
        public virtual CarPerson CarPerson { get; set; }

    }
}