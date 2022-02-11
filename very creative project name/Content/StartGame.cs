﻿using System;

namespace very_creative_project_name
{
    class StartGame
    {
        public static Display disp = new Display();
        public static CoreLoop core = new CoreLoop();
        public static ConsoleEdits edit = new ConsoleEdits();
        public static Properties prop = new Properties();

        static void Main()
        {      
            edit.Title("title");
            edit.Colour("DarkRed");
            Console.WriteLine("When you press ENTER, your window will be resized to the recommended size before continuing." +
                "\nChanging this has a high risk of affecting or breaking your gameplay experience!" +
                "\nNOTE: If you ever experience this issue, it can be fixed if you re-open the game.");
            Console.ReadLine();
            edit.Colour("Blue");

            //Clear console and resize window
            Console.CursorVisible = false;
            Console.SetWindowSize(200, 50);
            Console.Clear();
            Map.Seed();
        }
    }
}
