using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForenkletToDoAppAug2024
{
    public enum TaskStatus //Ansvar for å vise om oppgaven er 'Ikke Startet', 'I Progresjon' eller 'Ferdig' og gjelder alle oppgaver. På norsk ettersom det brukes i writeoutinfo.
    {
        IkkeStartet,
        IProgresjon,
        Ferdig
    }
}
