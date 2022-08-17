using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Events
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        public void FillForm()
        {
            Fillcities();
        }

        public void Fillcities()
        {
            listBox1.Items.Add("İstanbul");
            listBox1.Items.Add("Ankara");
            listBox1.Items.Add("İzmir");
            listBox1.Items.Add("Ardahan");
            listBox1.Items.Add("Edirne");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listbox da seçili bir item var mı?
            if (listBox1.SelectedIndex>-1)
            {
                string item = listBox1.SelectedItem.ToString();
                listBox2.Items.Add(item);
                listBox1.Items.Remove(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex>-1)
            {
                string item = listBox2.SelectedItem.ToString();
                listBox1.Items.Add(item);
                listBox2.Items.Remove(item);
            }
        }
    }
}
