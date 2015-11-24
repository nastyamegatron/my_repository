using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;


namespace Kurs_step_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread myThread;
        Thread test;


        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern Int16 GetKeyState(Keys keys);


        private void button1_Click(object sender, EventArgs e)
        {
            test = new Thread(Test);
            test.Start();
        }
        public void Test()
        {
            for (int n = 0; n <= 2; n++)
            {
                try { myThread.Abort(); }
                catch { };
                label2.Invoke((ThreadStart)delegate()
                {
                    label2.Text = 0.ToString();
                });
                label4.Invoke((ThreadStart)delegate()
                {
                    label4.Text = 0.ToString();
                });
                label6.Invoke((ThreadStart)delegate()
                {
                    label6.Text = 0.ToString();
                });
                label8.Invoke((ThreadStart)delegate()
                {
                    label8.Text = 0.ToString();
                });
                
                myThread = new Thread(Schet);
                myThread.Start();
                Thread.Sleep(10000);
                listBox1.Invoke((ThreadStart)delegate()
                {
                    listBox1.Items.Add("Количество нажатий на клавиши вверх вниз" + label2.Text);
                });
                listBox1.Invoke((ThreadStart)delegate()
                {
                    listBox1.Items.Add("Количество нажатий на клавиши букв цифр" + label4.Text);
                });
                listBox1.Invoke((ThreadStart)delegate()
                {
                    listBox1.Items.Add("Количество нажатий на мышь" + label6.Text);
                });
                listBox1.Invoke((ThreadStart)delegate()
                {
                    listBox1.Items.Add("Количество нажатий на скролл" + label8.Text);
                });
                listBox1.Invoke((ThreadStart)delegate()
                {
                    listBox1.Items.Add("");
                });
                
            }
            myThread.Abort();
            test.Abort();
            
        }
        public void Schet()
        {

            

            IntPtr DialogHandle = FindWindow("Chrome_WidgetWin_1", "Яндекс - Google Chrome");
            if (DialogHandle == IntPtr.Zero)
            {
                MessageBox.Show("Application is not running.");
                return;
            }
            while (true)
            {
                IntPtr selectedWindow = GetForegroundWindow();
                if (selectedWindow == DialogHandle)
                {
                  
                    if ((GetKeyState(Keys.Down) & 256) == 256 || (GetKeyState(Keys.Up) & 256) == 256)
                    {
                        label2.Invoke((ThreadStart)delegate()
                        {
                            label2.Text = (Int32.Parse(label2.Text) + 1).ToString();
                            //listBox1.Items.Add("Количество нажатий на клавиши вверх вниз" + label2.Text);
                            Thread.Sleep(150);
                        });
                        

                    }
                    if ((GetKeyState(Keys.A) & 256) == 256 || (GetKeyState(Keys.B) & 256) == 256 || (GetKeyState(Keys.C) & 256) == 256
                        || (GetKeyState(Keys.D) & 256) == 256 || (GetKeyState(Keys.E) & 256) == 256 || (GetKeyState(Keys.F) & 256) == 256
                        || (GetKeyState(Keys.G) & 256) == 256 || (GetKeyState(Keys.H) & 256) == 256 || (GetKeyState(Keys.I) & 256) == 256
                        || (GetKeyState(Keys.J) & 256) == 256 || (GetKeyState(Keys.K) & 256) == 256 || (GetKeyState(Keys.L) & 256) == 256
                        || (GetKeyState(Keys.M) & 256) == 256 || (GetKeyState(Keys.N) & 256) == 256 || (GetKeyState(Keys.O) & 256) == 256
                        || (GetKeyState(Keys.P) & 256) == 256 || (GetKeyState(Keys.Q) & 256) == 256 || (GetKeyState(Keys.R) & 256) == 256
                        || (GetKeyState(Keys.S) & 256) == 256 || (GetKeyState(Keys.T) & 256) == 256 || (GetKeyState(Keys.U) & 256) == 256
                        || (GetKeyState(Keys.V) & 256) == 256 || (GetKeyState(Keys.W) & 256) == 256 || (GetKeyState(Keys.X) & 256) == 256
                        || (GetKeyState(Keys.Y) & 256) == 256 || (GetKeyState(Keys.Z) & 256) == 256 || (GetKeyState(Keys.D0) & 256) == 256 
                        || (GetKeyState(Keys.D1) & 256) == 256|| (GetKeyState(Keys.D2) & 256) == 256|| (GetKeyState(Keys.D3) & 256) == 256 
                        || (GetKeyState(Keys.D4) & 256) == 256|| (GetKeyState(Keys.D5) & 256) == 256|| (GetKeyState(Keys.D6) & 256) == 256
                        || (GetKeyState(Keys.D7) & 256) == 256|| (GetKeyState(Keys.D8) & 256) == 256|| (GetKeyState(Keys.D9) & 256) == 256)
                    {
                        label4.Invoke((ThreadStart)delegate()
                        {
                            label4.Text = (Int32.Parse(label4.Text) + 1).ToString();
                            //listBox1.Items.Add("Количество нажатий на клавиши букв цифр" + label4.Text);
                            Thread.Sleep(150);
                        });
                        
                        
                    }
                    if ((GetKeyState(Keys.LButton) & 256) == 256 || (GetKeyState(Keys.RButton) & 256) == 256)
                    {
                        label6.Invoke((ThreadStart)delegate()
                        {
                            label6.Text = (Int32.Parse(label6.Text) + 1).ToString();
                            //listBox1.Items.Add("Количество нажатий на мышь" + label6.Text);
                            Thread.Sleep(150);
                        });


                    }
                    if ((GetKeyState(Keys.MButton) & 256) == 256 || (GetKeyState(Keys.PageUp) & 256) == 256 || (GetKeyState(Keys.PageDown) & 256) == 256)
                    {
                        label8.Invoke((ThreadStart)delegate()
                        {
                            label8.Text = (Int32.Parse(label8.Text) + 1).ToString();
                            //listBox1.Items.Add("Количество нажатий на скролл" + label8.Text);
                            Thread.Sleep(150);
                        });
                    

                    }

                   
                } 
            } 
        }
    }
}