using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Mas_Logistics_Company.Enums;
using Mas_Logistics_Company.Models.Persons;
using Mas_Logistics_Company.Models.Warehouses;

namespace Mas_Logistics_Company.Models
{
    public class Order
    {
        public Order()
        {
            
        }

        public Order(string customerName, int price, string address, string type, Status status, int distance, string startLocation, Broker broker,Freight freight)
        {
            CustomerName = customerName;
            Price = price;
            Address = address;
            Type = type;
            Status = status;
            Distance = distance;
            StartLocation = startLocation;
            Broker = broker;
            Freight = freight;
            if (!Broker.Orders.ContainsKey(OrderId))
            {
                Broker.Orders.Add(OrderId, this);
            }
            using (var ctx = new Context())
            {
                ctx.Orders.Add(this);
                ctx.SaveChanges();
            }
        }
        public int OrderId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public int Price { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
            public string Type { get; set; }
        public Status Status { get; set; }
        public int Distance { get; set; }
        [Required]
        public string StartLocation { get; set; }

        public virtual Freight Freight { get; set; }
        public virtual OrderTrailer OrderTrailer { get; set; }
        public virtual OrderTruck OrderTruck { get; set; }
        public virtual Broker Broker { get; set; }
        /// <summary>
        /// Returns List of Orders
        /// </summary>
        /// <returns></returns>
        public static List<Order> Show()
        {
            using (var ctx = new Context())
            {
                return ctx.Orders.ToList();
            }
        }
    }
}