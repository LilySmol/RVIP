using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace рвип22
{
    class Server
    {
        public int id;
        public int countParametrs;
        public RichTextBox conStatus;
        public List<string> result = new List<string>();
        Random random = new Random();

        public Server(RichTextBox r, int id, int countParametrs)
        {
            this.id = id;
            this.countParametrs = countParametrs;
            this.conStatus = r;
            connection();
        }

        public void connection() //подключение и расчет параметров
        {
            Thread.Sleep(500);          
            conStatus.Invoke((MethodInvoker)(delegate () { conStatus.Text += "Успешное подключение к серверу " + id + Environment.NewLine; }));
            Thread.Sleep(50);
            for (int i = 0; i < countParametrs; i++) //расчет параметров
            {
                result.Add("Сервер " + id + "; Параметр " + (i + 1) + ": " + random.Next(10, 100) + "%" + Environment.NewLine);
            }           
        }
    }
}
