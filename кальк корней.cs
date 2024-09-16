using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace калькулятор_корней
{
    public partial class Form1 : Form
    {
        public string D, last;
        bool fl = false;
        double res = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fl)
            {
                richTextBox1.Text = "0";
                fl = false;
            }
            Button B = (Button)sender;
            if (richTextBox1.Text == "0")
                richTextBox1.Text = B.Text;
            else richTextBox1.Text += B.Text;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            double n1, n2, res;
            string im;
            bool f1, f2;
            res = 0;
            f1 = Double.TryParse(last, out n1);
            if (!richTextBox1.Text.Contains("i"))
            {
                n2 = Convert.ToDouble(richTextBox1.Text);
                if (f1)
                {
                    if (D == "+")
                        res = n1 + n2;
                    else if (D == "-")
                        res = n1 - n2;
                    else if (D == "х")
                        res = n1 * n2;
                    else if (D == "/")
                        res = n1 / n2;
                    D = "=";
                    fl = true;
                    richTextBox1.Text = Convert.ToString(res);
                }
                else
                {
                    D = "=";
                    fl = true;
                    richTextBox1.Text = "ERROR";
                }
            
            }
            else
            {
                im = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
                f2 = Double.TryParse(im, out n2);
                if (f1 && f2)
                {
                    if (D == "+")
                    {
                        richTextBox1.Text = $"{n1}+{n2}i";
                    }
                    else if (D == "-")
                    {
                        richTextBox1.Text = $"{n1}-{n2}i";
                    }
                    else richTextBox1.Text = "Invalid operation";
                    D = "=";
                    fl = true;
                }

            }
                
        }

        private void button22_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "0";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
            if (richTextBox1.Text == "")
                richTextBox1.Text = "0";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double dn, res, im, re, arg, cs, sn;
            bool f1;
            if (!richTextBox1.Text.Contains("i"))
            {
                f1 = Double.TryParse(richTextBox1.Text, out dn);
                if (f1)
                {
                    if (dn < 0)
                        richTextBox1.Text = "ERROR";
                    else if (dn > 0)
                    {
                        res = Math.Sqrt(dn);
                        richTextBox1.Text = $"{res}/-{res}";
                    }
                    else if (dn == 0)
                        richTextBox1.Text = "0";
                }
                else richTextBox1.Text = "ERROR";
            }
            else
            {
                double k = 0;
                double res1, res2, res3, res4;
                string[] r = new string[2];
                if (richTextBox1.Text.Contains("+") )
                {
                    string[] imre = richTextBox1.Text.Split('+');
                    re = Convert.ToDouble(imre[0]);
                    im = Convert.ToDouble(imre[1].Substring(0, imre.Length -1));
                    arg =  Math.Sqrt(Math.Pow(re, 2)+ Math.Pow(im, 2));
                    cs = re / arg;
                    sn = im / arg;
                    //sn = Math.Asin(sn);
                    //cs = Math.Acos(cs);
                    res1 = Math.Sqrt(arg) * Math.Cos(Math.Asin(sn) / 2);
                    res2 = Math.Sqrt(arg) * Math.Sin(Math.Asin(sn) / 2);
                    if (res2<0)
                        r[0] = Convert.ToString(res1) + Convert.ToString(res2) + "i";
                    else r[0] = Convert.ToString(res1) + "+" + Convert.ToString(res2) + "i";
                    res3 = Math.Sqrt(arg) * Math.Cos((Math.Asin(sn) + 2*Math.PI)/ 2);
                    res4 = Math.Sqrt(arg) * Math.Sin((Math.Asin(sn) + 2 * Math.PI) / 2);
                    if (res4 < 0)
                        r[1] = Convert.ToString(res3) + Convert.ToString(res4) + "i";
                    else r[1] = Convert.ToString(res3) + "+" + Convert.ToString(res4) + "i";
                    richTextBox1.Text = "1) "+r[0] + " 2) " +r[1];
                    

                }
                else if (richTextBox1.Text.Contains("-"))
                {
                    
                    if (richTextBox1.Text.IndexOf("-") != 0)
                    {
                        string[] imre = richTextBox1.Text.Split('-');
                        re = Convert.ToDouble(imre[0]);
                        im =  - Convert.ToDouble(imre[1].Substring(0, imre.Length - 1));
                        arg = Math.Sqrt(Math.Pow(re, 2) + Math.Pow(im, 2));
                        cs = re / arg;
                        sn = im / arg;
                        sn = Math.Asin(sn);
                        cs = Math.Acos(cs);
                        res1 = Math.Sqrt(arg) * Math.Cos(cs / 2);
                        res2 = Math.Sqrt(arg) * Math.Sin(sn / 2);
                        if (res2<0)
                            r[0] = Convert.ToString(res1) + Convert.ToString(res2) + "i";
                        else r[1] = Convert.ToString(res1) + "+" + Convert.ToString(res2) + "i";
                        res3 = Math.Sqrt(arg) * Math.Cos((cs + 2 * Math.PI) / 2);
                        res4 = Math.Sqrt(arg) * Math.Sin((sn + 2 * Math.PI) / 2);
                        if (res4<0)
                            r[1] = Convert.ToString(res3) + Convert.ToString(res4) + "i";
                        else r[1] = Convert.ToString(res3) + "+" + Convert.ToString(res4) + "i";
                        richTextBox1.Text = "1) " + r[0] + " 2) " + r[1];
                    }
                    else
                    {
                        
                    }
                    
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double res, dn;
            bool f1;
            f1 = Double.TryParse(richTextBox1.Text, out dn);
            if (f1) 
            { 
                res = -dn;
                richTextBox1.Text = Convert.ToString(res);
            }
            else
            {
                richTextBox1.Text = "ERROR";
            }
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (fl)
            {
                richTextBox1.Text = "0";
                fl = false;
            }
            Button B = (Button)sender;
            if (richTextBox1.Text == "0")
                richTextBox1.Text = B.Text;
            else richTextBox1.Text += B.Text;

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            D = B.Text;
            last = richTextBox1.Text;
            fl = true;
        }
    }
}
