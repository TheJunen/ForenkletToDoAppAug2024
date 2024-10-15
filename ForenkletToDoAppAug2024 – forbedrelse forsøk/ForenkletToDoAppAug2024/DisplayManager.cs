using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    internal class DisplayManager
    {
        internal void PrintOutTaskLists(List<Task> undoneTasksList, List<Task> completedTasksList) //skriver ut begge listene
        {
            PrintOutTaskList("ugjort", undoneTasksList); 
            PrintOutTaskList("ferdig", completedTasksList);
        }

        internal void PrintOutTaskList(string taskType, List<Task> taskList) //Skriver ut liste basert på hvilken som ble sendt i parameter
        {
            Console.WriteLine($"Her er listen av {taskType} oppgaver:");
            foreach (var task in taskList)
            {
                task.WriteOutInfo();
            }
        }
    }
}
