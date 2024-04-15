using System;
using System.IO;

namespace Entretien_ES
{
    class Program
    {
        static void Main(string[] args)
        {
            function function = new function();
            List<Hourly> HourlyArray = function.createHourly();
            Console.WriteLine("\n\nBienvenu dans la gestion d'horaire de la boutique !\n");
            Console.WriteLine("Voici les horaires de la boutique :\n");
            foreach (Hourly h in HourlyArray) {
                if(h.opentHour == "") {
                    Console.WriteLine(h.day + " -> Fermer ");
                }
                else if(h.secondopentHour != "")
                {
                    Console.WriteLine(h.day + " -> " + h.opentHour + " - " + h.closeHour + "  " + h.secondopentHour + " - " + h.secondcloseHour);
                }
                else
                {
                    Console.WriteLine(h.day + " -> " + h.opentHour + " - " + h.closeHour);
                }
                Console.WriteLine(h.opentHour);
            }
            DateTime wednesday = new DateTime(2024, 02, 21, 7, 45, 00);
            Console.ReadLine();
        }
    } 
}