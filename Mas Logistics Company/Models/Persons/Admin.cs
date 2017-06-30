using System;

namespace Mas_Logistics_Company.Models.Persons
{
    public class Admin
    {
        public Admin()
        {
            
        }
        public int AdminId { get; set; }

        /// <summary>
        /// Creates new Person in DB
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="sex"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="pesel"></param>
        public void AddUser(string name, string surname, string sex, DateTime dateOfBirth,string address, string phoneNumber, string pesel)
        {
            new Person(name, surname, sex, dateOfBirth,address, phoneNumber, pesel);
        }

        public virtual Person Person { get; set; }
    }
}