﻿using System;
using Mas_Logistics_Company.Models.Vehicles;

namespace Mas_Logistics_Company.Models
{
    public class OrderTruck
    {
        public OrderTruck()
        {
            
        }
        public int OrderTruckId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Truck Truck { get; set; }
        public Order Order { get; set; }
    }
}