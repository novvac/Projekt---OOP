using System;
using w67166_OP;

namespace w67166_OP
{
    public class Program
    {
        public static void Main()
        {
            Environment.SetEnvironmentVariable("timetableFile", @"C:\Users\snowa\Desktop\PROJEKTY\Programowanie obiektowe 2023-2024\w67166_OP\Data\routes.txt");
            Environment.SetEnvironmentVariable("trainFile", @"C:\Users\snowa\Desktop\PROJEKTY\Programowanie obiektowe 2023-2024\w67166_OP\Data\trains.txt");
            Environment.SetEnvironmentVariable("userFile", @"C:\Users\snowa\Desktop\PROJEKTY\Programowanie obiektowe 2023-2024\w67166_OP\Data\");

            int selectedOption;

            do
            {
                List<string> options = new List<string> { "Użytkownik", "Administrator" };
                selectedOption = GUI.GetChoice("Wybierz typ konta", null, options);

                switch (selectedOption)
                {
                    case 0:
                        {
                            User user = new User();
                            user.Login();
                            break;
                        }
                    case 1:
                        {
                            Admin admin = new Admin();
                            admin.Login();
                            break;
                        }
                }
            } while (selectedOption > -1);
        }
    }
}