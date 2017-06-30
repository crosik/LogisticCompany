using System;
using Mas_Logistics_Company.Models.Vehicles;

namespace Mas_Logistics_Company.Models
{
    public class OrderTrailer
    {
        public OrderTrailer()
        {
            
        }
        public int OrderTrailerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Order Order { get; set; }
        public Trailer Trailer { get; set; }
    }
}