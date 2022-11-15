using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nukleotydy1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[^ACTG]+");
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "txt files (.txt)|*.txt|All files (.)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    MatchCollection matches = regex.Matches(richTextBox1.Text);
                    if (matches.Count > 0)
                    {
                        MessageBox.Show("Błąd, wczystany plik zawiera nieobsługiwane znaki");
                        richTextBox1.Text = String.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> listString = new List<string>();
            List<Int16> listInt = new List<Int16>();
            Regex regex = new Regex(@"[^ACTG]+");
            MatchCollection matches = regex.Matches(richTextBox1.Text);
            if (matches.Count > 0)
            {
                MessageBox.Show("Błąd, wczystany plik zawiera nieobsługiwane znaki. Proszę naprawić plik i spróbować jeszcze raz");
                richTextBox1.Text = String.Empty;
            }
            else
            {
                string tmp = "";
                int z = 0;
                int y = 0;
                int k = 0;
                string sekwencja = richTextBox1.Text;
                for (int i = 0; i < ((sekwencja.Length) - 3); i++)
                {
                    z = i + 1;
                    y = i + 2;
                    k = i + 3;

                    tmp += sekwencja[i];
                    tmp += sekwencja[z];
                    tmp += sekwencja[y];
                    tmp += sekwencja[k];

                    if (listString.Contains(tmp))
                    {
                        int m = listString.IndexOf(tmp);
                        listInt[m] += 1;
                    }
                    else
                    {
                        listString.Add(tmp);
                        listInt.Add(1);
                    }

                    tmp = "";


                    listInt.Sort();

                }
                string result = "Sekwencja         Ilość\r\n";
                for (int i = 0; i < listInt.Count; i++)
                {
                    result += String.Format("{0}                 {1}\r\n", listString[i].ToString(), listInt[i].ToString());
                }
                richTextBox2.Text = result;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
