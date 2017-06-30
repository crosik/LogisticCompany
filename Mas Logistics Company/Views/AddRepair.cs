using System;
using System.Linq;
using System.Windows.Forms;
using Mas_Logistics_Company.Models;
using Mas_Logistics_Company.Models.Persons;
using Mas_Logistics_Company.Models.Vehicles;

namespace Mas_Logistics_Company.Views
{
    public partial class AddRepair : Form
    {
        private Context ctx;
        public AddRepair()
        {
            InitializeComponent();
            ctx = new Context();
            Populate();
            PopulateVechicles();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void PopulateVechicles()
        {
            comboBox1.Items.Clear();

            
                if (radioButton1.Checked)
                {
                    foreach (var truck in ctx.Vehicles.OfType<Truck>())
                    {
                        comboBox1.Items.Add(truck);
                    }
                }
                else if (radioButton2.Checked)
                {
                    foreach (var trailer in ctx.Vehicles.OfType<Trailer>())
                    {
                        comboBox1.Items.Add(trailer);
                    }
                }
            
        }

        private void Populate()
        {

            {
                var list = ctx.CarPersons.ToList();
                foreach (var carPerson in list)
                {
                    comboBox2.Items.Add(carPerson);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PopulateVechicles();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PopulateVechicles();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dateTimePicker1.Value - dateTimePicker2.Value).Days <= 0)
                {
                    var selectedCarPerson = comboBox2.SelectedItem as CarPerson;
                    if (selectedCarPerson != null)
                    {
                        var dbCarPerson =
                            ctx.CarPersons.FirstOrDefault(p => p.Id == selectedCarPerson.Id);
                        if (radioButton1.Checked)
                        {
                            var selectedTruck = comboBox1.SelectedItem as Truck;
                            if (selectedTruck != null)
                            {
                                var dbTruck = ctx.Vehicles.OfType<Truck>()
                                    .FirstOrDefault(p => p.VehicleId == selectedTruck.VehicleId);
                                new RepairTruck(textBox1.Text, dbCarPerson, dateTimePicker1.Value.Date,
                                    dateTimePicker2.Value.Date, dbTruck, ctx);
                                MessageBox.Show("Succesfully created Truck Repair");
                                Close();
                            }
                            else
                            {
                                throw new Exception("Selected Truck cant be null");
                            }
                        }
                        else if (radioButton2.Checked)
                        {
                            var selectedTrailer = comboBox1.SelectedItem as Trailer;
                            if (selectedTrailer != null)
                            {
                                var dbTrailer = ctx.Vehicles.OfType<Trailer>()
                                    .FirstOrDefault(p => p.VehicleId == selectedTrailer.VehicleId);
                                new RepairTrailer(textBox1.Text, dbCarPerson, dateTimePicker1.Value.Date,
                                    dateTimePicker2.Value.Date, dbTrailer, ctx);
                                MessageBox.Show("Succesfully created Trailer Repair");
                                Close();
                            }
                            else
                            {
                                throw new Exception("Selected Trailer cant be null");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Selected Person cant be null");
                    }
                }
                else
                {
                    throw new Exception("Start date cant be after End Date");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
