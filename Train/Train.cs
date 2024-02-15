using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w67166_OP
{
    class Train : DatabaseManager
    {
        public Train(string name) : base(name) { }

        public void PrintTrains()
        {
            string[] items = Read();

            GUI.ColorText("Dostępne pociągi");

            if (items.Length == 0)
            {
                GUI.ColorText("Brak pociągów.\n", ConsoleColor.DarkGray);
            }
            else
            {
                Console.WriteLine("================================================================");
                Console.WriteLine("N | Typ | Numer | Pociag | Ilość miejsc | Trasa | Peron | Status");
                Console.WriteLine("================================================================");
                foreach (var item in items)
                {
                    string[] itemValues = item.Split(";");

                    GUI.ColorText(String.Join(" | ", itemValues), itemValues[1] == "Pociag" ? ConsoleColor.Green : ConsoleColor.DarkGray);
                }
                Console.Write("\n");
            }
        }

        public override void Create()
        {
            Console.Clear();
            PrintTrains();

            Timetable timetable = new Timetable(@"C:\Users\snowa\Desktop\PROJEKTY\Programowanie obiektowe 2023-2024\w67166_OP\Data\routes.txt");
            timetable.PrintTimetable();

            GUI.ColorText("Kreator nowego pociągu");

            string type;
            string trainNumber;

            do
            {
                GUI.ColorText("Typ: [Pociag/Wagon] > ", ConsoleColor.DarkGray, true);
                type = Console.ReadLine();
            } while (type != "Pociag" && type != "Wagon");

            if (type == "Wagon")
            {
                string attached;
                string passangersCount;

                GUI.ColorText("Numer wagonu > ", ConsoleColor.DarkGray, true);
                trainNumber = Console.ReadLine();

                GUI.ColorText("ID pociągu > ", ConsoleColor.DarkGray, true);
                attached = Console.ReadLine();

                GUI.ColorText("Ilość miejsc > ", ConsoleColor.DarkGray, true);
                passangersCount = Console.ReadLine();

                string[] line = { FormatData([type, trainNumber, attached, passangersCount, "nd", "nd"]) };
                AppendToFile(line);
            }
            else
            {
                string peron;
                string routeId;

                GUI.ColorText("Numer pociągu > ", ConsoleColor.DarkGray, true);
                trainNumber = Console.ReadLine();

                GUI.ColorText("ID trasy > ", ConsoleColor.DarkGray, true);
                routeId = Console.ReadLine();

                GUI.ColorText("Peron przyjazdu > ", ConsoleColor.DarkGray, true);
                peron = Console.ReadLine();

                string[] line = { FormatData([type, trainNumber, "nd", "nd", routeId, peron]) };
                AppendToFile(line);
            }
        }

        public override string[] Read()
        {
            return File.ReadAllLines(filename);
        }

        public override void Delete()
        {
            GUI.ColorText("Wprowadź ID pociągu do usunięcia > ", ConsoleColor.DarkGray, true);
            string id = Console.ReadLine();

            DeleteHelper(id);
        }
    }
}
