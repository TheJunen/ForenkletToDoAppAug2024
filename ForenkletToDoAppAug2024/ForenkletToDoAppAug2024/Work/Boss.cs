using ForenkletToDoAppAug2024.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024.Work
{
    internal class Boss : Task //egen updateTask og AddWork, fordi AtWork må endres og lages egen type instanse
    {
        public StatusAtWorkOrHome AtWorkOrHome { get; private set; }

        public Boss(string name, DateTime date, TaskStatus status, string comment, StatusAtWorkOrHome atworkorhome) : base(name, date, status, comment)
        {
            AtWorkOrHome = atworkorhome;
        }

        public Boss()
        {
            
        }

        internal override void UpdateTask() 
        {
            Console.WriteLine("Skriv 1 for å oppdatere navn, 2 for tid, 3 for status, 4 for kommentar og 5 for Jobb/Hjemme");
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
                case "5":
                    AddAtWorkOrHome();
                    break;
                default:
                    Console.WriteLine("Èrror. Vennligst skriv inn et gyldig tall");
                    break;
            }
        }

        private StatusAtWorkOrHome AddAtWorkOrHome() //skriver inn status for om det er hjemme eller jobboppgave
        {

            while(true)
            {
                Console.WriteLine("Skriv inn status: (fra 1 til {0}):", Enum.GetValues(typeof(StatusAtWorkOrHome)).Length);
                Console.WriteLine("Skriv 1 for 'Jobb' og 2 for 'Hjemme'.");
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out int status) && Enum.IsDefined(typeof(TaskStatus), status - 1))
                {
                    return AtWorkOrHome = (StatusAtWorkOrHome)(status - 1);
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
            AddAtWorkOrHome();
            Console.WriteLine("Oppgave ble lagt til.");
            return new Boss(Name, Date, Status, Comment, AtWorkOrHome);
        }

        internal override void WriteOutInfo() //skriver ut oppgavedetaljer
        {
            Console.WriteLine($"{Name}, {Date}, {Status}, {Comment}, På jobb: {AtWorkOrHome}");
        }

    }
}
