using Authentication;
using Car;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Truck;

namespace PIU_Project_With_Forms
{
    public partial class UpdateTruck : UserControl
    {
        int carId;
        RepositoryClass repository;
        Admin admin;

        public UpdateTruck(RepositoryClass _repository, Admin _admin)
        {
            InitializeComponent();
            repository = _repository;
            admin = _admin;
            carId = -1;
        }

        public void SetTruckId(int id)
        {
            carId = id;
        }

        public void Updatedetails(TruckClass car)
        {
            brandBox.Text = car.Brand;
            modelBox.Text = car.Model;
            yearBox.Text = car.Year;
            kmBox.Text = car.Km.ToString();
            priceBox.Text = car.Price.ToString();
            conditionBox.Text = car.Condition;
            cargoBox.Text = car.CargoCapacity.ToString();
            towBox.Text = car.TowCapacity.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string truckFile = "../../../Repository/Truck.txt";
            if (carId == -1)
            {
                MessageBox.Show("No vehicle selected");
            }
            else
            {
                TruckClass newTruck = new TruckClass(admin.getId(), brandBox.Text, modelBox.Text, yearBox.Text,
                    Int32.Parse(kmBox.Text), Int32.Parse(priceBox.Text), conditionBox.Text, Int32.Parse(cargoBox.Text),
                    Int32.Parse(towBox.Text));

                TruckClass lookFor = (TruckClass)repository.GetById(carId);
                repository.UpdateByIndex(carId, newTruck);

                List<string> data = new List<string>(File.ReadAllLines(truckFile));
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i] == lookFor.FormatDataForFileSave())
                    {
                        data[i] = newTruck.FormatDataForFileSave();
                        File.WriteAllLines(truckFile, data);
                        MessageBox.Show("Motorcycle file updated");
                        break;
                    }
                }
            }
        }
    }
}
