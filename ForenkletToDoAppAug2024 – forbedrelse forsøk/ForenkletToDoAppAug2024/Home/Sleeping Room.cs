using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024.Home
{
    internal class SleepingRoom : Task //helt lik task, utennom egen konstruktør og egen AddTask
    {
        public SleepingRoom(string name, DateTime? date, TaskStatus status, string comment = "Ingen kommentar", string taskType = "Soverom") : base(name, date, status, comment, taskType)
        {
        }

        public SleepingRoom()
        {
            
        }

        internal override SleepingRoom AddTask()
        {
            Name = AddName();
            Date = AddDate();
            Status = AddStatus();
            Comment = AddComment();

            return new SleepingRoom(Name, Date, Status, Comment);
        }
    }
}
