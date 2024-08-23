using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024.Home
{
    internal class Sleeping_Room : Task
    {
        public Sleeping_Room(string name, DateTime date, bool status, string comment) : base(name, date, status, comment)
        {

        }

        public Sleeping_Room()
        {
            
        }

        internal override Sleeping_Room AddTask()
        {
            Name = AddName();
            Date = AddDate();
            Status = AddStatus();
            Comment = AddComment();

            return new Sleeping_Room(Name, Date, Status, Comment);
        }
    }
}
