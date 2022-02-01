using System;
using System.Collections.Generic;
using System.Text;

namespace very_creative_project_name.Content.Player
{
    class CoreLoop
    {
        public string[] movementKeys = new string[] { "W", "A", "S", "D" };
        public void Choice()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            if (Array.Exists(movementKeys, key => key == keyPressed.Key.ToString()));
            {
                MovePlayer move = new MovePlayer(keyPressed);
            }
        }
    }
}
