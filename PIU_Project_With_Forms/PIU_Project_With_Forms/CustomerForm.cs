using Authentication;
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
    public partial class CustomerForm : Form
    {
        RepositoryClass repository;
        BuyVehicle buyVehicle;
        DataGridView dataGridView;
        DataGridView dataGridView2;
        void HideEverything()
        {
           
            buyVehicle.Hide();
            dataGridView.Hide();
            dataGridView2.Hide();

        }
        public CustomerForm(Customer customer)
        {
            InitializeComponent();
            repository = new RepositoryClass();

            FirstNameLabel.Text = customer.getFirstName();
            LastNameLabel.Text = customer.getLastName();
            OwnerIdLabel.Text = customer.getId().ToString();
            bugetlabel.Text = customer.GetBuget().ToString();

            repository.GetDataFromFile();

            dataGridView  = new DataGridView();
            dataGridView.Location = new Point(250, 33);
            Controls.Add(dataGridView);

            dataGridView2 = new DataGridView();
            dataGridView2.Location = new Point(250, 33);
            Controls.Add(dataGridView2);

            buyVehicle = new BuyVehicle(customer, repository, bugetlabel);
            buyVehicle.Location = new Point(250, 33);
            Controls.Add(buyVehicle);

            HideEverything();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HideEverything();
            dataGridView.DataSource = null;
            dataGridView.DataSource = repository.GetAll();
            dataGridView.AutoSize = true;
            dataGridView.Show();
            if (dataGridView.Columns.Contains("OwnerId"))
            {
                dataGridView.Columns.Remove("OwnerId");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideEverything();
            buyVehicle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HideEverything();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = repository.GetPurchesedCars();
            dataGridView2.AutoSize = true;
            if (dataGridView2.Columns.Contains("OwnerId"))
            {
                dataGridView2.Columns.Remove("OwnerId");
            }
            dataGridView2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}
