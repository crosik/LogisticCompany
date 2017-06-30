using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mas_Logistics_Company.Enums;

namespace Mas_Logistics_Company.Models.Persons
{
    public class Person
    {
        public Person()
        {

        }

        public Person(string name, string surname, string sex, DateTime dateOfBirth,string address, string phoneNumber, string pesel)
        {
            Name = name;
            Surname = surname;
            Sex = sex;
            Address = address;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Pesel = pesel;
            using (var ctx = new Context())
            {
                ctx.Persons.Add(this);
                ctx.SaveChanges();
            }
        }

        public int PersonId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Pesel { get; set; }

        [Required]
        public string Address { get; set; }
        /// <summary>
        /// Returns Age of a person
        /// </summary>
        public int Age
        {
            get
            {
                if (DateOfBirth != null) return (DateOfBirth.Value.Day - DateTime.Now.Day) / 365;
                throw new Exception("Date of birth is null");
            }
        }

        public virtual Admin Admin { get; set; }
        public virtual Broker Broker { get; set; }
        public virtual CarPerson CarPerson { get; set; }
        public virtual SafetyWorker SafetyWorker { get; set; }
        public virtual Warehouseman Warehouseman { get; set; }
        /// <summary>
        /// XOR (Becomes Admin)
        /// </summary>
        public void BecomeAdmin()
        {
            using (var db = new Context())
            {
                var person = db.Persons.Find(PersonId);
                if (Broker != null)
                {
                    db.Brokers.Remove(Broker);
                    Broker = null;

                }

                if (CarPerson != null)
                {
                    db.CarPersons.Remove(CarPerson);
                    CarPerson = null;

                }

                if (Warehouseman != null)
                {
                    db.Warehousemans.Remove(Warehouseman);
                    Warehouseman = null;
                }

                if (SafetyWorker != null)
                {
                    db.Workers.Remove(SafetyWorker);
                    SafetyWorker = null;
                }

                Admin = new Admin();
                Admin.Person = this;
                db.Admins.Add(Admin);
                db.Entry(person).CurrentValues.SetValues(this);
                db.SaveChanges();
            }


        }
        /// <summary>
        /// XOR(Becomes Safety Worker)
        /// </summary>
        public void BecomeSafetyWorker()
        {
            using (var db = new Context())
            {
                var person = db.Persons.Find(PersonId);
                if (Broker != null)
                {
                    db.Brokers.Remove(Broker);
                    Broker = null;

                }

                if (CarPerson != null)
                {
                    db.CarPersons.Remove(CarPerson);
                    CarPerson = null;

                }

                if (Warehouseman != null)
                {
                    db.Warehousemans.Remove(Warehouseman);
                    Warehouseman = null;
                }

                if (Admin != null)
                {
                    db.Admins.Remove(Admin);
                    Admin = null;
                }

                SafetyWorker = new SafetyWorker();
                SafetyWorker.Person = this;
                db.Workers.Add(SafetyWorker);
                db.Entry(person).CurrentValues.SetValues(this);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// XOR(Becomes Broker)
        /// </summary>
        public void BecomeBroker()
        {
            using (var db = new Context())
            {
                var person = db.Persons.Find(PersonId);
                if (Admin != null)
                {
                    db.Admins.Remove(Admin);
                    Admin = null;

                }

                if (CarPerson != null)
                {
                    db.CarPersons.Remove(CarPerson);
                    CarPerson = null;

                }

                if (Warehouseman != null)
                {
                    db.Warehousemans.Remove(Warehouseman);
                    Warehouseman = null;
                }

                if (SafetyWorker != null)
                {
                    db.Workers.Remove(SafetyWorker);
                    SafetyWorker = null;
                }

                Broker = new Broker();
                Broker.Person = this;
                db.Brokers.Add(Broker);
                db.Entry(person).CurrentValues.SetValues(this);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// XOR(Become Warehouseman)
        /// </summary>
        /// <param name="medicalCertificate"></param>
        public void BecomeWarehouseman(string medicalCertificate)
        {
            using (var db = new Context())
            {
                var person = db.Persons.Find(PersonId);
                if (Broker != null)
                {
                    db.Brokers.Remove(Broker);
                    Broker = null;

                }

                if (CarPerson != null)
                {
                    db.CarPersons.Remove(CarPerson);
                    CarPerson = null;

                }

                if (Admin != null)
                {
                    db.Admins.Remove(Admin);
                    Admin = null;
                }

                if (SafetyWorker != null)
                {
                    db.Workers.Remove(SafetyWorker);
                    SafetyWorker = null;
                }

                Warehouseman = new Warehouseman(medicalCertificate);
                Warehouseman.Person = this;
                db.Warehousemans.Add(Warehouseman);
                db.Entry(person).CurrentValues.SetValues(this);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// XOR(Become Car Person)
        /// </summary>
        /// <param name="area"></param>
        /// <param name="specialization"></param>
        /// <param name="levelOfExp"></param>
        /// <param name="carPersonTypes"></param>
        public void BecomeCarPerson(Area? area, Specialization? specialization, int levelOfExp, HashSet<CarPersonType> carPersonTypes)
        {
            using (var db = new Context())
            {
                var person = db.Persons.Find(PersonId);
                if (Broker != null)
                {
                    db.Brokers.Remove(Broker);
                    Broker = null;

                }

                if (Warehouseman != null)
                {
                    db.Warehousemans.Remove(Warehouseman);
                    Warehouseman = null;

                }

                if (Admin != null)
                {
                    db.Admins.Remove(Admin);
                    Admin = null;
                }

                if (SafetyWorker != null)
                {
                    db.Workers.Remove(SafetyWorker);
                    SafetyWorker = null;
                }

                CarPerson = new CarPerson(area,specialization,levelOfExp,carPersonTypes);
                CarPerson.Person = this;
                db.CarPersons.Add(CarPerson);
                db.Entry(person).CurrentValues.SetValues(this);
                db.SaveChanges();
            }
        }
    }
}