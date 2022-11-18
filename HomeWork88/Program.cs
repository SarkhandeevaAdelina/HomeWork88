using HomeWork88.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = HomeWork88.Classes.Task;

namespace HomeWork88
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("КФУ");
            DateTime deadline = DateTime.Now.AddDays(7);

            TeamLead teamlead = new TeamLead("Екатерина", "Фадеева");
            int countOfEmployees = 10;
            Project project = new Project("Обучить студентов программированию", deadline, teamlead, customer);

            List<Employee> employees = new List<Employee>(countOfEmployees);
            ///
            employees.Add(new Employee("Арайан", "Тимурхан", "011"));
            employees.Add(new Employee("Вальярова", "Алина", "012"));
            employees.Add(new Employee("Воронко", "Диана", "013"));
            employees.Add(new Employee("Заречный", "Максим", "014"));
            employees.Add(new Employee("Муракаева", "Дания", "015"));
            employees.Add(new Employee("Полетаев", "Никита", "016"));
            employees.Add(new Employee("Салимов", "Радмир", "017"));
            employees.Add(new Employee("Сархандеева", "Аделина", "018"));
            employees.Add(new Employee("Чернова", "Маргарита", "019"));
            employees.Add(new Employee("Шпак", "Виталий", "020"));
            ///
            string path = @"TextFile1.txt";
            List<Task> tasks = new List<Task>(countOfEmployees);
            string str;
            using (StreamReader reader = new StreamReader(path))
            {
                while ((str = reader.ReadLine()) != null)
                {

                    string[] data = str.Split('/');

                    for (int i = 0; i < data.Length; i++)
                    {
                        string t = data[i];
                        tasks.Add(new Task(t, teamlead));

                    }

                }

            }

            project.AddTasksInProject(tasks);
            Employee.GiveTasks(employees, tasks);
            Console.ReadKey();
            Console.Clear();

            while (employees.Count > 0)
            {
                Console.WriteLine("Чтобы сдать отчет работника выберите цифру, стоящую рядом с работником");
                Console.WriteLine("Работники:");
                for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {employees[i].PrintInfo()}");
                }
                int index;
                while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > employees.Count)
                {
                    Console.WriteLine("Неверный ввод!");
                }
                if (System.DateTime.Now > deadline)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Отчет создан позже срока");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Отчет создан в срок");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Report onCheck = Report.CreateNewReport(employees[index - 1]);
                Console.WriteLine($"Инициатор к тебе вопрос!Нравится ли тебе отчет работника {employees[index - 1].PrintInfo()}?да/нет");
                Console.WriteLine("Его отчет:");
                onCheck.PrintInfoReport();
                string answer = Console.ReadLine();
                while (!answer.Equals("да") && !answer.Equals("нет"))
                {
                    Console.WriteLine("Повторите ввод!");
                    answer = Console.ReadLine();
                }
                if (answer.Equals("да"))
                {
                    Task.CloseTask(employees[index - 1]);
                    employees.Remove(employees[index - 1]);
                    onCheck = null;
                }
                else
                {
                    Console.WriteLine("Отчет не завершен!Доработайте!");
                    onCheck = null;
                }
            }
            project.CloseProject();
            Console.ReadKey();
        }
    }
}
