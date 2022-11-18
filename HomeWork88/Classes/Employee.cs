using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork88.Classes
{
    internal class Employee
    {
        /// <summary>
        /// Имя работника
        /// </summary>
        private string name;
        /// <summary>
        /// Фамилия работника
        /// </summary>
        private string surname;
        /// <summary>
        /// Id работника
        /// </summary>
        private string id;
        private Task task;
        public Task Task
        {
            get { return task; }
        }
        /// <summary>
        /// Создание объекта класса Employee работника именем name, фамилией surname, id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="id"></param>

        public Employee(string name, string surname, string id)
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
        }

        public string PrintInfo()
        {
            return $"{name} {surname}";
        }
        /// <summary>
        /// Метод, выдающий задания работникам
        /// </summary>
        /// <param name="workers"></param>
        /// <param name="tasks"></param>
        public static void GiveTasks(List<Employee> workers, List<Task> tasks)
        {
            Dictionary<string, Employee> dict = new Dictionary<string, Employee>();
            var tmp = new List<Task>();
            tmp.AddRange(tasks);
            foreach (Employee z in workers)
            {
                dict.Add(z.id, z);
            }
            for (int i = 0; i < workers.Count; i++)
            {
                for (int j = 0; j < tmp.Count; j++)
                {
                    if (workers[i].Task == null)
                    {
                        Console.WriteLine("Задача:");
                        tmp[j].PrintInfo();
                        Console.WriteLine("Исполнитель:");
                        Console.WriteLine(workers[i].PrintInfo());
                        Console.WriteLine("Будет ли он брать задачу?(да/нет)");
                        string answer = Console.ReadLine().ToLower();
                        while (!answer.Equals("да") && !answer.Equals("нет"))
                        {
                            Console.WriteLine("Повторите ввод!");
                            answer = Console.ReadLine();
                        }
                        if (answer.Equals("да") || j == tmp.Count - 1)
                        {
                            workers[i].task = tmp[j];
                            Task.SwitchStatus(workers[i], tmp[j]);
                            tmp.Remove(tmp[j]);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Работник получил задачу");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.WriteLine("Выберите кому планируете ее делегировать!");
                            foreach (Employee z in workers)
                            {
                                Console.WriteLine($"{z.id} - {z.name}");
                            }
                            for (int y = 1; y < 3; y++)
                            {
                                string iner = Console.ReadLine();
                                Console.WriteLine("Будет ли он брать задачу?(да/нет)");
                                answer = Console.ReadLine();
                                if (answer.Equals("да"))
                                {
                                    dict[iner].task = tmp[j];
                                    Task.SwitchStatus(dict[iner], tmp[j]);
                                    tmp.Remove(tmp[j]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Работник получил задачу");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                else if (y != 2)
                                    Console.WriteLine("Введите ID другого сотрудника");
                                if (y == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Задача никем не принята и удалена");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    tmp.Remove(tmp[j]);
                                }
                            }
                        }
                    }


                }
            }
        }
    }
}

