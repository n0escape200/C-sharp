using Car;
using Motorcycle;
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
    public partial class AddMotorcycle : UserControl
    {
        long OwnerId;
        RepositoryClass repository;
        public AddMotorcycle(RepositoryClass _repository, long _OwnerId)
        {
            InitializeComponent();
            OwnerId = _OwnerId;
            repository = _repository;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int aux = 1;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        control.BackColor = Color.Red;
                        control.ForeColor = Color.White;
                        aux = 0;
                    }
                    else if (control.Name == "yearBox" || control.Name == "kmBox" || control.Name == "priceBox" || control.Name == "ccBox")
                    {
                        if (!string.IsNullOrEmpty(control.Text) && !Int32.TryParse(control.Text, out int n))
                        {
                            control.BackColor = Color.Red;
                            control.ForeColor = Color.White;
                            aux = 0;
                        }
                    }
                    else
                    {
                        control.BackColor = Color.White;
                        control.ForeColor = Color.Black;
                    }
                }
            }
            if (aux == 1)
            {
                MotorcycleClass motorcycle = new MotorcycleClass(OwnerId, brandBox.Text, modelBox.Text, yearBox.Text,
                Int32.Parse(kmBox.Text), Int32.Parse(priceBox.Text), conditionBox.Text, Int32.Parse(ccBox.Text),
                typeBox.Text);
                repository.Add(motorcycle);
                MessageBox.Show("Motorcycle created");
            }
        }
    }
}
