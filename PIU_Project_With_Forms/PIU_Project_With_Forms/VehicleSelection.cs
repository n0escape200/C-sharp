using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIU_Project_With_Forms
{
    public partial class VehicleSelection : UserControl
    {
        RepositoryClass repository;

        AddCar addCar;
        AddMotorcycle addMotorcycle;
        AddTruck addTruck;

        long OwnerId;
        public VehicleSelection(RepositoryClass _repository, long ownerId)
        {
            repository = _repository;
            InitializeComponent();
            OwnerId = ownerId;

            addCar = new AddCar(repository, ownerId);
            addMotorcycle = new AddMotorcycle(repository, ownerId);
            addTruck = new AddTruck(repository, ownerId);

            addCar.Location = new Point(0, 56);
            addMotorcycle.Location = new Point(0, 56);
            addTruck.Location = new Point(0, 56);

            Controls.Add(addCar);
            Controls.Add(addMotorcycle);
            Controls.Add(addTruck);

            addCar.Hide();
            addTruck.Hide();
            addMotorcycle.Hide();
            
        }

        private void CarSelect_Click(object sender, EventArgs e)
        {
            addCar.Show();
            addTruck.Hide();
            addMotorcycle.Hide();
        }

        private void TruckSelect_Click(object sender, EventArgs e)
        {
            addCar.Hide();
            addTruck.Show();
            addMotorcycle.Hide();
        }

        private void MotorcycleSelect_Click(object sender, EventArgs e)
        {
            addCar.Hide();
            addTruck.Hide();
            addMotorcycle.Show();
        }

        private void addMotorcycle1_Load(object sender, EventArgs e)
        {

        }
    }
}
