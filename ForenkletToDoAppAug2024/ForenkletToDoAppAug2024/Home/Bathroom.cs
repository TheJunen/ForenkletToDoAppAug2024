using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    internal class Bathroom : Task 
    {
        public Bathroom(string name, DateTime date, TaskStatus status, string comment) : base(name, date, status, comment)
        {

        }

        public Bathroom()
        {
            
        }

        internal override Bathroom AddTask()
        {
            Name = AddName();
            Date = AddDate();
            Status = AddStatus();
            Comment = AddComment();
            //Console.WriteLine($"{newtask.Name}, {newtask.Date}, {newtask.Status}, {newtask.Comment}");
            return new Bathroom(Name, Date, Status, Comment); // returnerer direkte men får ikke brukt writeline.
            //return newtask;
        }
    }
}
