using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr2modul
{
    public partial class Form3 : Form
    {
        Form1 form1;
        public Form3(Form1 owner)
        {
            form1 = owner;
            InitializeComponent();
        }


        string path = "C:\\Users\\d-bel\\Desktop\\1.txt";
        void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string num = form1.textBox2.Text;
                string[] c = form1.textBox1.Text.Split(' ');
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == num)
                    {
                        form1.textBox3.Text = $"Числу {num} принадлежит индекс {i}";
                        i++;
                    }

                }
                bool s = form1.textBox1.Text.Contains(num);
                if (s == false)
                {
                    form1.textBox3.Text ="Такого элемента нет!";
                }
                string str = form1.textBox1.Text + Environment.NewLine + form1.textBox3.Text;
                File.WriteAllText(path, str);
            }
            catch (Exception)
            {

                MessageBox.Show("неверный формат");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int findthis = Convert.ToInt32(form1.textBox2.Text);
                bool bl = form1.textBox1.Text.Contains(findthis.ToString());
                if (bl == false)
                {
                    form1.textBox3.Text = "Такого элемента нет!";
                }
                else
                {
                    string s = form1.textBox1.Text;
                    string[] chars = s.Split(' ');
                    int[] b = Array.ConvertAll(chars, int.Parse);
                    int index;
                    int curnumber;
                    for (int i = 0; i < b.Length; i++)
                    {
                        index = i;
                        curnumber = (b[i]);
                        while (index > 0 && curnumber < b[index - 1])
                        {
                            b[index] = b[index - 1];
                            index--;
                        }
                        b[index] = curnumber;
                    }
                    form1.textBox1.Text = String.Join(" ", b);
                    int lev = 0;
                    int prav = b.Length - 1;
                    int centr = 0;
                    while (b[centr] != findthis)
                    {
                        centr = (lev + prav) / 2;
                        if (findthis < b[centr])
                        {
                            prav = centr - 1;
                        }
                        else if (findthis > b[centr])
                        {
                            lev = centr + 1;
                        }

                    }

                    form1.textBox3.Text = $"Числу {findthis} принадлежит индекс {centr}";
                    
                }
                string str = form1.textBox1.Text + Environment.NewLine + form1.textBox3.Text;
                File.WriteAllText(path, str);
            }
            catch (Exception)
            {

                MessageBox.Show("неверный формат");
            }
        }
    }
}
