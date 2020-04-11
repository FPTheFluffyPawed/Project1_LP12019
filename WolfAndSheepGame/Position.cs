using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    public struct Position
    {
        // Variables.
        public int X { get; }

        public int Y { get; }

        // X and Y position assignment.
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Override to format the position.
        public override string ToString() => $"({X}, {Y})";
    }
}
