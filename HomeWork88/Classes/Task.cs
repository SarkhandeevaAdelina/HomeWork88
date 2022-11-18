using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork88.Classes
{
    enum StatusOfTask
    {
        Appointed,
        InProcess,
        OnCheck,
        Finished
    }
    class Task
    {
        private string description;
        private DateTime deadline;
        private TeamLead teamlead;
        private Employee worker;


        public Employee Worker
        {
            get { return worker; }
            private set { worker = value; }
        }

        private StatusOfTask status;
        public Task(string description, TeamLead teamlead)
        {
            this.description = description;
            this.teamlead = teamlead;
            status = StatusOfTask.Appointed;
        }
        public static void SwitchStatus(Employee worker, Task task)
        {
            if (worker.Task != null && worker.Task.status == StatusOfTask.Appointed)
            {
                worker.Task.status = StatusOfTask.InProcess;
                task.Worker = worker;

            }
        }
        public void PrintInfo()
        {
            Console.WriteLine($"{description} {deadline}");
        }
        public static void SendOnCheck(Employee employee)
        {
            if (employee.Task.status.Equals(StatusOfTask.InProcess))
            {

                employee.Task.status = StatusOfTask.OnCheck;
            }
        }
        public static void CloseTask(Employee employee)
        {
            if (employee.Task.status.Equals(StatusOfTask.OnCheck))
            {
                employee.Task.status = StatusOfTask.Finished;
            }
        }

    }
}
