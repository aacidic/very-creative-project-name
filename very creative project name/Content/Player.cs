using System.Text.RegularExpressions;
using static very_creative_project_name.Ref;
using System;

namespace very_creative_project_name
{
    class Player
    {
        public void Name()
        {
            string name;
            bool creatingName = true;

            while (creatingName)
            {
                Console.Write("\nPlease enter a username.\nYou can only include alphanumeric characters and must be atleast three characters: ");
                name = Console.ReadLine();
                if (Regex.IsMatch(name, "^[a-zA-Z0-9]*$") && name.Length > 2)
                {
                    stats.playerName = name;
                    creatingName = false;
                }
                else
                {
                    Console.Write("That was invalid. Please try again.");
                }
            }
        }

        public void Create()
        {
            Name();
            Console.CursorVisible = false;
            Console.SetWindowSize(200, 50);
            Console.Clear();
            stats.firstLoop = true;
            map.Generate();
        }
    }
}