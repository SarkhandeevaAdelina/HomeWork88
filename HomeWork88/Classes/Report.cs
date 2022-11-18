using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork88.Classes
{
    internal class Report
    {
        /// <summary>
        /// Описание отчета
        /// </summary>
        private string text;
        /// <summary>
        /// Время выполнения
        /// </summary>
        private DateTime time;
        /// <summary>
        /// Объект класса работник
        /// </summary>
        private Employee worker;
        /// <summary>
        /// Создание отчета работника worker с описанием text
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="text"></param>
        public Report(Employee worker, string text)
        {
            this.worker = worker;
            this.text = text;
        }
        /// <summary>
        /// Метод ссоздание отчета
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public static Report CreateNewReport(Employee worker)
        {
            Console.WriteLine("Введите описание отчета");
            string text = Console.ReadLine();
            Task.SendOnCheck(worker);
            return new Report(worker, text);
        }
        public void PrintInfoReport()
        {
            Console.WriteLine($"{text}");
        }
    }
}
