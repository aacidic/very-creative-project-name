using System;

namespace very_creative_project_name
{
    class ConsoleEdits
    {
        /// <summary>
        /// Modifies text colour of console window with string.
        /// </summary>
        /// <param name="colour">Colour to set text in console window</param>
        /// <returns>Colour as string, used for printing debug</returns>
        public string Colour(string colour)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colour);
            return colour;
        }

        /// <summary>
        /// All text parsed into this function centres it based on console window size.
        /// </summary>
        /// <param name="text">Text to center</param>
        /// <returns>Centered text</returns>
        public string Format(string text)
        {
            string formatText = string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text);
            return formatText;
        }
    }
}
