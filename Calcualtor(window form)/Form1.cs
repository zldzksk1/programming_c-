using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcWinForm
{
    public partial class Form1 : Form
    {
        bool cal = false;
        bool decimalCheck = false;
        bool afterCal = false;

        public Form1()
        {
            InitializeComponent();

        }

        private void editEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void engToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void empty(object sender, EventArgs e)
        {

        }

        private void squareRoot(object sender, EventArgs e)
        {
            int sRoot = int.Parse(label1.Text);
            label1.Text = Math.Sqrt(sRoot).ToString();
            decimalCheck = false;
            cal = true;
            afterCal = true;
        }

        private void makeDecimal(object sender, EventArgs e)
        {
            if (!decimalCheck)
            {
                label1.Text += ".";
                decimalCheck = true;
            }
        }

        private void deleteNum(object sender, EventArgs e)
        {
            int num = label1.Text.Length;
            if (num <= 1)
            {
                label1.Text = "0";
            }
            else
                label1.Text = label1.Text.Substring(0, num - 1);
        }

        private void ClearAll(object sender, EventArgs e)
        {
            label2.Text = "";
            label1.Text = "0";
            decimalCheck = false;
        }

        private void ClearEnter(object sender, EventArgs e)
        {
            label1.Text = " ";
            decimalCheck = false;
        }


        private void dividedByx(object sender, EventArgs e)
        {
            label2.Text = "1/" + label1.Text;
            int x = Int32.Parse(label1.Text);
            float res = 1F / x;
            label1.Text = res.ToString();
            cal = true;
        }

        private void getNum(object sender, EventArgs e)
        {
            if (label1.Text == "0")
            {
                label1.Text = "";
            }

            if (cal && afterCal)
            {
                label1.Text = "";
                label2.Text = "";
                cal = false;
            }


            //((Button)sender).Text;

            label1.Text += ((Button)sender).Text;
        }


        private void getAction(object sender, EventArgs e)
        {
            if (afterCal)
            {
                label2.Text = label1.Text + ((Button)sender).Text;
                label1.Text = " ";
                afterCal = false;
            }
            else 
            {
                label2.Text = label2.Text + label1.Text + ((Button)sender).Text;
                label1.Text = "0";
            }
        }

        private void getAnswer(object sender, EventArgs e)
        {
            label2.Text = label2.Text + label1.Text;

            Calc();
        }

        public void Calc() {
            DataTable dt = new DataTable();
            var v = dt.Compute(label2.Text, "").ToString();
            label1.Text = v;
            decimalCheck = false;
            cal = true;
            afterCal = true;
        }
    }
}
