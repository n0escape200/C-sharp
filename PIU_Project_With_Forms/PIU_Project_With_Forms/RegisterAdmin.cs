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
    public partial class RegisterAdmin : Form
    {
        HandleUsers handleUsers;
        public RegisterAdmin()
        {
            InitializeComponent();
            handleUsers = new HandleUsers();
            FirstNameARegisterBox.Focus();
        }

        private void RegisterShowCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form registerCustomer = new RegisterCustomer();
            registerCustomer.ShowDialog();
            this.Close();
        }

        private void loginShowButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form login = new Login();
            login.ShowDialog();
            this.Close();
        }

        void Reset()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    control.BackColor = Color.White;
                }
            }
        }
        private void RegisterAButton_Click(object sender, EventArgs e)
        {
            Reset();
            int aux = 1;
            foreach(Control control in Controls)
            {
                if(control is TextBox)
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        aux = 0;
                        control.BackColor = Color.Red;
                    }
                }
            }
            if(aux == 1)
            {
                if (AdminARegisterBox.Text != "35057")
                {
                    MessageBox.Show("Admin code incorrect");
                }
                else
                {
                    handleUsers.Register(new Admin(FirstNameARegisterBox.Text, LastNameARegisterBox.Text,
                        UsernameARegisterBox.Text, PasswordARegisterBox.Text));
                    MessageBox.Show("Admin registered");
                }
            }
        }
    }
}
