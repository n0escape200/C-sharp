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
    public partial class AddByID : UserControl
    {
        RepositoryClass repository;
        public AddByID(RepositoryClass _repository)
        {
            InitializeComponent();
            repository = _repository;
        }

        private void addBox_Click(object sender, EventArgs e)
        {
            int aux = 1;
            foreach(Control control in Controls)
            {
                if(control is TextBox)
                {
                    if(string.IsNullOrEmpty(control.Text) || (!string.IsNullOrEmpty(control.Text) && !Int32.TryParse(control.Text, out int n)))
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
                if (repository.AddByIdToFile(Int32.Parse(indexBox.Text)))
                {
                    MessageBox.Show("Vehicle with id " + indexBox.Text + " was added to the DB");
                }
                else
                {
                    MessageBox.Show("Vehicle with id " + indexBox.Text + " doesn't exist");
                }
            }
        }
    }
}
