///Auteur: Robustiano Lomabrdo
///Date: 15.04.2024
///Description: Programme permettant la gestion d'horaires
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
            string value;
            do
            {
                //Création de la page princiaple
                Console.Clear();
                Console.WriteLine("\n\nBienvenu dans la gestion d'horaire de la boutique !\n");
                Console.WriteLine("Voici les horaires de la boutique :\n");
                //Affichage des horaires
                foreach (Hourly h in HourlyArray)
                {
                    if (h.opentHour == "")
                    {
                        Console.WriteLine(h.day + " -> Fermer ");
                    }
                    else if (h.secondopentHour != "")
                    {
                        Console.WriteLine(h.day + " -> " + h.opentHour + " - " + h.closeHour + "  " + h.secondopentHour + " - " + h.secondcloseHour);
                    }
                    else
                    {
                        Console.WriteLine(h.day + " -> " + h.opentHour + " - " + h.closeHour);
                    }
                }
                Console.WriteLine("\nQu'elle action shouaiter vous entreprendre ?");
                Console.WriteLine("\n[1] Modifier les horaires\n[2] Voir la validation des tests\n");
                value = Console.ReadLine();
                Console.WriteLine(value);
                //Destination selon le choix de l'utilisateur
                if (value == "1")
                {
                    //Modification des horaires
                    Console.Clear();
                    Console.WriteLine("\nQu'elle horaire shouaiter vous changer ?\n");
                    int i = 0;
                    foreach (Hourly h in HourlyArray)
                    {   
                        if (h.opentHour == "")
                        {
                            Console.WriteLine("["+i+"] "+ h.day + " -> Fermer ");
                        }
                        else if (h.secondopentHour != "")
                        {
                            Console.WriteLine("[" + i + "] " + h.day + " -> " + h.opentHour + " - " + h.closeHour + "  " + h.secondopentHour + " - " + h.secondcloseHour);
                        }
                        else
                        {
                            Console.WriteLine("[" + i + "] " + h.day + " -> " + h.opentHour + " - " + h.closeHour);
                        }
                        i++;
                    }
                    Console.WriteLine("");
                    value = Console.ReadLine();

                    Console.WriteLine("\nPour le bon fonctionnement du programme vous êtes priez d'écrire l'horaire de cette façon :\nMon-8:00-12:00-14:00-16:00\n" +
                        "Si vous n'avez qu'une seul plage horaire à indiquer, vous être prier de laisser la deuxième vide");                    
                    string[] newHourly = Console.ReadLine().Split("-");

                    Hourly changeHourly;

                    if (newHourly.Length < 4)
                    {
                        changeHourly = new Hourly(newHourly[0], newHourly[1], newHourly[2],"","");
                    }
                    else
                    {
                        changeHourly = new Hourly(newHourly[0], newHourly[1], newHourly[2], newHourly[3], newHourly[4]);
                    }

                    HourlyArray[Int32.Parse(value)] = changeHourly;

                }
                else
                {
                    //Affichage des Tests
                    Console.Clear();

                    DateTime wednesday = new DateTime(2024, 02, 21, 7, 45, 00);
                    DateTime thursday = new DateTime(2024, 02, 22, 12, 22, 11);
                    DateTime saturday = new DateTime(2024, 02, 24, 09, 15, 00);
                    DateTime sunday = new DateTime(2024, 02, 25, 09, 15, 00);
                    DateTime fridayMorning = new DateTime(2024, 02, 23, 08, 00, 00);
                    DateTime mondayMorning = new DateTime(2024, 02, 26, 08, 00, 00);
                    DateTime thursdayAfternoon = new DateTime(2024, 02, 22, 14, 00, 00);
                    Console.WriteLine("\n Voici les résultats des tests :\n");
                    Console.WriteLine("IsOpenOn(wednesday) == "+function.IsOpenOn(HourlyArray,wednesday)[0]);
                    Console.WriteLine("IsOpenOn(thursday) == " + function.IsOpenOn(HourlyArray, thursday)[0]);
                    Console.WriteLine("IsOpenOn(sunday) == " + function.IsOpenOn(HourlyArray, sunday)[0]);
                    Console.WriteLine("NextOpeningDate(thursday_afternoon) == " + function.NextOpeningDate(HourlyArray, thursdayAfternoon, function.IsOpenOn(HourlyArray,thursdayAfternoon)[1]));
                    Console.WriteLine("NextOpeningDate(saturday) == " + function.NextOpeningDate(HourlyArray, saturday, function.IsOpenOn(HourlyArray, saturday)[1]));
                    Console.WriteLine("NextOpeningDate(thursday) == " + function.NextOpeningDate(HourlyArray, thursday, function.IsOpenOn(HourlyArray, thursday)[1]));
                    Console.ReadLine();

                }
            }while (true);
        }
    } 
}