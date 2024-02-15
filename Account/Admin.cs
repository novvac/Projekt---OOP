using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace w67166_OP
{
    class Admin : Account
    {
        private Timetable timetable = new Timetable(@"C:\Users\snowa\Desktop\PROJEKTY\Programowanie obiektowe 2023-2024\w67166_OP\Data\routes.txt");
        private Train train = new Train(@"C:\Users\snowa\Desktop\PROJEKTY\Programowanie obiektowe 2023-2024\w67166_OP\Data\trains.txt");

        public override void Login()
        {
            Welcome();
        }

        protected override void Welcome()
        {
            do
            {
                List<string> options = new List<string> { "Zarządzanie rozkładem jazdy", "Zarządzanie pociągami" };
                selectedOption = GUI.GetChoice($"Jesteś zalogowany jako administrator.", null, options);

                switch (selectedOption)
                {
                    case 0:
                        {
                            TimetableManagement();
                            break;
                        }
                    case 1:
                        {
                            TrainsManagement();
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                }
            } while (selectedOption > -1);
        }

        private void TimetableManagement()
        {
            int choice;

            do
            {
                List<string> options = new List<string> { "Dodaj nową trasę", "Usuń wybraną trasę" };
                choice = GUI.GetChoice(null, () => timetable.PrintTimetable(false), options);

                switch (choice)
                {
                    case 0:
                        {
                            timetable.Create();
                            break;
                        }
                    case 1:
                        {
                            timetable.Delete();
                            break;
                        }
                }
            } while (choice > -1);
        }

        private void TrainsManagement()
        {
            int choice;

            do
            {
                List<string> options = new List<string> { "Stwórz nowy pociąg", "Usuń wybrany pociąg" };
                choice = GUI.GetChoice(null, () => train.PrintTrains(), options);

                switch (choice)
                {
                    case 0:
                        {
                            train.Create();
                            break;
                        }
                    case 1:
                        {
                            train.Delete();
                            break;
                        }
                }
            } while (choice > -1);
        }
    }
}
