using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    class Wolf : Sheep
    {
        public Wolf(ConsoleColor Color) : base(Color)
        {
            this.Color = Color;
            Symbol = 'W';
        }
    }
}
