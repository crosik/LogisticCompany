using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mas_Logistics_Company.Enums;
using Mas_Logistics_Company.Models.Persons;
using Mas_Logistics_Company.Models.Vehicles;

namespace Mas_Logistics_Company.Views
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new AddRepair();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new ManageRepair();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person Andrzej = new Person("Andrzej","Mechanik","M",new DateTime(1995,12,12),"Adres 123 / 123 warszawa", "123123123","12312312310");
            HashSet<CarPersonType> ctypes = new HashSet<CarPersonType>();
            ctypes.Add(CarPersonType.Mechanic);
            Andrzej.BecomeCarPerson(null,null,10,ctypes);
            new Truck(1,"WE 123123", 0, "Scania", "R730",8000,"Perfect",0);
            new Truck(2, "WF 123123", 0, "Scania", "P400", 8000, "Perfect", TruckType.Daycab);
            new Truck(3, "WB 123123", 0, "Scania", "R500", 8000, "Perfect", TruckType.Straight);
            new Trailer(1, "plate", 0, 14000, 15, TrailerType.Dry);
            new Trailer(1, "plate", 0, 16000, 15, TrailerType.Reefer);
        }
    }
}
