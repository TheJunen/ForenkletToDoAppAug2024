using ForenkletToDoAppAug2024.Home;
using ForenkletToDoAppAug2024.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    internal class TaskInitializer
    {
        TaskLogic taskLogic = new TaskLogic();

        internal void InitializeTasks(List<Task> undoneTasksList, List<Task> completedTasksList) 
        {

            var tasks = new List<Task> //samle alle task oppgaver i en liste
            {
                taskLogic.CreateTaskInTaskInitializer(TaskType.Bathroom, "Vaske do", new DateTime(2024, 12, 12), TaskStatus.IkkeStartet, "Jo fortere gjort, jo bedre"), //oppretter opgaver basert på typen oppgave
                taskLogic.CreateTaskInTaskInitializer(TaskType.LivingRoom, "Støvsuge stuen", new DateTime(2024, 11, 30), (TaskStatus)(0)),
                taskLogic.CreateTaskInTaskInitializer(TaskType.SleepingRoom, "Rydde soverommet", new DateTime(2024, 12, 05), TaskStatus.IProgresjon),
                taskLogic.CreateTaskInTaskInitializer(TaskType.Boss, "levere inn rapport for aug 2024", new DateTime(2024, 12, 01), TaskStatus.Ferdig, "må være nøyaktig", WorkLocation.Hjemme),
                taskLogic.CreateTaskInTaskInitializer(TaskType.General,"Hente ungen i barnehagen", new DateTime(2024, 11, 12), TaskStatus.Ferdig, "Hentes kl 15"),
            };

            foreach (var task in tasks) //Legger til oppgavene i riktig liste
            {
                taskLogic.AddToTaskList(task, undoneTasksList, completedTasksList);
            }
        }
    }
}
