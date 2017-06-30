using System;
using Mas_Logistics_Company.Models.Persons;
using Mas_Logistics_Company.Models.Vehicles;

namespace Mas_Logistics_Company.Models
{
    public class RepairTrailer
    {
        public RepairTrailer()
        {
            
        }
        public RepairTrailer(string description, CarPerson carPerson, DateTime startDate, DateTime endDate, Trailer trailer, Context ctx)
        {
            var repair = new Repair(description, carPerson, this);
            StartDate = startDate;
            EndDate = endDate;
            Trailer = trailer;
                ctx.Repairs.Add(repair);
                ctx.RepairTrailers.Add(this);
                ctx.SaveChanges();            
        }
        public int RepairTrailerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Repair Repair { get; set; }
        public virtual Trailer Trailer { get; set; }

        public override string ToString()
        {
            return $"Description: {Repair.Description}, Mechanic: {Repair.CarPerson.Person.Name}, StartDate:{StartDate.Date.ToShortDateString()}, EndDate:{EndDate.Date.ToShortDateString()}";
        }
    }
}