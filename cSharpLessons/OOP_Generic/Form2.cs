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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool IsEqual = GenericCalculatoor.AreEqual<int, int>(10, 20);
            bool IsEqual2 = GenericCalculatoor.AreEqual<string, int>("Yaren", 20);
            bool IsEqual3 = GenericCalculatoor.AreEqual<double, int>(10.0, 20);


            //bool IsEqual = Calculator.AreEqual(10, 10);

            //if (IsEqual)
            //{
            //    MessageBox.Show("İki değer birbirine eşittir. Hesaplama yapılamaz");
            //}
            //else
            //{
            //    MessageBox.Show("İki değer birbirine eşit değildir.");
            //}
        }
    }

    public class Calculator
    {
        public static bool AreEqual(int value1, int value2)
        {
            return value1 == value2;
        }
    }


    public class GenericCalculatoor
    {

        public static bool AreEqual<T, T1>(T value1, T1 value2)
        {
            return value1.Equals(value2);
        }
    }

    public class GenerizCalculatorProperty<T>
    {
        //Generic Property
        public T MyProperty { get; set; }
    }


}
