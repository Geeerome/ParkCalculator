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

            dateTimePicker1.CustomFormat = ("MM/dd/yyyy HH");
            dateTimePicker2.CustomFormat = ("MM/dd/yyyy HH");
            dateTimePicker3.CustomFormat = "HH:MM:SS";
            dateTimePicker4.CustomFormat = "HH:MM:SS";

            DateTime TimeInDate = (DateTime)dateTimePicker1.Value;
            DateTime TimeOutDate = (DateTime)dateTimePicker2.Value;

            TimeSpan ts = TimeOutDate.Subtract(TimeInDate);

           

            
            string Days = ts.Days.ToString();
            int hrs = (Convert.ToInt32(Days));
            string Gp = "03:00:00";
            TimeSpan GracePeriod = TimeSpan.Parse(Gp);
            TimeSpan ts6 = dateTimePicker3.Value.Subtract(dateTimePicker4.Value);
            Double DURATION = ((TimeOutDate - TimeInDate) + ts6 - GracePeriod).TotalHours;
            Double DURATIONS = ((TimeOutDate - TimeInDate) + ts6).TotalHours;
            

            

            int GracePayment = 50;
            int sccdhrs = 10;
            double VAT = .12;

           
            if (DURATION <= 0)
            {

                double  totalPayment = (GracePayment * VAT) + GracePayment;
                MessageBox.Show(" UNDERGRACE PERIOD");
                MessageBox.Show("TIME IN :" +TimeInDate+
                    "\n TIME OUT: " + TimeOutDate +
                     "\n DURATION: " + DURATIONS + " Hours"
                    + "\n VAT SALE: " + totalPayment
                    + "\nVAT AMOUNT: " + (GracePayment * VAT)
                    + "\n TOTAL AMOUNT TO BE PAID: " + totalPayment
                    );

            } //change

            else {
                double totalPayment = (GracePayment * VAT) + GracePayment;
                int res = Convert.ToInt32(DURATION);
                double totalPayment2 = (GracePayment * VAT) + GracePayment;
                double overGraced = (res * sccdhrs);
                double lastP = (overGraced + totalPayment2);
                MessageBox.Show(" OVERGRACE PERIOD  ");

                MessageBox.Show("TIME IN :" + TimeInDate +
                    "\n TIME OUT: " + TimeOutDate +
                     "\n DURATION: " + DURATIONS + " Hours"
                    + "\n VAT SALE: " + totalPayment
                    + "\nVAT AMOUNT: " + (GracePayment * VAT)
                    + "\n TOTAL AMOUNT TO BE PAID: " + lastP
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