using ForenkletToDoAppAug2024.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024.Work
{
    internal class Boss : Task
    {
        private bool AtWork;

        public Boss(string name, DateTime date, bool status, string comment, bool AtWork) : base(name, date, status, comment)
        {
            
        }

        public Boss()
        {
            
        }

        private bool AddWorkOrHome()
        {
            Console.WriteLine("Skriv Y for på jobb, N for hjemme");
            string answer = Console.ReadLine().ToLower();
            bool running = true;

            while(running)
            {
                if (answer == "y")
                {
                    Console.WriteLine("Du valgte på jobb.");
                    AtWork = true;
                    running = false;
                }
                else if (answer == "n") 
                {
                    Console.WriteLine("Du valgte hjemme.");
                    running = false;
                    AtWork = false; ;
                }
                else 
                {
                    Console.WriteLine("Ugyldig input");
                }
            }
            return false;

        }
        internal override Boss AddTask()
        {
            Name = AddName();
            Date = AddDate();
            Status = AddStatus();
            Comment = AddComment();
            AddWorkOrHome();
            return new Boss(Name, Date, Status, Comment, AtWork);
        }

    }
}
