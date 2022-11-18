using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork88.Classes
{
    /// <summary>
    /// Статусы проекта
    /// </summary>
    public enum StatusOfProject
    {
        Project,
        InProcess,
        Closed
    }
    class Project
    {
        /// <summary>
        /// Описание проекта
        /// </summary>
        private string description;
        /// <summary>
        /// Дедлайн
        /// </summary>
        private DateTime time;
        /// <summary>
        /// Тимлид
        /// </summary>
        private TeamLead teamlead;
        /// <summary>
        /// Заказщик
        /// </summary>
        private Customer customer;
        /// <summary>
        /// Лист с заданиями к проекту
        /// </summary>
        List<Task> tasksOfProject;
        /// <summary>
        /// Стутус проекта
        /// </summary>
        private StatusOfProject status;
        /// <summary>
        /// Создание объекта класса с описанием description, дедлайном deadline, тимлидом teamlead, заказщиком customer
        /// </summary>
        /// <param name="description"></param>
        /// <param name="deadline"></param>
        /// <param name="teamlead"></param>
        /// <param name="customer"></param>
        public Project(string description, DateTime deadline, TeamLead teamlead, Customer customer)
        {
            this.description = description;
            time = deadline;
            this.teamlead = teamlead;
            this.customer = customer;
            status = StatusOfProject.Project;

        }
        /// <summary>
        /// Метод, добавляющий выполненное задание в проект
        /// </summary>
        /// <param name="tasks"></param>
        public void AddTasksInProject(List<Task> tasks)
        {
            if (tasks != null && tasksOfProject == null)
            {
                tasksOfProject = tasks;
                status = StatusOfProject.InProcess;
            }
        }
        /// <summary>
        /// Метод, закрывающий проект после его завершения
        /// </summary>
        public void CloseProject()
        {
            if (status == StatusOfProject.InProcess)
            {
                status = StatusOfProject.Closed;
                if (time < DateTime.Now)
                {
                    Console.WriteLine("Проект закрыт не вовремя!");
                }
                else
                {
                    Console.WriteLine("Вам удалось уложиться в дедлайн!");
                }
            }
        }


    }
}
