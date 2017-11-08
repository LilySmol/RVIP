using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace рвип22
{
    class Computer
    {
        public string task;
        public RichTextBox listServers;
        public RichTextBox result;
        public List<Server> listS = new List<Server>();
        public Computer(string task, RichTextBox listServers, int countS, int countP, RichTextBox result)
        {
            this.task = task;
            this.listServers = listServers;
            this.result = result;
            sendTask(countS, countP);
        }

        public void sendTask(int cS, int cP)
        {
            for (int i = 0; i < cS; i++)
            {
                listServers.Text += "Сервер " + (i + 1) + " необходимо получить " + cP + " параметров" + Environment.NewLine; 
            }
        }

        public void showResult() //вывести результат
        {
            //result.Invoke((MethodInvoker)(delegate () { result.Clear(); }));
            if (listS.Count != 0)
            {
                for (int i = 0; i < listS.Count; i++)
                {
                    if (listS[i].result.Count != 0)
                    {
                        for (int j = 0; j < listS[i].result.Count; j++)
                        {
                            result.Invoke((MethodInvoker)(delegate () { result.Text += listS[i].result[j] + Environment.NewLine; }));
                        }
                    }
                }
            }
        }
    }
}
