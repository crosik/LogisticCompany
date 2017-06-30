using System.Collections.Generic;
using System.Data.Entity;
using Mas_Logistics_Company.Enums;
using Mas_Logistics_Company.Models.Warehouses;

namespace Mas_Logistics_Company.Models.Persons
{
    public class Broker
    {
        public Broker()
        {
            
        }
        public int BrokerId { get; set; }

        /// <summary>
        /// Creates New order in DB
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="price"></param>
        /// <param name="address"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="distance"></param>
        /// <param name="startLocation"></param>
        /// <param name="broker"></param>
        /// <param name="freight"></param>
        public void NewOrder(string customerName, int price, string address, string type, Status status, int distance, string startLocation, Broker broker, Freight freight)
        {
            new Order(customerName, price, address, type, status, distance, startLocation, broker, freight);
        }
        /// <summary>
        /// Edit existing order in DB
        /// </summary>
        /// <param name="order"></param>
        public void EditOrder(Order order)
        {
            using (var ctx = new Context())
            {
                ctx.Entry(order).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public virtual Person Person { get; set; }

        public Dictionary<int,Order> Orders { get; set; }
    }
}