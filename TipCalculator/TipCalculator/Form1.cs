using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TipCalculator
{
    public partial class Form1 : Form
    {
       
       // Regex regex = new Regex("^[0 - 9]{1,5}\d{0, 9}(\.\d{1,3})?");
        public Form1()
        {
            InitializeComponent();
            textBox1.Text="0.00";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Regex.IsMatch(e.KeyChar, regex);
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar!='.') )
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        

        public void Tipcalculate()
        {
            int no_of_people = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));

            double tip = (Convert.ToDouble(textBox1.Text) * Convert.ToInt32(Math.Round(numericUpDown2.Value, 0))) / 100;

            double tippp = tip / no_of_people;

            double totalpp = (Double)Convert.ToDouble(textBox1.Text) / no_of_people;
            double total_bill_pp = totalpp + tippp;
            
            if(textBox1.Text.Length>0 && numericUpDown1.Value>0 && numericUpDown2.Value>=0)
            {
                textBox2.Text = tippp.ToString();
                textBox3.Text = total_bill_pp.ToString();
            }


        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Tipcalculate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Tipcalculate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Tipcalculate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i=1;i<comboBox1.Items.Count;i++)
            {
                String country = comboBox1.Text;
                if (country.Equals("USA"))
                {
                    label7.Text = "$";
                    label8.Text = "$";
                }
                else if (country.Equals("JAPAN"))
                {
                    label7.Text = "¥";
                    label8.Text = "¥";
                }
                else if (country.Equals("INDIA")) 
                {
                    label7.Text = "Rs";
                    label8.Text = "Rs";
                }
                else if (country.Equals("CHINA"))
                {
                    label7.Text = "圓";
                    label8.Text = "圓";
                }
                else
                {
                    label7.Text = "AU$";
                    label8.Text = "AU$";
                }
            }
        }
    }
}
