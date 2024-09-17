using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024.Home
{
    internal class Living_Room : Task
    {
        public Living_Room(string name, DateTime date, TaskStatus status, string comment) : base(name, date, status, comment)
        {

        }

        public Living_Room()
        {
            
        }

        internal override Living_Room AddTask()
        {
            Name = AddName();
            Date = AddDate();
            Status = AddStatus();
            Comment = AddComment();

            return new Living_Room(Name, Date, Status, Comment);
        }
    }
}
