using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Mas_Logistics_Company.Enums;
using Mas_Logistics_Company.Models.Persons;

namespace Mas_Logistics_Company.Models
{
    public class Repair
    {
        public Repair()
        {
            
        }

        public Repair(string description, CarPerson carPerson, RepairTruck repairTruck)
        {
            int counter = 0;
            using (var ctx = new Context())
            {
                foreach (var carPersonType in ctx.CarPersonTypes.Where(p => p.CarPerson.Id == carPerson.Id))
                {
                    if (carPersonType.PersonType == CarPersonType.Mechanic)
                    {
                        counter++;
                        Description = description;
                        CarPerson = carPerson;
                        RepairTruck = repairTruck;
                    }
                }
                if (counter == 0)
                {
                    throw new Exception("Person needs to be a Mechanic");
                }
            }
        }

        public Repair(string description, CarPerson carPerson, RepairTrailer repairTrailer)
        {
            int counter = 0;
            using (var ctx = new Context())
            {
                foreach (var carPersonType in ctx.CarPersonTypes.Where(p => p.CarPerson.Id == carPerson.Id))
                {
                    if (carPersonType.PersonType == CarPersonType.Mechanic)
                    {
                        counter++;
                        Description = description;
                        CarPerson = carPerson;
                        RepairTrailer = repairTrailer;
                    }
                }
                if (counter == 0)
                {
                    throw new Exception("Person needs to be a Mechanic");
                }
            }
        }

        public int RepairId { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual RepairTruck RepairTruck { get; set; }
        public virtual RepairTrailer RepairTrailer { get; set; }
        public virtual CarPerson CarPerson { get; set; }

        /// <summary>
        /// Returns list of all Repairs
        /// </summary>
        /// <returns></returns>
        public static List<Repair> RepairsList()
        {
            using(var ctx = new Context())
            {
                return ctx.Repairs.ToList();
            }
        }
    }
}