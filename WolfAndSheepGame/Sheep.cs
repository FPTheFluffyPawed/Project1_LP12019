using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    public class Sheep
    {
        // Character to represent the sheep.
        public char Symbol { get; protected set; }
        public ConsoleColor Color { get; set; }

        public Sheep(ConsoleColor Color)
        {
            this.Color = Color;
            Symbol = 'S';
        }

        /*public void Move(string, string)
        {
            
        }*/
    }
}
