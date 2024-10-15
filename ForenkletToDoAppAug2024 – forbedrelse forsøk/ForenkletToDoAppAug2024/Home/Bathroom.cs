using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    internal class Bathroom : Task 
    {
        public Bathroom(string name, DateTime? date, TaskStatus status, string comment = "Ingen kommentar", string taskType = "Bad") : base(name, date, status, comment, taskType)
        {

        }

        public Bathroom()
        {
            
        }

        internal override Bathroom AddTask() //Lager en oppgave av type 'Bathroom'. Fyller opp variabelene og lager et Bathroom instanse med de i
        {
            Name = AddName();
            Date = AddDate();
            Status = AddStatus();
            Comment = AddComment();
            return new Bathroom(Name, Date, Status, Comment); // returnerer direkte men får ikke brukt writeline.
        }
    }
}
