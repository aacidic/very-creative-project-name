using System;
using static very_creative_project_name.Ref;

namespace very_creative_project_name
{
    class StartGame
    {
        static void Main()
        {
            Player player = new Player();
            bool saveExists = save.DoesSaveExist();
            if (saveExists)
            {
                save.LoadData();
            }

            Console.Clear();
            Console.SetCursorPosition(0, 3);
            edit.Colour("DarkRed");
            Console.WriteLine(edit.Format("When you press ENTER, your window will be resized to the required size before continuing."));
            Console.WriteLine(edit.Format("     Changing this has a high risk of affecting or breaking the gameplay experience!     "));
            edit.Colour("Red");
            Console.WriteLine(edit.Format("    NOTE: If you ever experience this issue, it can be fixed if you re-open the game.\n\n "));
            edit.Colour("Blue");
            disp.Help(false);
            Console.ReadLine();

            player.Create();
        }
    }
}
