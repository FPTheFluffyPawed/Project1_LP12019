using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    class Wolf : Sheep
    {
        public Wolf(ConsoleColor color ) : base(color)
        {
            Symbol = 'W';
            Color = color;
        }
    }
}
