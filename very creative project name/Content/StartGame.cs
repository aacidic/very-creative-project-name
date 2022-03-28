using System;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class StartGame
    {
        static void Main()
        {      
            edit.Colour("DarkRed");
            Console.WriteLine("When you press ENTER, your window will be resized to the required size before continuing." +
                "\nChanging this has a high risk of affecting or breaking your gameplay experience!" +
                "\nNOTE: If you ever experience this issue, it can be fixed if you re-open the game or by pressing the map resize key.");
            edit.Colour("Blue");
            disp.Help(false);
            Console.ReadLine();

            //Clear console and resize window
            Console.CursorVisible = false;
            Console.SetWindowSize(200, 50);
            Console.Clear();
            map.Generate();
            
        }
    }
}
