using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StackAndQueue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stack stack=new Stack();
            //LIFO lasn in first out
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            //foreach (var item in stack)
            //{
            //    listBox1.Items.Add(item);
            //}


            var item = stack.Pop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //fifo : first in first out

            Queue queue=new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);


            //foreach (var item in queue)
            //{
            //    listBox1.Items.Add(item);
            //}

           var item= queue.Dequeue();
        }
    }
}
