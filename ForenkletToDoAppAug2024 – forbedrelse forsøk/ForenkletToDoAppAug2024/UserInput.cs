using ForenkletToDoAppAug2024.Home;
using ForenkletToDoAppAug2024.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    internal class UserInput
    {
        TaskLogic taskLogic = new TaskLogic();
        DisplayManager displayManager = new DisplayManager();
        internal void ToDoAppMenu(List<Task> undoneTasksList, List<Task> completedTasksList) //ToDoApp meny med valg om å lage oppgave, endre oppgave eller se listene av ugjorte og gjorte oppgaver                                            
        {
            bool toDoAppMenuRunning = true;

            while (toDoAppMenuRunning)
            {
                Console.WriteLine("Skriv 1 for å lage ny oppgave, 2 for å endre oppgave, 3 for å se listene av ugjorte og gjorte oppgaver");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1": //lage oppgave
                        bool makeNewTaskSuccessful = false;
                        while (!makeNewTaskSuccessful)
                        {
                            Console.WriteLine("Velg type: 1 for badet, 2 for stue, 3 for soverom, 4 for jobbsjefen, 5 for annen oppgave");
                            string answercase1 = Console.ReadLine();
                            if (int.TryParse(answercase1, out int taskType) && taskType > 0 && taskType <= 5) //validasjon slik at det sørger 1-5 int for HandleTaskCreation
                            {
                                taskLogic.HandleTaskCreation(taskType, undoneTasksList, completedTasksList);
                                makeNewTaskSuccessful = true;
                            }
                            else
                            {
                                Console.WriteLine("Ugyldig input");
                            }
                        }
                        break;
                    case "2": //endre oppgave
                        taskLogic.EditTask(undoneTasksList, completedTasksList);
                        break;
                    case "3": //skrive ut oppgavelister
                        displayManager.PrintOutTaskLists(undoneTasksList, completedTasksList);
                        break;
                    case "4": //avslutte todoapp program
                        toDoAppMenuRunning = false;
                        Console.WriteLine("Du har nå avsluttet applikasjonen");
                        break;
                    default: //sier ifra om ugyldig verdi og kjører menyen på nytt
                        Console.WriteLine("Vennligst skriv inn et gyldig tall");
                        break;
                }
            }
        }
    }
}
