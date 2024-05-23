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
    public partial class Login : Form
    {
       
        public Login()
        {
            InitializeComponent();
        }

        private void registerShowButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form registerAdminForm = new RegisterAdmin();
            registerAdminForm.ShowDialog();
            this.Close();
        }

        void ResetLabels()
        {
            usernameLabel.ForeColor = Color.Black;
            passwordLabel.ForeColor = Color.Black;
            adminLabel.ForeColor = Color.Black;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            ResetLabels();
            long id = -1;
            HandleUsers handleUsers = new HandleUsers();
            if (usernameLoginBox.Text != string.Empty && passwordLoginBox.Text != string.Empty)
            {
                id = handleUsers.Login(usernameLoginBox.Text, passwordLoginBox.Text, adminLoginBox.Text == String.Empty ? 0 : Int32.Parse(adminLoginBox.Text));
                if (id == 0)
                {
                    MessageBox.Show("User not found");
                }
                if (id > 0)
                {
                    User user = handleUsers.getUserById(id);
                    if (user is Admin)
                    {
                        this.Hide();
                        Form adminForm = new AdminForm((Admin)user);
                        adminForm.ShowDialog();
                        this.Close();
                    }
                    if (user is Customer)
                    {
                        this.Hide();
                        Form customerFrom = new CustomerForm((Customer)user);
                        customerFrom.ShowDialog();
                        this.Close();
                    }

                }
            }

            if (string.IsNullOrEmpty(usernameLoginBox.Text))
            {
                usernameLabel.ForeColor = Color.Red;
            }
            if (string.IsNullOrEmpty(passwordLoginBox.Text))
            {
                passwordLabel.ForeColor = Color.Red;
            }
            if(!string.IsNullOrEmpty(adminLoginBox.Text) && !Int32.TryParse(adminLoginBox.Text, out int n))
            {
                adminLabel.ForeColor = Color.Red;
            }

        }

    }
}
