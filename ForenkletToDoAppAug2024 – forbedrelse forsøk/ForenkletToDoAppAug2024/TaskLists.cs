using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    internal class TaskLists //liste for ugjorte og ferdig oppgaver
    {
        List<Task> undoneTasksList = new List<Task>();
        List<Task> completedTasksList = new List<Task>();

        internal List<Task> ReturnundoneTasksList() //returnerer undoneTasksList
        {
            return undoneTasksList;
        }

        internal List<Task> ReturncompletedTasksList() //returnerer completedTasksList
        {
            return completedTasksList;
        }
    }
}
