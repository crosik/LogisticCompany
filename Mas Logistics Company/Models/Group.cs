using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using Mas_Logistics_Company.Enums;
using Mas_Logistics_Company.Models.Persons;

namespace Mas_Logistics_Company.Models
{
    public class Group
    {
        public Group()
        {
            
        }
        public int GroupId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<CarPerson> CarPersons { get; set; }
        public virtual CarPerson Leader { get; set; }

        public Group(string name, CarPerson leader)
        {
            int counter = 0;
            using (var ctx = new Context())
            {
                foreach (var carPersonType in ctx.CarPersonTypes.Where(p => p.CarPerson.Id == leader.Id))
                {
                    if (carPersonType.PersonType == CarPersonType.Driver)
                    {
                        Name = name;
                        Leader = leader;
                        counter++;
                        if (ctx.Groups.ToList().Count < 2)
                        {
                            ctx.Groups.Add(this);
                            ctx.SaveChanges();
                        }
                        throw new Exception("there are 2 groups already");
                    }

                }
                if (counter == 0)
                {
                    throw new Exception("Person needs to be a Driver");
                }
            }
        }

        public void AddDriver(CarPerson carPerson)
        {
            int counter = 0;
            using (var ctx = new Context())
            {
                foreach (var carPersonType in ctx.CarPersonTypes.Where(p => p.CarPerson.Id == carPerson.Id))
                {
                    if (carPersonType.PersonType == CarPersonType.Driver)
                    {
                        counter++;
                        carPerson.Group = this;
                        CarPersons.Add(carPerson);
                        ctx.Entry(carPerson).State = EntityState.Modified;
                         ctx.SaveChanges();
                    }
            }
                if (counter == 0)
                {
                    throw new Exception("Person needs to be a driver");
                }

        }
    }
}
    }