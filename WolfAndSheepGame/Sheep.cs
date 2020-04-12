using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    public class Sheep
    {
        // Character to represent the sheep.
        public char Symbol { get; protected set; }

        // Color to represent the sheep.
        public ConsoleColor Color { get; set; }

        public Sheep(ConsoleColor color)
        {
            Symbol = 'S';
            Color = color;
        }

        /*public void Move(string, string)
        {
            
        }*/
    }
}
