using ForenkletToDoAppAug2024.Home;
using ForenkletToDoAppAug2024.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace ForenkletToDoAppAug2024
{
    internal class TaskLogic
    {
        DisplayManager displayManager = new DisplayManager();
        internal void AddToTaskList(Task task, List<Task> undoneTasksList, List<Task> completedTasksList) //sorterer og legger til i ugjort eller gjort liste 
        {
            if (task.Status == TaskStatus.IkkeStartet || task.Status == TaskStatus.IProgresjon)
            {
                undoneTasksList.Add(task);
            }
            else
            {
                completedTasksList.Add(task);
            }
        }


        internal void EditTask(List<Task> undoneTasksList, List<Task> completedTasksList) //endrer på valgt oppgave
        {
            Console.WriteLine("Velg 1 for å endre ugjort liste, 2 for gjort liste");
            int selectedList = SelectList(); //returnerer index basert på listevalg

            if (selectedList == 1)
            {
                displayManager.PrintOutTaskList("ugjort", undoneTasksList); //skriver ut ugjort liste
                int taskIndex = GetTaskIndex(undoneTasksList); //returnerer valgt task index
                undoneTasksList[taskIndex].EditTask(); //endrer valgt task
            }
            else if (selectedList == 2)
            {
                displayManager.PrintOutTaskList("ferdig", completedTasksList);
                int taskIndex = GetTaskIndex(completedTasksList);
                completedTasksList[taskIndex].EditTask();
            }
        }

        private int SelectList() //returnerer index basert på listevalg
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && (choice == 1 || choice == 2))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Ugyldig valg, prøv igjen.");
                return SelectList();
            }
        }

        private int GetTaskIndex(List<Task> taskList) //returnerer valgt task index
        {
            bool validInput = false;
            int index = -1;

            while (!validInput)
            {
                Console.WriteLine("Skriv nummeret på oppgaven du vil endre (1 for nr1, 2 for nr2 osv.):");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number) && number > 0 && number <= taskList.Count)
                {
                    validInput = true;
                    index = number - 1;
                }
                else
                {
                    Console.WriteLine("ugyldig input. vennligst skriv inn 1 for å endre nr 1, 2 for nr 2 også videre");
                }
            }

            return index;
        }

        internal void HandleTaskCreation(int taskType, List<Task> undoneTasksList, List<Task> completedTasksList) //Håndterer oppgavelaging basert på valg i ToDoAppMenu
        {
            Task newTask = taskType switch //int switch basert på valg i todoappmenu
            {
                1 => new Bathroom().AddTask(),
                2 => new LivingRoom().AddTask(),
                3 => new SleepingRoom().AddTask(),
                4 => new Boss().AddTask(),
                5 => new Task().AddTask(),
                _ => null
            };

            if (newTask == null) //kjører rekursivt ved null
            {
                Console.WriteLine("Ugyldig oppgavetype. Vennligst prøv igjen.");
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out int newTaskType))
                {
                    HandleTaskCreation(newTaskType, undoneTasksList, completedTasksList);
                }
            }
            else //Legger til oppgave i korrekt liste
            {
                AddToTaskList(newTask, undoneTasksList, completedTasksList);
            }
        }

        internal Task CreateTaskInTaskInitializer(TaskType tasktype, string name, DateTime date, TaskStatus status, string comment = "Ingen kommentar", WorkLocation? workLocation = null) //håndterer oppgavelaging i TaskInitializer
        {
            return tasktype switch //returnerer oppgavetype basert på TaskType
            {
                TaskType.Bathroom => new Bathroom(name, date, status, comment),
                TaskType.LivingRoom => new LivingRoom(name, date, status, comment),
                TaskType.SleepingRoom => new SleepingRoom(name, date, status, comment),
                TaskType.Boss when workLocation.HasValue => new Boss(name, date, status, workLocation.Value, comment),
                _ => new Task(name, date, status, comment),
            };
        }
        //neste er å sjekke fra etter Task om det er gyldige kommentarer og metodene er delt opp riktig etter jeg har implementert denne
    }
}
