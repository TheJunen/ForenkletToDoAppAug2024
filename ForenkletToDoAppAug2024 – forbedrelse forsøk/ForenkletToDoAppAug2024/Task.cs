using ForenkletToDoAppAug2024.Home;
using ForenkletToDoAppAug2024.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    internal class Task //Oppgaver uten kategori lages type Task
    {
        private DateTime? _date;
        private TaskStatus _status;
        private string _comment;
        private string _name;
        private TaskLogic taskLogic { get; } = new TaskLogic();
        private string _taskType;

        public DateTime? Date //brukerinput må valideres
        {
            get { return _date; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Date must be in the future. Please try again.");
                }
                _date = value;
            }
        }

        public TaskStatus Status //brukerinput må valideres
        {
            get { return _status; }
            set
            {
                if (value < (TaskStatus)(0) || value > (TaskStatus)(2))
                {
                    throw new ArgumentException("Input is not between (TaskStatus)(0)-(2). Please try again.");
                }
                _status = value;
            }

        }

        public string Comment //brukerinput må valideres
        {
            get { return _comment; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Input is null");
                }
                else if (value == "")
                {
                    _comment = "Ingen kommentar";
                }
                else
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
                    throw new ArgumentException("Input is empty, have only space or is null");
                }
                _name = value;
            }
        }

        public string TaskType //brukerinput må valideres
        {
            get { return _taskType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Input is empty, have only space or is null");
                }
                _taskType = value;
            }
        }

        public Task(string name, DateTime? date, TaskStatus status, string comment = "Ingen kommentar", string taskType = "Annen oppgave")
        {
            Name = name;
            Date = date;
            Status = status;
            Comment = comment;
            TaskType = taskType;
        }

        public Task() //tom konstruktør for å lage en midlertidig instanse for å enkelt få tilgang til klassen.
        {

        }

        //ha metoder som er helt likt for alle klasser her, slik at det ikke blir gjentakelser.

        protected void EditName() //Oppdaterer navnet basert på bruker input
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                Console.WriteLine("Skriv inn det nye navnet:");
                string answer = Console.ReadLine();

                try
                {
                    Name = answer;
                    Console.WriteLine($"Navnet '{answer}' ble lagt til vellykket.");
                    isInputValid = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Feil: {ex.Message}");
                }
            }
        }


        protected void EditDate() //Oppdaterer dato basert på bruker input
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                Console.WriteLine("Skriv inn ny dato: (format: dd/MM/yyyy)");

                if (DateTime.TryParse(Console.ReadLine(), out DateTime newdate)) //valideringen sørger for at en gyldig dato blir laget før det blir lagt til i Date
                {
                    Date = newdate;
                    Console.WriteLine($"Dato oppdatert til: {Date}");
                    isInputValid = true;
                }
                else
                {
                    Console.WriteLine("Ugyldig input. vennligst skriv format: dd/MM/yyyy");
                }
            }
        }

        protected void EditStatus() //Oppdaterer Status basert på bruker input
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
        }

        protected void EditComment() //Oppdaterer kommentar basert på bruker input
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                Console.WriteLine("Skriv inn den nye kommentaren:");
                string answer = Console.ReadLine();

                try
                {
                    Comment = answer;
                    Console.WriteLine($"Kommentaren '{answer}' ble lagt til vellykket.");
                    isInputValid = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Feil: {ex.Message}");
                }
            }
        }

        internal virtual void EditTask() //Meny for å oppdatere navn, dato, status eller kommentar
        {
            Console.WriteLine("Skriv 1 for å oppdatere navn, 2 for tid, 3 for status og 4 for kommentar");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    EditName();
                    break;
                case "2":
                    EditDate();
                    break;
                case "3":
                    EditStatus();
                    break;
                case "4":
                    EditComment();
                    break;
                default:
                    Console.WriteLine("Èrror. Vennligst skriv inn et gyldig tall");
                    EditTask(); //kjører rekursivt hvis et gyldig tall ikke ble skrevet
                    break;
            }
        }

        protected string AddName() //Lager og returnerer navn basert på bruker input
        {

            bool isInputValid = false;
            string name = null;

            while (!isInputValid) //loop for å sørge for riktig input
            {
                Console.WriteLine("Skriv inn navn:");
                name = Console.ReadLine();

                try
                {
                    Name = name; //validerer variabel med property slik at property for riktig input
                    Console.WriteLine($"Navnet '{name}' ble lagt til vellykket.");
                    isInputValid = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Feil: {ex.Message}");
                }
            }
            return name;
        }

        protected static DateTime AddDate() //Lager og returnerer dato basert på bruker input
        {
            bool isValidInput = false;
            DateTime newdate = DateTime.MinValue;
            while (!isValidInput) //loop for å sørge for riktig input
            {
                Console.WriteLine("Skriv inn ny dato: (format: dd/MM/yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out newdate)) //validasjon sørger for gyldig dato før det returneres
                {
                    Console.WriteLine("En gyldig tid ble skrevet. Fortsetter.");
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Ugyldig input. Vennligst skriv inn et gyldig heltall");
                }
            }
            return newdate;
        }

        protected TaskStatus AddStatus() //Lager og returnerer status basert på bruker input
        {
            bool isInputValid = false;
            TaskStatus status = TaskStatus.IkkeStartet;
            while (!isInputValid) //loop for å sørge for riktig input
            {
                Console.WriteLine("Skriv inn status: (fra 1 til {0}):", Enum.GetValues(typeof(TaskStatus)).Length);
                Console.WriteLine("Skriv 1 for 'IkkeStartet', 2 for 'IProgresjon' og 3 for 'Ferdig'.");
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out int statusInput) && Enum.IsDefined(typeof(TaskStatus), statusInput - 1)) //validasjon sørger for gyldig status før det returneres ved å sjekke input kan konverteres til heltall og om det er en gyldig verdi i TaskStatus-enumet (-1 for å tilpasse til enum indeksene)
                {
                    isInputValid = true;
                    status = (TaskStatus)(statusInput - 1);
                }
                else
                {
                    Console.WriteLine("ugyldig input. vennligst skriv inn 1,2 eller 3.");
                }

            }
            return status;
        }

        protected string AddComment()
        {
            bool isInputValid = false;
            string comment = null;

            while (!isInputValid) //loop for å sørge for riktig input
            {
                Console.WriteLine("Skriv inn kommentar:");
                comment = Console.ReadLine();

                try
                {
                    Comment = comment; //validerer variabel med property slik at property får riktig input
                    Console.WriteLine($"Kommentar '{comment}' ble lagt til vellykket.");
                    isInputValid = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Feil: {ex.Message}");
                }
            }
            return comment;
        }

        internal virtual Task AddTask() //Lager oppgave. Fyller alle task properties med variablene fra tilhørende metoder og legger til i en Task instanse som returneres.
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
            Console.WriteLine($"Oppgave ({TaskType}): {Name}, {Date}, {Status}, {Comment}");
        }
    }
}
