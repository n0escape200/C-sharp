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
using Authentication;
using Vehicle;

namespace PIU_Project_With_Forms
{
    public partial class BuyVehicle : UserControl
    {
        RepositoryClass repository;
        Customer customer;
        Label bugetLabel;
        public BuyVehicle(Customer _customer,RepositoryClass _repository,Label _bugetLabel)
        {
            InitializeComponent();
            repository = _repository;
            customer = _customer;
            bugetLabel = _bugetLabel;
        }

        private void buyBox_Click(object sender, EventArgs e)
        {

            int aux = 1;
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty(control.Text) || (!string.IsNullOrEmpty(control.Text) && !Int32.TryParse(control.Text, out int n)))
                    {
                        aux = 0;
                        control.BackColor = Color.Red;
                        control.ForeColor = Color.White;
                    }
                    else
                    {
                        aux = 1;
                        control.BackColor = Color.White;
                        control.ForeColor = Color.Black;
                    }
                }
            }
            if(aux == 1)
            {
                VehicleClass vehicle = repository.GetById(Int32.Parse(indexBox.Text));
                if (vehicle != new VehicleClass())
                {
                    if (repository.PurchesCar(customer, vehicle))
                    {
                        MessageBox.Show("Car purchased");
                        bugetLabel.Text = customer.GetBuget().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Not enough money");
                    }
                }
                else
                {
                    MessageBox.Show("Vehicle with id " + indexBox.Text + " doesn't exist");
                }
            }
        }
    }
}
