using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w67166_OP
{
    class Timetable : DatabaseManager
    {
        public Timetable(string name) : base(name) {}

        public void PrintTimetable(bool onlyActive = false)
        {
            GUI.ColorText("Aktualny rozkład jazdy");

            string[] items = Read();

            if (items.Length == 0)
            {
                GUI.ColorText("Aktualnie nie ma żadnych tras.\n", ConsoleColor.DarkGray);
            }
            else
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("N | Miasto | Przyjazd | Odjazd | Status");
                Console.WriteLine("=======================================");

                foreach (var item in items)
                {
                    string[] itemValues = item.Split(";");

                    if (onlyActive && itemValues[4] != "active")
                        continue;

                    GUI.ColorText(String.Join(" | ", itemValues), itemValues[4] == "active" ? ConsoleColor.Green : ConsoleColor.DarkGray);
                }
                Console.Write("\n");
            }
        }

        public override void Create()
        {
            Console.Clear();
            GUI.ColorText("Kreator nowego połączenia");

            GUI.ColorText("Przystanek docelowy > ", ConsoleColor.DarkGray, true);
            string destination = Console.ReadLine();

            GUI.ColorText("Przyjazd format:[XX:XX] > ", ConsoleColor.DarkGray, true);
            string arrival = Console.ReadLine();

            GUI.ColorText("Odjazd format:[XX:XX] > ", ConsoleColor.DarkGray, true);
            string departure = Console.ReadLine();

            // Save to file routes.txt
            string[] line = { FormatData([destination, arrival, departure]) };
            AppendToFile(line);
        }

        public override string[] Read()
        {
            return File.ReadAllLines(filename);
        }

        public override void Delete()
        {
            GUI.ColorText("Wprowadź ID trasy do usunięcia > ", ConsoleColor.DarkGray, true);
            string id = Console.ReadLine();

            DeleteHelper(id);
        }
    }
}
