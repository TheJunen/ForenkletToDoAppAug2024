using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    internal class Task //Oppgaver uten kategori lages type Task
    {
        protected DateTime _date;
        internal TaskStatus Status {  get; set; }
        protected string _comment = "Ingen kommentar";
        protected string _name;

        public DateTime Date //brukerinput må valideres
        {
            get { return _date; }
            set 
            { 
                if (value <= DateTime.Now)
                {
                    throw new ArgumentException("Date must be in the future. Please try again.");
                }
                _date = value; 
            }

        }

        public string Comment //brukerinput må valideres
        {
            get { return _comment; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentException("Input is empty, have only space or is null.");
                }
                else if (value != "")
                {
                    _comment = value;
                }
            }
        }

        public string Name //brukerinput må valideres
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Input is empty, have only space or is null.");
                }
                _name = value;
            }
        }

        //ha metoder som er helt likt for alle klasser her, slik at det ikke blir gjentakelser.
        public Task(string name, DateTime date, TaskStatus status, string comment)
        {
            Name = name;
            Date = date;
            Status = status;
            Comment = comment;
        }

        public Task() //tom konstruktør for å lage en midlertidig instanse for å enkelt få tilgang til klassen.
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

        protected TaskStatus UpdateStatus()
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                Console.WriteLine("Skriv inn ny status: (fra 1 til {0}):", Enum.GetValues(typeof(TaskStatus)).Length);
                Console.WriteLine("Skriv 1 for 'IkkeStartet', 2 for 'IProgresjon' og 3 for 'Ferdig'.");
                string answer = Console.ReadLine();

                if (int.TryParse(answer, out int status) && Enum.IsDefined(typeof(TaskStatus), status - 1))
                {
                    Status = (TaskStatus)(status - 1);
                    isInputValid = true;
                }
                else
                {
                    Console.WriteLine("ugyldig input. vennligst skriv inn 1,2 eller 3.");
                }

            }
            return Status;
        }

        protected void UpdateComment()
        {
            Console.WriteLine("Skriv inn ny kommentar");
            Comment = Console.ReadLine();
        }

        internal virtual void UpdateTask() //Strukturert slik at hver handling er delt opp i egne metoder, og puttet i en meny. Fått tilbakemelding om at alt bør deles i flere metoder for mer objektorientert.
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
            bool isValidInput = false;
            DateTime newdate = DateTime.MinValue;
            while (!isValidInput)
            {
                Console.WriteLine("Skriv inn ny dato: (format: dd/MM/yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out newdate))
                {
                    Console.WriteLine("En gyldig tid ble skrevet. Fortsetter.");
                    isValidInput = true;
                    return newdate;
                }
                else
                {
                    Console.WriteLine("Ugyldig input. Vennligst skriv inn et gyldig heltall");
                }
            }
            return newdate;
        }

        protected TaskStatus AddStatus()
        {
            bool isInputValid = false;
            while (!isInputValid)
            {
                Console.WriteLine("Skriv inn status: (fra 1 til {0}):", Enum.GetValues(typeof(TaskStatus)).Length);
                Console.WriteLine("Skriv 1 for 'IkkeStartet', 2 for 'IProgresjon' og 3 for 'Ferdig'.");
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out int status) && Enum.IsDefined(typeof(TaskStatus), status - 1))
                {
                    isInputValid = true;
                    return Status = (TaskStatus)(status - 1);
                }
                else
                {
                    Console.WriteLine("ugyldig input. vennligst skriv inn 1,2 eller 3.");
                }

            }
            return Status;
        }

        protected string AddComment()
        {
            Console.WriteLine("Skriv inn kommentar");
            string comment = Console.ReadLine();
            return comment;
        }
        internal virtual Task AddTask() //ikke meny, alle metoder kjører for å lage en hel oppgave.
        {
            Name = AddName();
            Date = AddDate();
            Status = AddStatus();
            Comment = AddComment();
            Task task = new Task(Name, Date, Status, Comment);
            Console.WriteLine("Oppgave ble lagt til");
            return task;
        }

        internal virtual void WriteOutInfo() //skriver ut oppgavedetaljer
        {
            Console.WriteLine($"{_name}, {_date}, {Status}, {_comment}");
        }
    }
}
