using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    /// <summary>
    /// The Sheep class that is the base for our pieces in the Board.
    /// </summary>
    public class Sheep
    {
        // Character to represent the sheep.
        public char Symbol { get; protected set; }

        // Color to represent the sheep.
        public ConsoleColor Color { get; set; }

        // The Sheep's position.
        public Position Pos { get; set; }

        /// <summary>
        /// The constructor that asks for a color and assigns 'S' to the
        /// Symbol.
        /// </summary>
        /// <param name="color">Color to represent this as.</param>
        public Sheep(ConsoleColor color)
        {
            Symbol = 'S';
            Color = color;
        }

        /// <summary>
        /// Method that checks if the piece can move at all!
        /// Used to avoid the player picking a piece that can't make any moves,
        /// sparing the trouble.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool CanMoveAtAll(Board board)
        {
            Position destination1, destination2;

            // Since this is a sheep, and they can only make two moves...
            // We'll only save two destinations and check them.
            destination1 = new Position(Pos.X - 1, Pos.Y - 1);
            destination2 = new Position(Pos.X - 1, Pos.Y + 1);

            // Check both positions to see if they're occupied.
            // If they're both occupied, this piece can't move!
            if (board.IsOccupied(destination1)
                && board.IsOccupied(destination2))
            {
                Console.WriteLine("This sheep can't be moved!");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Method that checks if the piece can move to a specific location.
        /// If it's occupied, it will return false, if not, true.
        /// </summary>
        /// <param name="board">Board to check.</param>
        /// <param name="destination">The place to move into.</param>
        /// <returns>True or false.</returns>
        public bool CanMoveToPlace(Board board, Position destination)
        {
            // Check if the piece is occupied.
            if (board.IsOccupied(destination))
            {
                Console.WriteLine("This piece can't move there!");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// The method that sorts out moving the piece in question.
        /// </summary>
        /// <param name="board">Board to make moves on.</param>
        public virtual void Move(Board board)
        {
            Position destination;
            string aux;

            // As long there isn't a valid option picked, it will keep asking
            // for one.
            do
            {
                Console.WriteLine("Up/Left (1) or Up/Right? (2)");
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
