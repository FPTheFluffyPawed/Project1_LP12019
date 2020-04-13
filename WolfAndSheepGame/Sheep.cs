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

        public bool CanMoveAtAll(Board board)
        {
            Position destination1, destination2;

            destination1 = new Position(Pos.X - 1, Pos.Y - 1);
            destination2 = new Position(Pos.X - 1, Pos.Y + 1);

            if (board.IsOccupied(destination1)
                && board.IsOccupied(destination2))
            {
                Console.WriteLine("This sheep can't be moved!");
                return false;
            }
            else
                return true;
        }

        public bool CanMoveToPlace(Board board, Position destination)
        {
            if (board.IsOccupied(destination))
            {
                Console.WriteLine("This sheep can't move there!");
                return false;
            }
            else
                return true;
        }

        public void Move(Board board)
        {
            Position destination;
            string aux;

            do
            {
                Console.WriteLine("Left or right? ('1' or '2')");
                aux = Console.ReadLine();
                switch (aux)
                {
                    case "1":
                        destination = new Position(Pos.X - 1, Pos.Y - 1);
                        if (CanMoveToPlace(board, destination))
                        {
                            board.MovePiece(this, destination);
                            Pos = destination;
                            break;
                        }
                        aux = null;
                        break;
                    case "2":
                        destination = new Position(Pos.X - 1, Pos.Y + 1);
                        if (CanMoveToPlace(board, destination))
                        {
                            board.MovePiece(this, destination);
                            Pos = destination;
                            break;
                        }
                        aux = null;
                        break;
                    default:
                        aux = null;
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            } while (aux == null);
        }
    }
}
