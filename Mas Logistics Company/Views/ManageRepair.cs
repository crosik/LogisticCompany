using System;
using System.Linq;
using System.Windows.Forms;
using Mas_Logistics_Company.Models;
using Mas_Logistics_Company.Models.Vehicles;

namespace Mas_Logistics_Company.Views
{
    public partial class ManageRepair : Form
    {
        public ManageRepair()
        {
            InitializeComponent();
            PopulateListbox();
        }
        private void PopulateListbox()
        {
            listBox1.Items.Clear();
            using (var ctx = new Context())
            {
                if (radioButton1.Checked)
                {
                    foreach (var truck in ctx.Vehicles.OfType<Truck>())
                    {
                        listBox1.Items.Add(truck);
                    }
                }
                else if (radioButton2.Checked)
                {
                    foreach (var trailer in ctx.Vehicles.OfType<Trailer>())
                    {
                       listBox1.Items.Add(trailer);
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PopulateListbox();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PopulateListbox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (radioButton2.Checked)
            {
                var selected = listBox1.SelectedItem as Trailer;
                using (var ctx = new Context())
                {
                    foreach (var repairTrailer in ctx.RepairTrailers.Where(p => p.Trailer.VehicleId == selected.VehicleId))
                    {
                        listBox2.Items.Add(repairTrailer);
                    }
                }
            }else if (radioButton1.Checked)
            {
                var selected = listBox1.SelectedItem as Truck;
                using (var ctx = new Context())
                {
                    foreach (var repairTruck in ctx.RepairTrucks.Where(p => p.Truck.VehicleId == selected.VehicleId))
                    {
                        listBox2.Items.Add(repairTruck);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
