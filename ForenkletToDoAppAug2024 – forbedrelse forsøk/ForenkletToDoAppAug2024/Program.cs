// See https://aka.ms/new-console-template for more information
using ForenkletToDoAppAug2024.Home;
using ForenkletToDoAppAug2024.Work;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ForenkletToDoAppAug2024
{
    class Program
    {
        static void Main(string[] args)
        {
            try //siste sikkerhetsmekamisme for å hindre at programmet krasjer. Den går igjennom hele programmet.
            {
                ToDoAppController toDoAppController = new ToDoAppController();
                toDoAppController.RunToDoAppProgram();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

