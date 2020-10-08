using System;
using System.Threading;
using System.Windows.Forms;

namespace ThreadsTest4
{
    public partial class Form1 : Form
    {
        Thread[] thread = new Thread[3];
        public void addCount()
        {
            for (int i = 0; i < 100; i++)
            {
                Invoke((MethodInvoker)delegate () { textBox1.Text += "1"; });

                Thread.Sleep(500);
            }
        }

        public void progress()
        {
            for (int i = 0; i < 100; i++)
            {
                Invoke((MethodInvoker)delegate () { progressBar1.Value = i; });
                Thread.Sleep(100);
            }
        }
        public void addCount2()
        {
            for (int i = 0; i < 100; i++)
            {
                Invoke((MethodInvoker)delegate () 
                { 
                    textBox2.Text += "2"; 
                });

                Thread.Sleep(500);
            }
        }

        public Form1()
        {


            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            thread[0] = new Thread(addCount);
            thread[0].Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread[1] = new Thread(addCount2);
            thread[1].Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            thread[2] = new Thread(progress);
            thread[2].Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Thread item in thread)
            {
                item.Abort();
            }
            
        }
    }  
}
