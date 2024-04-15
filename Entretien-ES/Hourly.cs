///Auteur: Robustiano Lomabrdo
///Date: 15.04.2024
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entretien_ES
{
    internal class Hourly
    {
        public string day;
        public string opentHour;
        public string closeHour;
        public string secondopentHour;
        public string secondcloseHour;

        public Hourly(string day, string opentHour, string closeHour, string secondopentHour, string secondcloseHour)
        {
            this.day = day;
            this.opentHour = opentHour;
            this.closeHour = closeHour;
            this.secondopentHour = secondopentHour;
            this.secondcloseHour = secondcloseHour;
        }
    }
}
