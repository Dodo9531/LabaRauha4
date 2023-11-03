using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNS4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd_init = new Random();

            double[] pi = new double[16];
            Boolean[] pib = new Boolean[16];
            List<Random> randoms = new List<Random>();


            double[] pblock = new double[4];
            Boolean[] pblockb = new Boolean[4];

            double P;
            Boolean PB = new Boolean();

            int count = 0; // Счетчик частот
            int N = 0; // Число испытаний

                //Блок 1
                pi[0] = Convert.ToDouble(textBox1.Text);
                pi[1] = Convert.ToDouble(textBox2.Text);
                pi[2] = Convert.ToDouble(textBox3.Text);
                pi[3] = Convert.ToDouble(textBox4.Text);

                //Блок 2
                pi[4] = Convert.ToDouble(textBox5.Text);
                pi[5] = Convert.ToDouble(textBox6.Text);
                pi[6] = Convert.ToDouble(textBox7.Text);
                pi[7] = Convert.ToDouble(textBox8.Text);

                //Блок 3
                pi[8] = Convert.ToDouble(textBox9.Text);
                pi[9] = Convert.ToDouble(textBox10.Text);
                pi[10] = Convert.ToDouble(textBox11.Text);
                pi[11] = Convert.ToDouble(textBox12.Text);

                //Блок 4
                pi[12] = Convert.ToDouble(textBox13.Text);
                pi[13] = Convert.ToDouble(textBox14.Text);
                pi[14] = Convert.ToDouble(textBox15.Text);
                pi[15] = Convert.ToDouble(textBox16.Text);

                N = Convert.ToInt32(textBox17.Text);
            
           

            for (int i = 0; i < 16; i++) 
            {
                randoms.Add(new Random(rnd_init.Next()));
            }

            //Расчет вероятности по блокам
            pblock[0] = 1 - (1 - pi[0] * pi[1]) * (1 - pi[2] * pi[3]);
            pblock[1] = (1 - (1 - pi[4]) * (1 - pi[5] * pi[6])) * pi[7];
            pblock[2] = 1 - (1 - pi[8]) * (1 - pi[9] * (1 - (1 - pi[10]) * (1 - pi[11])));
            pblock[3] = 1 - (1 - pi[12]) * (1 - pi[13]) * (1 - pi[14] * pi[15]);

            P =  (1-(1 - pblock[0]) * (1 - pblock[1]) * (1 - pblock[2])) * pblock[3];

            textBox18.Text = P.ToString();



            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (randoms[j].NextDouble() <= pi[j])
                        pib[j] = true;
                    else
                        pib[j] = false;
                }


                pblockb[0] = (pib[0] && pib[1]) || (pib[2] && pib[3]);
                pblockb[1] = (pib[4] || (pib[5] && pib[6])) && pib[7];
                pblockb[2] = pib[8] || (pib[9] && (pib[10] || pib[11]));
                pblockb[3] = pib[12] || pib[13] || (pib[14] && pib[15]);



                PB = (pblockb[0] || pblockb[1] || pblockb[2]) && pblockb[3];

                if (PB)
                    count++;
            }

            textBox19.Text = ((double)count / N).ToString();
        }
    }
}
