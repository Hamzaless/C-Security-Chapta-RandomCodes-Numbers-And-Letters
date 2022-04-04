using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace Security_Chapta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;

            Random rastgele = new Random();
            Random rastgelesayi = new Random();
            for (int i = 0; i < 20; i++)
            {
                
                string harfler = "ABCDEFGHIJKLMNOPRSTUVYZabcdefghIijklmnoprstuvyz";
                string uret = "";
                for (int a= 0; a < 3; a++)
                {
                    uret += harfler[rastgele.Next(harfler.Length)];
                }
                int sayi = rastgele.Next(1, 50);
               
                label1.Text = sayi.ToString();

                int sayi2 = rastgele.Next(1, 50);
                label1.Text = sayi.ToString() + sayi2.ToString() ;

                int sayi3 = rastgele.Next(1, 50);
                label1.Text = sayi.ToString() + sayi2.ToString()+sayi3.ToString();
                int sayi4 = rastgele.Next(1, 50);
                label1.Text = sayi.ToString() + sayi2.ToString() + sayi3.ToString() + sayi4.ToString() ;
                int sayi5 = rastgele.Next(1, 50);
                label1.Text = sayi.ToString() +uret+ sayi2.ToString() + sayi3.ToString() + sayi4.ToString() +uret+ sayi5.ToString();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (textBox1.Text==label1.Text)
            {
                Application.Exit();
                
            }
           else
            {
                MessageBox.Show("Enter Chapta Code or You Can't Exit", "Chapta Closing Error");
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            
        if (textBox1.Text == label1.Text)
            {

            }
        else
            {
                foreach (Process proc in Process.GetProcessesByName("taskmgr"))
                {
                    proc.Kill();
                    MessageBox.Show("You can't do this without going past the chapta: Task Manager Blocker", proc.ProcessName);
                }
                foreach (Process proc2 in Process.GetProcessesByName("cmd"))
                {
                    proc2.Kill();
                    MessageBox.Show("You can't do this without going past the chapta: Command Prompt Blocker", proc.ProcessName);
                }
            }
           

        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox1.Text = label1.Text;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(3);
            if (progressBar1.Value == 300)
            {
                if (textBox1.Text == label1.Text)
                {
                    timer2.Stop();
                    MessageBox.Show("Chapta Passed", "Chapta");
                    Application.Exit();
                }
                else
                {
                    timer2.Stop();
                    MessageBox.Show("Chapta Code Incorrect", "Chapta Error"); 
                    progressBar1.Value = 0;
                }
            }
        }
    }
}
