using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*************************************************************************************
**            This app Calculates a customer bill from the city power company.      **
**              Author: Gabriel Capobianco                                          **
**              Date: December 2020                                                 **
*************************************************************************************/
namespace Lab1_Gabriel_Capobianco
{
    public partial class BillCalculator : Form
    {
        const double RESI = 6.00;           //residential rate
        const double COMM = 60.00;          //commercial rate
        const double IND_PEAK = 76.00;      //Industrial peak hour rate
        const double IND_OFF = 40.00;       //Industrial off-peak hour rate

        public BillCalculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // When the form loads the Industrial box will be hidden and Residential radio button selected as default
            industrialBox.Visible = false;
            radioButtonResidential.Checked = true;
        }

        private void radioButtonResidential_CheckedChanged(object sender, EventArgs e)
        {
            // When selected industrial box will be hidden
            industrialBox.Visible = false;
            label2.Visible = true;
            textBox1.Visible = true;
        }

        private void btnCalculate_Click(object sender, EventArgs e)     // Button that calls the methods to calculate the bill total
        {
            // Declaration of variables to use
            double usage;
            double billTotal;
            double peakUsage, offPeakUsage;

            if (radioButtonResidential.Checked == true && Validator.IsPresent(textBox1, "Residential Usage"))  // When the Radio button Residential is selected
            {
                // when Residential radio button is selected the Usage text box is tested to see if it is empty
                // or if the input is negative
                if (Validator.IsPositive(textBox1.Text, "Residential Usage"))
                {
                    usage = Convert.ToDouble(textBox1.Text);
                    billTotal = Calculate.ResiTotal(RESI, usage);       // Calculate the bill total thru a method
                    txtTotal.Text = billTotal.ToString("c");        // Show total in Currency format
                }
            }

            if (radioButtonCommercial.Checked == true && Validator.IsPresent(textBox1, "Commercial Usage"))    // When the Radio button Comercial is selected
            {
                // when Commercial radio button is selected the Usage text box is tested to see if it is empty
                // or if the input is negative
                if (Validator.IsPositive(textBox1.Text, "Commercial Usage"))
                {
                    usage = Convert.ToDouble(textBox1.Text);
                    billTotal = Calculate.CommTotal(COMM, usage);       // Calculate the bill total thru a method
                    txtTotal.Text = billTotal.ToString("c");            // Show total in Currency format
                }
            }

            if (radioButtonIndustrial.Checked == true)
            {
                // when Industrial radio button is selected the Peak and Off-Peak hours text boxes are tested to see if they are empty
                // or if the input is negative
                if (Validator.IsPresent(textBox2, "Peak hours Usage") && Validator.IsPresent(textBox3, "Off-Peak hours Usage"))
                {
                    if (Validator.IsPositive(textBox2.Text, "Peak hours Usage") && Validator.IsPositive(textBox3.Text, "Off-Peak hours Usage"))
                    {
                        peakUsage = Convert.ToDouble(textBox2.Text);
                        offPeakUsage = Convert.ToDouble(textBox3.Text);
                        billTotal = Calculate.IndTotal(IND_PEAK, IND_OFF, peakUsage, offPeakUsage);     // Calculate the bill total thru a method
                        txtTotal.Text = billTotal.ToString("c");                                        // Show total in Currency format
                    }
                }
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            // Erase whatever it is in the text boxes and put the app to default
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            txtTotal.Text = "";
            industrialBox.Visible = false;
            radioButtonResidential.Checked = true;
            textBox1.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)          // Terminate the application
        {
            //Application.Exit();
            this.Close();
        }

        private void radioButtonCommercial_CheckedChanged(object sender, EventArgs e)
        {
            // When selected industrial box will be hidden
            industrialBox.Visible = false;
            label2.Visible = true;
            textBox1.Visible = true;
        }

        private void radioButtonIndustrial_CheckedChanged(object sender, EventArgs e)
        {
            // When selected industrial box will show and residential and commercial usage text box hidden
            industrialBox.Visible = true;
            label2.Visible = false;
            textBox1.Visible = false;
        }





    }
    
}

    
 


