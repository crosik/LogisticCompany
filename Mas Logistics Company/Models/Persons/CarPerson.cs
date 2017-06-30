using System;
using System.Collections.Generic;
using System.Linq;
using Mas_Logistics_Company.Enums;
using Mas_Logistics_Company.Interfaces;

namespace Mas_Logistics_Company.Models.Persons
{
    public class CarPerson : IDriver, IMechanic
    {
        public CarPerson()
        {
            
        }

        public CarPerson(Area? area, Specialization? specialization, int levelOfExp, HashSet<CarPersonType> carPersonTypes)
        {
            if (carPersonTypes != null)
            {
                if (carPersonTypes.Count > 0)
                {
                    foreach (var carPersonType in carPersonTypes)
                    {
                        
                        using (var ctx = new Context())
                        {
                            ctx.CarPersonTypes.Add(new CPersonType
                            {
                                CarPerson = this,
                                PersonType = carPersonType
                            });
                        }
                    }
                    Area = area;
                    Specialization = specialization;
                    LevelOfExp = levelOfExp;
                }
                else
                {
                    throw new Exception("Car Person needs more types than 0!");
                }
            }
            else
            {
                throw new Exception("Car Person types cant be null");
            }
        }
        public int Id { get; set; }
        public Area? Area { get; set; }
        public Specialization? Specialization { get; set; }
        public int LevelOfExp { get; set; }
        public virtual ICollection<CPersonType> CarPersonTypes { get; set; }
        public virtual Person Person { get; set; }
        /// <summary>
        /// Driver can add a driver truck
        /// </summary>
        public void AddTruck()
        {
            using (var ctx = new Context())
            {
                foreach (var carPersonType in CarPersonTypes)
                {
                    if (carPersonType.PersonType == CarPersonType.Driver)
                    {
                        //TODO
                    }
                }
            }
        }
        /// <summary>
        /// Mechanic can assign a Repair
        /// </summary>
        public void AssignRepair()
        {
            using (var ctx = new Context())
            {
                foreach (var carPersonType in CarPersonTypes)
                {
                    if (carPersonType.PersonType == CarPersonType.Mechanic)
                    {
                        //TODO
                    }
                }
            }
        }

        /// <summary>
        /// Mechanic can assign a mechanic to an repair
        /// </summary>
        public void AssignMechanic()
        {
            using (var ctx = new Context())
            {
                foreach (var carPersonType in CarPersonTypes)
                {
                    if (carPersonType.PersonType == CarPersonType.Mechanic)
                    {
                        //TODO
                    }
                }
            }
        }
        /// <summary>
        /// Mechanic can manage repairs
        /// </summary>
        public void ManageRepairs()
        {
            using (var ctx = new Context())
            {
                foreach (var carPersonType in CarPersonTypes)
                {
                    if (carPersonType.PersonType == CarPersonType.Mechanic)
                    {
                        //TODO
                    }
                }
            }
        }
        /// <summary>
        /// List of all CarPersons from DB
        /// </summary>
        /// <returns></returns>
        public static List<CarPerson> CarPersonList()
        {
            using (var ctx = new Context())
            {
                return ctx.CarPersons.ToList();
            }
        }

        public virtual ICollection<Repair> Repairs { get; set; }
        public virtual ICollection<DriverTruck> DriverTrucks { get; set; }
        public virtual Group Group { get; set; }
        public virtual Group LeaderOfGroup { get; set; }

        public override string ToString()
        {
            return $"Name: {Person.Name}, PhoneNumber: {Person.PhoneNumber}, Level Of Exp: {LevelOfExp}";
        }
    }
}