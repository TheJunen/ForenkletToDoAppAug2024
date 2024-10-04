// See https://aka.ms/new-console-template for more information
using ForenkletToDoAppAug2024.Home;
using ForenkletToDoAppAug2024.Work;
using System.Collections.Generic;

namespace ForenkletToDoAppAug2024
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            List<Task> undonetask = new List<Task>(); //lager bool for while loop, lister, oppgaver, og UpdateList for å legge til oppgavene i riktig liste. DateTime er nytt for meg så var greit å øve
            List<Task> completedtask = new List<Task>();
            DateTime bathroomdate = new DateTime(2024, 10, 10);
            var bathroom = new Bathroom("Vaske do", bathroomdate, (TaskStatus)(0), "Jo fortere gjort, jo bedre");
            DateTime livingroomdate = new DateTime(2024, 11, 30);
            var living_room = new Living_Room("Støvsuge stuen", livingroomdate, (TaskStatus)(0), "");
            DateTime sleepingroomdate = new DateTime(2024, 12, 05);
            var sleeping_room = new Sleeping_Room("Rydde soverommet", sleepingroomdate, (TaskStatus)(1), "");
            DateTime bossdate = new DateTime(2024, 12, 01);
            var boss = new Boss("levere inn rapport for aug 2024", bossdate, (TaskStatus)(2), "må være nøyaktig", (StatusAtWorkOrHome)(0));
            DateTime othertaskdate = new DateTime(2024, 10, 05);
            var othertask = new Task("Hente ungen i barnehagen", othertaskdate, (TaskStatus)(2), "Hentes kl 15");
            UpdateList(bathroom, undonetask, completedtask);
            UpdateList(living_room, undonetask, completedtask);
            UpdateList(sleeping_room, undonetask, completedtask);
            UpdateList(boss, undonetask, completedtask);
            UpdateList(othertask, undonetask, completedtask);


            //var statusresult = bathroom.CheckStatusAndPutToList(bathroom, undonetask, completedtask);
            //if (statusresult == completedtask)
            //{
            //    completedtask = statusresult;
            //}
            //else
            //{
            //    undonetask = statusresult;
            //}
            //var statusresult2 = living_room.CheckStatusAndPutToList(living_room, undonetask, completedtask);
            //if (statusresult2 == completedtask)
            //{
            //    completedtask = statusresult2;
            //}
            //else
            //{
            //    undonetask = statusresult2;
            //}
            //var statusresult3 = sleeping_room.CheckStatusAndPutToList(sleeping_room, undonetask, completedtask);
            //if (statusresult3 == completedtask)
            //{
            //    completedtask = statusresult3;
            //}
            //else
            //{
            //    undonetask = statusresult3;
            //}

            Console.WriteLine("Her er listen av ugjorte oppgaver:"); //henter ut alle oppgavene fra listen og bruker writeoutinfo for å skrive ut oppgavedetaljene. Kunne godt vært i en metode for å minimere kode i Main
            foreach (Task task in undonetask)
            {
                task.WriteOutInfo();
            }

            Console.WriteLine("Her er listen av gjorte oppgaver");
            foreach (Task task in completedtask)
            {
                task.WriteOutInfo();
            }



            while (running) //kjører helt til bruker velger å avslutte
            {
                Console.WriteLine("Skriv 1 for å lage ny oppgave, 2 for å endre oppgave, 3 for å se listene av ugjorte og gjorte oppgaver");
                string answer = Console.ReadLine();

                switch (answer) // meny med ulike funksjoner
                {
                    case "1":
                        Console.WriteLine("Velg type: 1 for badet, 2 for stue, 3 for soverom, 4 for jobbsjefen, 5 for annen oppgave");
                        string answercase1 = Console.ReadLine();
                        switch (answercase1)
                        {
                            case "1":
                                Bathroom newbathroom = new Bathroom().AddTask();
                                UpdateList(newbathroom, undonetask, completedtask); //prøvde å ha listen foran, men så må den klare å skille mellom listene
                                break;
                            case "2":
                                Living_Room newliving_room = new Living_Room().AddTask(); //i switch så hadde jeg objektene foran AddTask() som de oppgaveobjektene i starten av main,
                                                                                        //derfor ble de også endret likt til nye oppgaven og ble duplikat.
                                UpdateList(newliving_room, undonetask, completedtask);
                                break;
                            case "3":
                                Sleeping_Room newsleeping_room = new Sleeping_Room().AddTask();
                                UpdateList(newsleeping_room, undonetask, completedtask);
                                break;
                            case "4":
                                Boss newboss = new Boss().AddTask();
                                UpdateList(newboss, undonetask, completedtask);
                                break;
                            case "5":
                                Task newtask = new Task().AddTask();
                                UpdateList(newtask, undonetask, completedtask);
                                break;
                            default:
                                Console.WriteLine("Ugyldig input");
                                break;
                        }
                        break;
                    case "2":
                        ChooseTaskAndEdit(undonetask, completedtask);
                        break;
                    case "3":
                        PrintList(undonetask, completedtask);
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Du har nå avsluttet applikasjonen");
                        break;
                    default:
                        Console.WriteLine("Vennligst skriv inn et gyldig tall");
                        break;
                }
            }



        }


        //static private List<Task> CheckStatusAndPutToList(Task task, List<Task> undonetask, List<Task> completedtask)
        //{
            //if (task.Status == false)
            //{
            //    undonetask.Add(task);
            //    return undonetask;
            //}
            //else
            //{
            //    completedtask.Add(task);
            //    return completedtask;
            //}

//    /*Lage en liste for ferdig og ugjorte oppgaver
//     * status med false/true, og på slutten av metoden sjekker om det er false eller true og legger til riktig liste. I listene skal det være validering som går gjennom listen og tar vekk de med feil status.
//    */
//}

static private void UpdateList(Task task, List<Task> undonetask, List<Task> completedtask) //sorterer til og putter i  ugjort og gjort liste 
        {
        //    var statusresult = CheckStatusAndPutToList(task, undonetask, completedtask);
        //    if (statusresult == completedtask)
        //    {
        //        completedtask = statusresult;
        //        return completedtask;
        //    }
        //    else
        //    {
        //        undonetask = statusresult;
        //        return undonetask;
        //    }
            if (task.Status == TaskStatus.IkkeStartet || task.Status == TaskStatus.IProgresjon)
            {
                undonetask.Add(task);
            }
            else
            {
                completedtask.Add(task);
                //return completedtask; ettersom alt som sendes i parameter er referanser som endrer direkte på objektet, så trenger jeg ikke å returnere listen da endringen er globalt for hele programmet.
            }
            //var statusresult2 = living_room.CheckStatusAndPutToList(living_room, undonetask, completedtask);
            //if (statusresult2 == completedtask)
            //{
            //    completedtask = statusresult2;
            //}
            //else
            //{
            //    undonetask = statusresult2;
            //}
            //var statusresult3 = sleeping_room.CheckStatusAndPutToList(sleeping_room, undonetask, completedtask);
            //if (statusresult3 == completedtask)
            //{
            //    completedtask = statusresult3;
            //}
            //else
            //{
            //    undonetask = statusresult3;
            //}
        }

        static private int PrintList(List<Task> undonetask, List<Task> completedtask) //skriver ut listene basert på valg
        {
            Console.WriteLine("Skriv 1 for ugjort liste, 2 for gjort liste");

            bool running = true;
            while (running) 
            { 
                string answer = Console.ReadLine();                   
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("Her er listen av ugjorte oppgaver:");
                        foreach (var task in undonetask)
                        {
                            task.WriteOutInfo();
                        }
                        return 1;
                    case "2":
                        Console.WriteLine("Her er listen av ferdige oppgaver:");
                        foreach (var task in completedtask)
                        {
                            task.WriteOutInfo();
                        }
                        return 2;
                    default:
                        Console.WriteLine("Ugyldig input");
                        break;
                }
            }
            return -1;
            
        }

        static private List<Task> ChooseTaskAndEdit(List<Task> undonetask, List<Task> completedtask) //skriver ut valgt liste, og en meny for å endre oppgave i listen
        {
            Console.WriteLine("Velg 1 for å endre ugjort liste, 2 for gjort liste");
            int result = PrintList(undonetask, completedtask); //basert
            

            if (result == 1)
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("Skriv 1 for å endre nr 1, 2 for nr 2 også videre");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int number))
                    {               
                        running = false;
                        int intanswer = number - 1;
                        undonetask[intanswer].UpdateTask();                 
                    }
                    else
                    {
                        Console.WriteLine("ugyldig input. vennligst skriv inn 'true' eller 'false'.");
                    }

                }
                return undonetask;
            }
            else if (result == 2) 
            {
                Console.WriteLine("Skriv 1 for å endre nr 1, 2 for nr 2 også videre");
                bool running = true;
                while (running)
                {
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int number))
                    {
                        running = false;
                        int intanswer = number - 1;
                        completedtask[intanswer].UpdateTask();
                    }
                    else
                    {
                        Console.WriteLine("ugyldig input. vennligst skriv inn 'true' eller 'false'.");
                    }

                }
                return completedtask;
            }
            else
            {
                Console.WriteLine("Ugyldig input");
            }
            return undonetask;
        }

        //static private List<Task> AddTaskToList(List<Task> undonetask, List<Task> completedtask)
        //{
        //    if ()
        //}


    }
}

