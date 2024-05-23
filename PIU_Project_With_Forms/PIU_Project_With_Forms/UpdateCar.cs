using Authentication;
using Car;
using Motorcycle;
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
    public partial class UpdateCar : UserControl
    {
        int carId;
        RepositoryClass repository;
        Admin admin;
        public UpdateCar(RepositoryClass _repository,Admin _admin)
        {
            InitializeComponent();
            repository = _repository;
            admin = _admin;
            carId = -1;
        }

        public void SetCarId(int id) {
            carId = id;
        }

        public void Updatedetails(CarClass car)
        {
            brandBox.Text = car.Brand;
            modelBox.Text = car.Model;
            yearBox.Text = car.Year;
            kmBox.Text = car.Km.ToString();
            priceBox.Text = car.Price.ToString();
            conditionBox.Text = car.Condition;
            doorBox.Text = car.NrOfDoors.ToString();
            cpBox.Text = car.CP.ToString();
            bodyBox.Text = car.Body;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string carFile = "../../../Repository/Car.txt";
            if (carId == -1)
            {
                MessageBox.Show("No vehicle selected");
            }
            else
            {
                CarClass newCar = new CarClass(admin.getId(), brandBox.Text, modelBox.Text, yearBox.Text,
                    Int32.Parse(kmBox.Text), Int32.Parse(priceBox.Text), conditionBox.Text, Int32.Parse(doorBox.Text),
                    Int32.Parse(cpBox.Text), bodyBox.Text);

                CarClass lookFor = (CarClass)repository.GetById(carId);
                repository.UpdateByIndex(carId, newCar);
                

                List<string> data = new List<string>(File.ReadAllLines(carFile));
                for(int i =  0; i < data.Count; i++)
                {
                    if (data[i] == lookFor.FormatDataForFileSave())
                    {
                        data[i] = newCar.FormatDataForFileSave();
                        File.WriteAllLines(carFile, data);
                        MessageBox.Show("Car file updated");
                        break;  
                    }
                }  
            }
        }
    }
}
