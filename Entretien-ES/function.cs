///Auteur: Robustiano Lomabrdo
///Date: 15.04.2024
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
        /// <summary>
        /// Création des horaires
        /// </summary>
        /// <returns>La liste des horaires</returns>
        public List<Hourly> createHourly()
        {
            List<Hourly> result = new List<Hourly>();
            result.Add(new Hourly("Mon", "8:00", "16:00", "", ""));
            result.Add(new Hourly("Tue", "8:00", "12:00", "14:00", "18:00"));
            result.Add(new Hourly("Wed", "8:00", "16:00", "", ""));
            result.Add(new Hourly("Thu", "8:00", "12:00", "14:00", "18:00"));
            result.Add(new Hourly("Fri", "8:00", "16:00", "", ""));
            result.Add(new Hourly("Sat", "8:00", "12:00", "", ""));
            result.Add(new Hourly("Sun", "", "", "", ""));
            return result;
        }

        /// <summary>
        /// Savoir si le magasin est ouvert ou non
        /// </summary>
        /// <param name="listHourly">La liste des horaires</param>
        /// <param name="dateTime">La date désirer</param>
        /// <returns></returns>
        public bool[] IsOpenOn(List<Hourly> listHourly, DateTime dateTime)
        {
            string day = dateTime.DayOfWeek.ToString();
            foreach (Hourly hourly in listHourly)
            {
                if (day.Contains(hourly.day))
                {
                    if (hourly.opentHour != "")
                    {
                        double openat = ConvertHour(hourly.opentHour);

                        double closeat = ConvertHour(hourly.closeHour);

                        string textwhathour = dateTime.Hour.ToString() + "," + dateTime.Minute.ToString();
                        double whathour = double.Parse(textwhathour);

                        if (whathour > openat && whathour < closeat) {
                            return new bool[] { true, false };
                        }
                        else if (hourly.secondopentHour != "") {
                            double secondopenat = ConvertHour(hourly.opentHour);

                            double secondcloseat = ConvertHour(hourly.closeHour);
                            if (whathour > openat && whathour < secondcloseat) { return new bool[] { true };
                            }
                            else { return new bool[] { false, true };
                            }
                        }
                        return new bool[] { false, false };
                    };
                    
                }
            }
            return new bool[] { false };
        }

        /// <summary>
        /// Savoir quand sera ouvert le magasin
        /// </summary>
        /// <param name="listHourly">La liste des horaires</param>
        /// <param name="dateTime">La date désirer</param>
        /// <param name="afternoon">Savoir si le jour sélection à une après midi</param>
        /// <returns>Le jour avec l'heure d'ouverture</returns>
        public String NextOpeningDate(List<Hourly> listHourly, DateTime dateTime, bool afternoon)
        {
            string day = dateTime.DayOfWeek.ToString();
            string textwhathour = dateTime.Hour.ToString() + "," + dateTime.Minute.ToString();
            double whathour = double.Parse(textwhathour);

            foreach (Hourly hourly in listHourly)
            {
                if (day.Contains(hourly.day))
                {
                    if(afternoon)
                    {
                        double openat = ConvertHour(hourly.secondopentHour);

                        double closeat = ConvertHour(hourly.secondcloseHour);
                        if (whathour < openat || whathour > closeat)
                            return hourly.day + " -> " + hourly.secondopentHour + " - " + hourly.secondcloseHour;
                    }

                    for (int i = 1; i <= 7; i++) {
                        DateTime tomorrow = dateTime.AddDays(i);
                        string nextday = tomorrow.DayOfWeek.ToString();
                        foreach (Hourly nexthourly in listHourly)
                        {
                            if (nextday.Contains(nexthourly.day) && nexthourly.closeHour != "") {
                                return nexthourly.day + " -> " + nexthourly.opentHour + " - " + nexthourly.closeHour;
                            }
                        }
                    }
                    
                }
            }
            return "";
        }

        /// <summary>
        /// Converti les heures string en double
        /// </summary>
        /// <param name="hour">L'heure a convertir</param>
        /// <returns></returns>
        public double ConvertHour(string hour)
        {
            string[] gethour = hour.Split(':');
            string texthour = gethour[0] + "," + gethour[1];
            return double.Parse(texthour);
        }
    }
}
