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
            _hookID = SetHook(_proc);
            InitializeComponent();
        }
        Thread myThread;
        Thread test;
        static string browser;

        public static int wheel;

        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private const int WH_MOUSE_LL = 14;

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {

            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback (int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_MOUSEWHEEL == (MouseMessages)wParam)
            {
                int PID;
                Process[] processes = Process.GetProcessesByName(browser);
                IntPtr selectedWindow = GetForegroundWindow();
                GetWindowThreadProcessId(GetForegroundWindow(), out PID);
                if (processes.Where(x => x.Id == PID).Count() > 0)
                {
                  wheel++;
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private enum MouseMessages
        {
            WM_MOUSEWHEEL = 0x020A,
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern Int16 GetKeyState(Keys keys);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Opera") browser = "opera";
            if (comboBox1.Text == "GoogleChrome") browser = "chrome";
            if (comboBox1.Text == "MozilaFirefox") browser = "mozila";
            if (comboBox1.Text == "InternetExplorer") browser = "iexplore";
            if (comboBox1.Text == "Yandex browser") browser = "browser";

            test = new Thread(Test);
            test.Start();
        }
        public void Test()
        {
            for (int n = 1; n <= 50; n++)
            {
                try { myThread.Abort(); }
                catch { };
                wheel = 0;
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
                label10.Invoke((ThreadStart)delegate ()
                {
                    label10.Text = n.ToString();
                });

                myThread = new Thread(Schet);
                myThread.Start();
                Thread.Sleep(60000);
                listBox1.Invoke((ThreadStart)delegate ()
                {
                    listBox1.Items.Add("Отчет за " + label10.Text + " минуту");
                });
                listBox1.Invoke((ThreadStart)delegate()
                {
                    listBox1.Items.Add("Количество нажатий на клавиши вверх вниз: " + label2.Text);
                });
                listBox1.Invoke((ThreadStart)delegate()
                {
                    listBox1.Items.Add("Количество нажатий на клавиши букв цифр: " + label4.Text);
                });
                listBox1.Invoke((ThreadStart)delegate()
                {
                    listBox1.Items.Add("Количество нажатий на мышь: " + label6.Text);
                });
                listBox1.Invoke((ThreadStart)delegate()
                {
                    listBox1.Items.Add("Количество нажатий на скролл: " + label8.Text);
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
            Process[] processes = Process.GetProcessesByName(browser);
            if (processes.Count() == 0)
            {
                MessageBox.Show("Application is not running");
                myThread.Abort();
            }
            while (true)
            {
                int PID;
                processes = Process.GetProcessesByName(browser);
                IntPtr selectedWindow = GetForegroundWindow();
                GetWindowThreadProcessId(GetForegroundWindow(), out PID);
                if (processes.Where(x => x.Id == PID).Count() > 0 )
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
                    if ((GetKeyState(Keys.LButton) & 256) == 256 || (GetKeyState(Keys.RButton) & 256) == 256 || (GetKeyState(Keys.MButton) & 256) == 256)
                    {
                        label6.Invoke((ThreadStart)delegate()
                        {
                            label6.Text = (Int32.Parse(label6.Text) + 1).ToString();
                            //listBox1.Items.Add("Количество нажатий на мышь" + label6.Text);
                            Thread.Sleep(200);
                        });
                    }

                    label8.Invoke((ThreadStart)delegate ()
                    {
                        label8.Text = wheel.ToString();
                        //listBox1.Items.Add("Количество скроллов" + label6.Text);
                    });

                } 
            } 
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
        }
    }
}