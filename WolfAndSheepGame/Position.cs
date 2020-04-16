using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    /// <summary>
    /// Position that is used when checking things in the Board.
    /// </summary>
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
    }
}
