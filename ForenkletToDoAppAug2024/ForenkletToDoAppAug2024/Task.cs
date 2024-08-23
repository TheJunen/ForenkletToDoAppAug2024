using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    internal class Task
    {
        protected DateTime Date;
        internal bool Status;
        protected string Comment;
        protected string Name;

        //ha metoder som er helt likt for alle klasser her, slik at det ikke blir gjentakelser.
        public Task(string name, DateTime date, bool status, string comment)
        {
            Name = name;
            Date = date;
            Status = status;
            Comment = comment;
        }

        public Task()
        {
            
        }

        protected void UpdateName()
        {
            Console.WriteLine("Skriv inn det nye navnet");
            Name = Console.ReadLine();
        }


        protected void UpdateDate()
        {
            Console.WriteLine("Skriv inn ny dato: (format: dd/MM/yyyy)");

            if (DateTime.TryParse(Console.ReadLine(), out DateTime newdate))
            {
                Date = newdate;
                Console.WriteLine($"Dato oppdatert til: {Date}");
            }
            else
            {
                Console.WriteLine("Ugyldig input. vennligst skriv format: dd/MM/yyyy");
            }
        }

        protected bool UpdateStatus()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Skriv inn ny status: (true/false)");
                string answer = Console.ReadLine();

                if (bool.TryParse(answer, out bool status))
                {
                    Status = status;
                    running = false;
                }
                else
                {
                    Console.WriteLine("Ugyldig input. Vennligst skriv inn 'true' eller 'false'.");
                }

            }
            return Status;
        }

        protected void UpdateComment()
        {
            Console.WriteLine("Skriv inn ny kommentar");
            Comment = Console.ReadLine();
        }

        internal void UpdateTask()
        {
            Console.WriteLine("Skriv 1 for å oppdatere navn, 2 for tid, 3 for status og 4 for kommentar");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    UpdateName();
                    break;
                case "2":
                    UpdateDate();
                    break;
                case "3":
                    UpdateStatus();
                    break;
                case "4":
                    UpdateComment();
                    break;
                default:
                    Console.WriteLine("Èrror. Vennligst skriv inn et gyldig tall");
                    break;
            }
        }

        protected string AddName()
        {
            Console.WriteLine("Skriv inn navn");
            string name = Console.ReadLine();
            return name;
        }

        protected static DateTime AddDate()
        {
            bool isValid = false;
            DateTime newdate = DateTime.MinValue;
            while (!isValid)
            {
                Console.WriteLine("Skriv inn ny dato: (format: dd/MM/yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out newdate))
                {
                    Console.WriteLine("En gyldig tid ble skrevet. Fortsetter.");
                    isValid = true;
                    return newdate;
                }
                else
                {
                    Console.WriteLine("Ugyldig input. Vennligst skriv inn et gyldig heltall");
                }
            }
            return newdate;
        }

        protected bool AddStatus()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Skriv inn status: (true/false)");
                string input = Console.ReadLine();

                if (bool.TryParse(input, out bool status))
                {
                    running = false;
                    return status;
                }
                else
                {
                    Console.WriteLine("ugyldig input. vennligst skriv inn 'true' eller 'false'.");
                }

            }
            return false;
        }

        protected string AddComment()
        {
            Console.WriteLine("Skriv inn kommentar");
            string comment = Console.ReadLine();
            return comment;
        }
        internal virtual Task AddTask()
        {
            Name = AddName();
            Date = AddDate();
            Status = AddStatus();
            Comment = AddComment();
            Task task = new Task(Name, Date, Status, Comment);
            return task;
        }

        internal void WriteOutInfo()
        {
            Console.WriteLine($"{Name}, {Date}, {Status}, {Comment}");
        }
    }
}
