using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    /// <summary>
    /// Wolf derived from Sheep. Works just like the sheep, with the added
    /// movement options.
    /// </summary>
    public class Wolf : Sheep
    {
        /// <summary>
        /// Constructor that asks for a color, and automatically assigns the
        /// symbol as 'W' for the Board.
        /// </summary>
        /// <param name="color">Color to represent Wolf as.</param>
        public Wolf(ConsoleColor color) : base(color)
        {
            Symbol = 'W';
            Color = color;
        }

        /// <summary>
        /// The Move method that sorts out movement, specific to Wolf.
        /// </summary>
        /// <param name="board">Board to make moves on.</param>
        public override void Move(Board board)
        {
            Position destination;
            string aux;

            // As long there isn't a valid option picked, this will keep
            // asking for an input.
            do
            {
                Console.WriteLine("Down/Right (1) or Down/Left (2)?");
                Console.WriteLine("Up/Left (3) or Up/Right (4)?");
                aux = Console.ReadLine();

                switch (aux)
                {
                    case "1":
                        destination = new Position(Pos.X + 1, Pos.Y + 1);
                        if (CanMoveToPlace(board, destination))
                        {
                            board.MovePiece(this, destination);
                            Pos = destination;
                            break;
                        }
                        aux = null;
                        break;
                    case "2":
                        destination = new Position(Pos.X + 1, Pos.Y - 1);
                        if (CanMoveToPlace(board, destination))
                        {
                            board.MovePiece(this, destination);
                            Pos = destination;
                            break;
                        }
                        aux = null;
                        break;
                    case "3":
                        destination = new Position(Pos.X - 1, Pos.Y - 1);
                        if (CanMoveToPlace(board, destination))
                        {
                            board.MovePiece(this, destination);
                            Pos = destination;
                            break;
                        }
                        aux = null;
                        break;
                    case "4":
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
