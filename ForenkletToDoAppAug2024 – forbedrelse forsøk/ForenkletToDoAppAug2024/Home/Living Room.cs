using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024.Home
{
    internal class LivingRoom : Task
    {
        public LivingRoom(string name, DateTime? date, TaskStatus status, string comment = "Ingen kommentar", string taskType = "Stue") : base(name, date, status, comment, taskType)
        {

        }

        public LivingRoom()
        {
            
        }

        internal override LivingRoom AddTask()
        {
            Name = AddName();
            Date = AddDate();
            Status = AddStatus();
            Comment = AddComment();

            return new LivingRoom(Name, Date, Status, Comment);
        }
    }
}
