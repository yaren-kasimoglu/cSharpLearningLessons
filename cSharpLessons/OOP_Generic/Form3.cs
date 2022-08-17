using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Generic
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenericList<GenericCalculatoor> list = new GenericList<GenericCalculatoor>();
            list.Add(new GenericCalculatoor() { });
         
          
        }
    }



    public class GenericList<T> where T : class, new()// T sadece class olabilsin ve new lenebilsin constrait: kısıtlama

        // public class GenericList<T> where T : struct //eğer buraya struct yazarsak null değer alamayan yapı çağır demiş oluyoruz struct olursa boş değer alamaz
    {

        List<T> list;

        public GenericList()
        {
            list = new List<T>();
             //burda new lememizin sebebi bu class ı çağırdığım anda new lemesini isteediğim için. eğer b unu yukarda yapsaydık ne zaman new leneceğiniz bilemezdik
        }

        public void Add(T item)
        {
            list.Add(item);
        }

    }
}
