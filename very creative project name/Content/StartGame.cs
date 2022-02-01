using System;
using very_creative_project_name.Content.Map;
using very_creative_project_name.Content.Text;

namespace TextProject
{
    class StartGame
    {
        public static Display disp = new Display();

        static void Main(string[] args)
        {      
            ConsoleEdits edit = new ConsoleEdits();
            edit.Title("title");
            edit.Colour("Blue");

            Console.WriteLine("When you press ENTER, your window will be resized to the recommended size before continuing.");
            Console.ReadLine();

            //Clear console and resize window
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 30);
            Console.Clear();
            Map.Seed();
        }
    }
}
