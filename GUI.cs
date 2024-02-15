using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w67166_OP
{
    internal class GUI
    {
        public static void ColorText(string text, ConsoleColor color = ConsoleColor.Yellow, bool inline = false)
        {
            Console.ForegroundColor = color;

            if (inline)
                Console.Write(text);
            else
                Console.WriteLine(text);

            Console.ResetColor();
        }

        public static int GetChoice(string? title, Action customCode, List<string> options)
        {
            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                customCode?.Invoke();

                if (title != null)
                    ColorText($"Menu: {title}\n");

                for (int i = 0; i < options.Count; i++)
                {
                    string checker = " ";

                    if (i == currentSelection)
                    {
                        checker = "X";
                    }

                    Console.WriteLine("[{0}] {1}", checker, options[i]);
                }

                GUI.ColorText("\nESC aby zakończyć", ConsoleColor.DarkGray);

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection > 0)
                                currentSelection -= 1;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection < options.Count - 1)
                                currentSelection += 1;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            currentSelection = -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter && currentSelection > -1);

            Console.CursorVisible = true;

            return currentSelection;
        }
    }
}
