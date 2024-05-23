using Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository;
using Vehicle;
using Car;
using Truck;
using Motorcycle;

namespace PIU_Project_With_Forms
{
    public partial class AdminForm : Form
    {

        Admin admin;
        UserControl vehicleSelect;
        RepositoryClass repository;
        DeleteAtIndex deleteIndex;
        AddByID addByID;
        DataGridView dataGrid;
        ListBox listBox;
        UpdateCar updateCar;
        UpdateTruck updateTruck;
        UpdateMotorcycle updateMotorcycle;

        void HideEverythig()
        {
            dataGrid.Hide();
            vehicleSelect.Hide();
            deleteIndex.Hide();
            addByID.Hide();
            listBox.Hide();
            updateCar.Hide();
            updateTruck.Hide();
            updateMotorcycle.Hide();
        }

        public AdminForm(Admin _admin)
        {

            repository = new RepositoryClass();

            InitializeComponent();

            admin = _admin;
            FirstNameLabel.Text = admin.getFirstName();
            LastNameLabel.Text = admin.getLastName();
            OwnerIdLabel.Text = admin.getId().ToString();

            vehicleSelect = new VehicleSelection(repository, long.Parse(OwnerIdLabel.Text));
            vehicleSelect.Location = new Point(250, 33);
            Controls.Add(vehicleSelect);

            dataGrid = new DataGridView();
            dataGrid.Location = new Point(250, 33);
            dataGrid.CellClick += dataGridView_CellClick;
            Controls.Add(dataGrid);

            listBox = new ListBox();
            listBox.Location = new Point(250, 33 + dataGrid.Size.Height) ;
            listBox.Size = new Size(200, 200);
            Controls.Add(listBox);

            deleteIndex = new DeleteAtIndex(repository);
            deleteIndex.Location = new Point(250, 33);
            Controls.Add(deleteIndex);

            addByID = new AddByID(repository);
            addByID.Location = new Point(250, 33);
            Controls.Add(addByID);

            updateCar = new UpdateCar(repository,admin);
            updateCar.Location = new Point(listBox.Location.X + updateCar.Size.Width, listBox.Location.Y);
            Controls.Add(updateCar);

            updateTruck = new UpdateTruck(repository, admin);
            updateTruck.Location = new Point(listBox.Location.X + updateTruck.Size.Width, listBox.Location.Y);
            Controls.Add(updateTruck);

            updateMotorcycle = new UpdateMotorcycle(repository, admin);
            updateMotorcycle.Location = new Point(listBox.Location.X + updateMotorcycle.Size.Width, listBox.Location.Y);
            Controls.Add(updateMotorcycle);



            HideEverythig();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HideEverythig();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGrid.Rows[e.RowIndex];
                int _id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                VehicleClass veh = repository.GetById(_id);

                if(veh != null)
                {
                    if(veh is CarClass)
                    {
                        CarClass _veh = veh as CarClass;
                        listBox.Items.Clear();
                        listBox.Items.Add("Brand:" + _veh.Brand);
                        listBox.Items.Add("Model:" + _veh.Model);
                        listBox.Items.Add("Year:" + _veh.Year);
                        listBox.Items.Add("KM:" + _veh.Km);
                        listBox.Items.Add("Price:" + _veh.Price);
                        listBox.Items.Add("State:" + _veh.Condition);
                        listBox.Items.Add("Number of doors:" + _veh.NrOfDoors);
                        listBox.Items.Add("Horse power:" + _veh.CP);
                        listBox.Items.Add("Body:" + _veh.Body);
                        updateCar.Updatedetails(_veh);
                        updateCar.SetCarId(_id);
                    }
                    if(veh is TruckClass)
                    {
                        TruckClass _veh = veh as TruckClass;
                        listBox.Items.Clear();
                        listBox.Items.Add("Brand:" + _veh.Brand);
                        listBox.Items.Add("Model:" + _veh.Model);
                        listBox.Items.Add("Year:" + _veh.Year);
                        listBox.Items.Add("KM:" + _veh.Km);
                        listBox.Items.Add("Price:" + _veh.Price);
                        listBox.Items.Add("State:" + _veh.Condition);
                        listBox.Items.Add("Cargo capacity:" + _veh.CargoCapacity);
                        listBox.Items.Add("Tow capacity:" + _veh.TowCapacity);
                        updateTruck.SetTruckId(_id) ;
                    }
                    if(veh is MotorcycleClass)
                    {
                        MotorcycleClass _veh = veh as MotorcycleClass;
                        listBox.Items.Clear();
                        listBox.Items.Add("Brand:" + _veh.Brand);
                        listBox.Items.Add("Model:" + _veh.Model);
                        listBox.Items.Add("Year:" + _veh.Year);
                        listBox.Items.Add("KM:" + _veh.Km);
                        listBox.Items.Add("Price:" + _veh.Price);
                        listBox.Items.Add("State:" + _veh.Condition);
                        listBox.Items.Add("CC:" + _veh.CC);
                        listBox.Items.Add("Type:" + _veh.Type);
                        updateMotorcycle.SetMotorcycleId(_id);
                    }
                    
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HideEverythig();
            dataGrid.DataSource = null;
            dataGrid.DataSource = repository.GetAll();
            dataGrid.AutoSize = true;
            dataGrid.Show();
            listBox.Show();
            updateCar.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            HideEverythig();
            deleteIndex.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HideEverythig();
            vehicleSelect.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            repository.GetDataFromFileById(admin.getId());
            MessageBox.Show("Data from DB was added to the local repository");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            HideEverythig();
            addByID.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(repository.GetSize() > 0)
            {
                repository.AddRepoToFile();
                MessageBox.Show("Repository added to the DB");
            }
            else
            {
                MessageBox.Show("Repository is empty");
            }

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}
