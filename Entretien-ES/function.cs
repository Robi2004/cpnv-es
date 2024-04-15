using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entretien_ES
{
    internal class function
    {
        public List<Hourly> createHourly()
        {
            List<Hourly> result = new List<Hourly> ();
            result.Add(new Hourly("Mon","8:00","16:00","",""));
            result.Add(new Hourly("Tue","8:00","12:00","14:00","18:00"));
            result.Add(new Hourly("Wed","8:00","16:00","",""));
            result.Add(new Hourly("Thu","8:00","12:00","14:00","18:00"));
            result.Add(new Hourly("Fri","8:00","16:00","",""));
            result.Add(new Hourly("Sat","8:00","12:00","",""));
            result.Add(new Hourly("Sun","","","",""));
            return result;
        }

        public bool IsOpenOn(List<Hourly> listHourly, DateTime dateTime)
        {
            foreach (Hourly hourly in listHourly)
            {
                string day = dateTime.DayOfWeek.ToString();
                if(day.Contains(hourly.day))
                {
                    
                }
            };
            DateTime wednesday = new DateTime(2024,02,21,7,45,00);
            return false;
        }
    }
}
