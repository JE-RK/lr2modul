using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace lr2modul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = "C:\\Users\\d-bel\\Desktop\\1.txt";
        private void button1_Click(object sender, EventArgs e)
        {         
            FileStream f = new FileStream(path, FileMode.Open);
            StreamReader r = new StreamReader(f);
            textBox1.Text = r.ReadLine();
            r.Close();
            f.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int[] a = new int[10];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = random.Next(-10, 11);
            }
            textBox1.Text = String.Join(" ", a);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Opred(string s, bool b)
        {
            try
            {
                string[] c = textBox1.Text.Split(' ');
                int[] num = Array.ConvertAll(c, int.Parse);
                int min = num[0];
                int index = 0;

                for (int i = 0; i < num.Length; i++)
                {
                    if (num[i] < min && b)
                    {
                        min = num[i];
                        index = i;
                    }

                    if (num[i] > min && b == false)
                    {
                        min = num[i];
                        index = i;
                    }
                }
                textBox3.Text = $"{s} число массива находится в {index + 1} позиции и равно {min}";
            }
            catch (Exception)
            {
                MessageBox.Show("неверный формат");
            }
           
        }
        private void button5_Click(object sender, EventArgs e)
        {

            Opred("Минимальное", true);
            string str = textBox1.Text + Environment.NewLine + textBox3.Text;
            File.WriteAllText(path, str);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Opred("Максимальное", false);
            string str = textBox1.Text + Environment.NewLine + textBox3.Text;
            File.WriteAllText(path, str);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "")
            {
                new Form3(this).Show();
            }
            else
            {
                textBox2.Text = "";
            }
            

        }
    }
}
