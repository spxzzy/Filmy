using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OdczytZPliku();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void DodawanieDanych(string tytul, string rezyser, string data, string aktor)
        {
            ListViewItem item = new ListViewItem(new string[] { tytul, rezyser, data, aktor });
            listView1.Items.Add(item);
        }
        private void DodawanieDanych(string[] dane)
        {
            ListViewItem item = new ListViewItem(dane);
            listView1.Items.Add(item);
        }

        private void UsuwanieDanych()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        }

        private string[] WierszeDoPliku()
        {
            string[] linie = new string[listView1.Items.Count];
            int i = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                linie[i] = "";
                for (int k = 0; k < item.SubItems.Count; k++)
                    linie[i] += item.SubItems[k].Text + "*";
                i++;
            }
            return linie;


        }
        
        private void OdczytZPliku()
        {

            if (!File.Exists("filmy.txt"))
                return;

            string[] linie = File.ReadAllLines("filmy.txt");
            foreach(string linia in linie)
            {
                string[] temp = linia.Split('*');
                DodawanieDanych(temp);
            }
            
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodawanieDanych(textBox1.Text, textBox3.Text, dateTimePicker1.Text, textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void usuńWybraneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuwanieDanych();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] linie = WierszeDoPliku();
            File.WriteAllLines("filmy.txt", linie);
            
        }
    }
    
}

