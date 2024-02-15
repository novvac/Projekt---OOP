using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w67166_OP
{
    class User : Account
    {
        private int accountId;

        public override void Login()
        {
            Console.Clear();
            GUI.ColorText("Witaj w panelu użytkownika. Zaloguj się poniżej.\n");

            Console.Write("Wprowadź ID: ");
            accountId = Convert.ToInt32(Console.ReadLine());

            string filename =  Environment.GetEnvironmentVariable("userFile") + $"{accountId}.txt";
            if (!File.Exists(filename))
            {
                using (StreamWriter w = File.AppendText(filename));
            }
            Welcome();
        }

        protected override void Welcome()
        {
            UserTrip userTrip = new UserTrip(Environment.GetEnvironmentVariable("userFile") + $"{accountId}.txt");

            do
            {
                List<string> options = new List<string> { "Kup bilet", "Moje podróże" };
                selectedOption = GUI.GetChoice($"Jesteś zalogowany jako użytkownik: {accountId}.", null, options);

                switch (selectedOption)
                {
                    case 0:
                        {
                            userTrip.Create();
                            break;
                        }
                    case 1:
                        {
                            userTrip.PrintTrips();
                            break;
                        }
                }
            } while (selectedOption > -1);
        }
    }
}
