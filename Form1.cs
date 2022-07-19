using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;


namespace ParkCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        DateTime currentDateTime = DateTime.Now;

        public void Calc() {

            //setting the proper format for each date and time
            dateTimePicker1.CustomFormat = ("MM/dd/yyyy HH");
            dateTimePicker2.CustomFormat = ("MM/dd/yyyy HH");
            dateTimePicker3.CustomFormat = "HH:MM:SS";
            dateTimePicker4.CustomFormat = "HH:MM:SS";

            //time for Time in section
            DateTime TimeInDate = (DateTime)dateTimePicker1.Value;

            //time for Time out section
            DateTime TimeOutDate = (DateTime)dateTimePicker2.Value;

     

            TimeSpan ts = TimeOutDate.Subtract(TimeInDate); // subtracting time in to time out to get the duration in hours


            
            string Days = ts.Days.ToString();
            int hrs = (Convert.ToInt32(Days));
            string Gp = "03:00:00";
            TimeSpan GracePeriod = TimeSpan.Parse(Gp);
            TimeSpan ts6 = dateTimePicker3.Value.Subtract(dateTimePicker4.Value);
            Double DURATION = ((TimeOutDate - TimeInDate) + ts6 - GracePeriod).TotalHours; //Duration with grace period deducted

            Double DURATIONS = ((TimeOutDate - TimeInDate) + ts6).TotalHours; //Total Duration


            

            int GracePayment = 50;
            int sccdhrs = 10;
            double VAT = .12;
            double newDur2 = Math.Round(DURATIONS);


            string timein = TimeInDate.ToString("MM/dd/yyyy") + " " + dateTimePicker4.Value.ToString("HH:mm:ss");
            string timeout = TimeOutDate.ToString("MM/dd/yyyy") + " " + dateTimePicker3.Value.ToString("HH:mm:ss");



            if (DURATION <= 0)
            {

                double  totalPayment = (GracePayment * VAT) + GracePayment;

               

                MessageBox.Show(" UNDERGRACE PERIOD");
                MessageBox.Show("TIME IN :" + timein +
                    "\n TIME OUT: " + timeout +
                     "\n DURATION: " + newDur2 + " Hours"
                    + "\n VAT SALE: " + totalPayment
                    + "\nVAT AMOUNT: " + (GracePayment * VAT)
                    + "\n TOTAL AMOUNT TO BE PAID: " + totalPayment
                    );

            } 

            else {

                int res = Convert.ToInt32(DURATION);

                double overGraced = (res * sccdhrs);
                double lastP = (overGraced + GracePayment);
                double VATSale = (lastP * VAT);
                double totalPayment2 = (lastP * VAT) + lastP;

                MessageBox.Show(" OVERGRACE PERIOD  ");

                MessageBox.Show("TIME IN :" + timein +
                    "\n TIME OUT: " + timeout +
                     "\n DURATION: " + newDur2 + " Hours"
                    + "\n VAT SALE: " + VATSale
                    + "\nVAT AMOUNT: " + lastP
                    + "\n TOTAL AMOUNT TO BE PAID: " + totalPayment2
                    );
  
                
            
            }
  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd,MM/dd/yyyy HH:mm:ss");


        }


        private void button3_Click(object sender, EventArgs e)
        {
            Calc();
        }
    }
}