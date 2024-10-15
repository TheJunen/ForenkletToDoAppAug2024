using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    internal class ToDoAppController
    {
        internal void RunToDoAppProgram()
        {
            TaskLists taskLists = new TaskLists();
            TaskLogic taskLogic = new TaskLogic();
            UserInput userInput = new UserInput();
            TaskInitializer taskInitializer = new TaskInitializer();
            DisplayManager displayManager = new DisplayManager();

            List<Task> undoneTasksList = taskLists.ReturnundoneTasksList() ?? new List<Task>(); //tar hensyn tl null verdi
            List<Task> completedTasksList = taskLists.ReturncompletedTasksList() ?? new List<Task>();

            taskInitializer.InitializeTasks(undoneTasksList, completedTasksList); //Initaliserer oppgaver

            displayManager.PrintOutTaskLists(undoneTasksList, completedTasksList);  //henter ut alle oppgavene fra listene og skriver ut oppgavedetaljene.

            userInput.ToDoAppMenu(undoneTasksList, completedTasksList); //kjører en ToDoApp Menu slik at bruker kan se ugjorte og ferdige oppgaver-lister, lage og endre på oppgaver.
        }
    }
}
