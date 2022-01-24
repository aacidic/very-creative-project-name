using System;

namespace very_creative_project_name.Content.Text
{
    class ConsoleEdits
    {
        public string Colour(string colour)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour);
            return colour;
        }

        public string Title(string title)
        {
            Console.Title = title;
            return title;
        }
    }
}
