using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace рвип22
{
    public partial class Form1 : Form
    {
        int countServers = 0;
        Random random = new Random();
        System.Timers.Timer timer = new System.Timers.Timer();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //старт
        {
            int countParametrs = random.Next(3, 5);
            int countServersTemp = 0;
            List<Thread> listThread = new List<Thread>();
            countServers = Convert.ToInt32(textBox1.Text);  
            Computer computer = new Computer("Посчитать загруженность " + countParametrs + " параметров" + Environment.NewLine + Environment.NewLine, richTextBox2, countServers, countParametrs, richTextBox3);
            richTextBox1.Text += computer.task;            
            timer.Elapsed += (s, ev) =>
            {
               Thread t = new Thread(delegate ()
                {
                    Server ser = new Server(richTextBox1, countServersTemp, countParametrs);
                    computer.listS.Add(ser);
                    //computer.showResult();
                });
                t.Start();
                listThread.Add(t); //добавить поток в список
                                    
                countServersTemp++;
                if (countServersTemp == countServers)
                {
                    timer.Stop();
                    //computer.showResult(listS);
                    for (int i = 0; i < listThread.Count; i++)
                    {
                        if (listThread[i].IsAlive)
                        {
                            listThread[i].Join();
                            computer.showResult();
                        }                        
                    }
                    
                }
            };
            timer.Interval = 1; 
            timer.Start(); 
        }
    }
}
