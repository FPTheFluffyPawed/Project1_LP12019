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

        public Position Pos { get; set; }

        public Sheep(ConsoleColor color)
        {
            Symbol = 'S';
            Color = color;
        }

        public void Move(Board board)
        {
            Position destination;

            Console.WriteLine("Left or right? ('1' or '2')");
            string aux = Console.ReadLine();
            switch(aux)
            {
                case "1":
                    destination = new Position(Pos.X - 1, Pos.Y - 1);
                    board.MovePiece(this, destination);
                    Pos = destination;
                    break;
                case "2":
                    destination = new Position(Pos.X - 1, Pos.Y + 1);
                    board.MovePiece(this, destination);
                    Pos = destination;
                    break;
                default:
                    break;
            }
        }
    }
}
