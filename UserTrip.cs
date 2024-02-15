using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w67166_OP
{
    class UserTrip : DatabaseManager
    {
        public UserTrip(string name) : base(name) { }

        public void PrintTrips()
        {
            Console.Clear();
            string[] items = Read();

            GUI.ColorText("Podróże");

            if (items.Length == 0)
            {
                GUI.ColorText("Brak podróży.\n", ConsoleColor.DarkGray);
            }
            else
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("N | Podróż do | Odjazd | Peron | Pociąg | Wagon | Numer miejsca | Status");
                Console.WriteLine("========================================================================");
                foreach (var item in items)
                {
                    string[] itemValues = item.Split(";");

                    GUI.ColorText(String.Join(" | ", itemValues), itemValues[1] == "Pociag" ? ConsoleColor.Green : ConsoleColor.DarkGray);
                }
                Console.Write("\n");
            }

            GUI.ColorText("Naciśnij przycisk aby kontyuować...", ConsoleColor.DarkGray, true);
            Console.ReadLine();
        }

        public override void Create()
        {
            Console.Clear();

            Timetable timetable = new Timetable(@"C:\Users\snowa\Desktop\PROJEKTY\Programowanie obiektowe 2023-2024\w67166_OP\Data\routes.txt");
            Train train = new Train(@"C:\Users\snowa\Desktop\PROJEKTY\Programowanie obiektowe 2023-2024\w67166_OP\Data\trains.txt");

            timetable.PrintTimetable(true);

            GUI.ColorText("Wprowadź ID trasy > ", ConsoleColor.DarkGray, true);
            string routeId = Console.ReadLine();

            string routeValues = timetable.Where(0, routeId).FirstOrDefault();
            string trainRef = train.Where(5, routeId).FirstOrDefault();

            if (trainRef != null)
            {
                string[] carriages = train.Where(3, trainRef.Split(';')[0]);
                string[] activeCarriages = DatabaseManager.Filter(carriages, 7, "active");

                Random r = new Random();
                string[] carriage = activeCarriages[r.Next(0, activeCarriages.Length - 1)].Split(';');

                int spot = r.Next(1, Convert.ToInt32(carriage[4]));
                string destination = routeValues.Split(';')[1];
                string arrival = routeValues.Split(';')[3];
                string trainNumber = trainRef.Split(';')[2];
                string peron = trainRef.Split(';')[6];
                string carriageNumber = carriage[2];

                GUI.ColorText($"\nZakup udany. Twój bilet do: {destination} odjeżdza z peronu {peron} o godzinie {arrival}.\nNumer pociągu: {trainNumber}. Numer wagonu: {carriageNumber}. Miejsce: {spot}\n", ConsoleColor.Green);
                GUI.ColorText("Naciśnij dowolny przycisk aby kontynuować...", ConsoleColor.DarkGray);

                string[] line = { FormatData([destination, arrival, peron, trainNumber, carriageNumber, spot.ToString()]) };
                AppendToFile(line);

                Console.ReadLine();
            }
        }

        public override string[] Read()
        {
            return File.ReadAllLines(filename);
        }

        public override void Delete()
        {}
    }
}
