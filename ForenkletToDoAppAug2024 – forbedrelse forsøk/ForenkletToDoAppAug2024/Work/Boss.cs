using ForenkletToDoAppAug2024.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024.Work
{
    internal class Boss : Task //egen updateTask og AddWork, fordi AtWork må endres og lages egen type instanse
    {
        private WorkLocation _workLocation;

        public WorkLocation WorkLocation //brukerinput må valideres
        {
            get { return _workLocation; }
            set
            {
                if (value < (WorkLocation)(0) || value > (WorkLocation)(1))
                {
                    throw new ArgumentException("Input is not between (WorkLocation)(0)-(2). Please try again.");
                }
                _workLocation = value;
            }
        }

        public Boss(string name, DateTime? date, TaskStatus status, WorkLocation workLocation, string comment = "Ingen kommentar", string taskType = "Sjef") : base(name, date, status, comment, taskType)
        {
            WorkLocation = workLocation;
        }

        public Boss()
        {
            
        }

        internal override void EditTask() 
        {
            Console.WriteLine("Skriv 1 for å oppdatere navn, 2 for tid, 3 for status, 4 for kommentar og 5 for Jobb/Hjemme");
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
                case "5":
                    AddWorkLocation();
                    break;
                default:
                    Console.WriteLine("Èrror. Vennligst skriv inn et gyldig tall");
                    break;
            }
        }

        private WorkLocation AddWorkLocation() //tar inn bruker input for å fylle status for om det er hjemme eller jobboppgave
        {

            while(true)
            {
                Console.WriteLine("Skriv inn status: (fra 1 til {0}):", Enum.GetValues(typeof(WorkLocation)).Length);
                Console.WriteLine("Skriv 1 for 'Jobb' og 2 for 'Hjemme'.");
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out int status) && Enum.IsDefined(typeof(TaskStatus), status - 1))
                {
                    return WorkLocation = (WorkLocation)(status - 1);
                }
                else
                {
                    Console.WriteLine("ugyldig input. vennligst skriv inn 1,2 eller 3.");
                }
            }
        }
        internal override Boss AddTask()
        {
            Name = AddName();
            Date = AddDate();
            Status = AddStatus();
            Comment = AddComment();
            AddWorkLocation();

            return new Boss(Name, Date, Status, WorkLocation, Comment);
        }

        internal override void WriteOutInfo() //skriver ut oppgavedetaljer
        {
            Console.WriteLine($"Oppgave ({TaskType}): {Name}, {Date}, {Status}, {Comment}, På jobb: {WorkLocation}");
        }

    }
}
