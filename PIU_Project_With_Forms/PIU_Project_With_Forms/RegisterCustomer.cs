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

namespace PIU_Project_With_Forms
{
    public partial class RegisterCustomer : Form
    {
        HandleUsers handleUsers;
        public RegisterCustomer()
        {
            InitializeComponent();
            handleUsers = new HandleUsers();
            FirstNameCRegisterBox.Focus();
        }

        private void RegisterShowAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form registerAdmin = new RegisterAdmin();
            registerAdmin.ShowDialog();
            this.Close();   
        }

        private void loginShowButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form login = new Login();
            login.ShowDialog();
            this.Close();
        }


        private void RegisterCButton_Click(object sender, EventArgs e)
        {
            int aux = 1;
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        aux = 0;
                        control.BackColor = Color.Red;
                        control.ForeColor = Color.White;
                    }else if(control.Name == "BugetBox" && !Int32.TryParse(control.Text,out int n))
                    {
                        aux = 0;
                        control.BackColor = Color.Red;
                        control.ForeColor = Color.White;
                    }
                    else
                    {
                        control.BackColor = Color.White;
                        control.ForeColor = Color.Black;
                    }
                }
            }
           if(aux == 1)
            {
                handleUsers.Register(new Customer(FirstNameCRegisterBox.Text, LastNameCRegisterBox.Text, UsernameCRegisterBox.Text, PasswordCRegisterBox.Text,
                   Int32.Parse(BugetBox.Text)));
                MessageBox.Show("Customer registered");
            }
        }
    }
}
