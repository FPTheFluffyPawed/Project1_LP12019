using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    /// <summary>
    /// The Board class that handles all the pieces.
    /// </summary>
    public class Board
    {
        // We can say that the board is made up of sheeps, since these are our
        // players.
        private Sheep[,] board;

        // Create our board for use. For now, it'll be limited to 8 x 8.
        public Board()
        {
            board = new Sheep[8, 8];
        }

        /// <summary>
        /// Method to be called when adding pieces to the board.
        /// </summary>
        /// <param name="x">X.</param>
        /// <param name="y">Y.</param>
        /// <param name="sheep">The piece to add.</param>
        public void AssignPositions(int x, int y, Sheep sheep)
        {
            board[x, y] = sheep;
            sheep.Pos = new Position(x, y);
        }

        // Check if a board's position is occupied.
        public bool IsOccupied(Position pos)
        {
            // Check if the position is out of bounds of our board.
            if(pos.Y > board.GetLength(1) - 1 || pos.Y < 0
                || pos.X > board.GetLength(0) || pos.X < 0)
                return true;
            // Else check if the position is not null.
            else
                return board[pos.X, pos.Y] != null;
        }

        /// <summary>
        /// Get the piece at the position.
        /// </summary>
        /// <param name="pos">Position to check.</param>
        /// <returns>Returns the piece in that position.</returns>
        public Sheep GetPieceAt(Position pos)
        {
            return board[pos.X, pos.Y];
        }

        /// <summary>
        /// The movement method that moves a sheep and clears its origin.
        /// Must be used with a check to see if the position is occupied.
        /// </summary>
        /// <param name="sheep">The piece to move.</param>
        /// <param name="position">The destination position.</param>
        public void MovePiece(Sheep sheep, Position position)
        {
                    // Place sheep there.
                    board[position.X, position.Y] = sheep;

                    // Remove origin.
                    board[sheep.Pos.X, sheep.Pos.Y] = null;
        }

        // Render out the board.
        public void Render()
        {
            for(int x = 0; x < board.GetLength(0); x++)
            {
                for(int y = 0; y < board.GetLength(1); y++)
                {
                    // Variable to be used for checking if there's a piece.
                    Position position = new Position(x, y);

                    // If there's a piece in the position, render it out
                    // differently.
                    if (IsOccupied(position))
                    {
                        // Get the piece at the position...
                        Sheep sheep = GetPieceAt(position);
                        // Get the piece's color...
                        Console.BackgroundColor = sheep.Color;
                        // Set the font color as black...
                        Console.ForegroundColor = ConsoleColor.Black;
                        // Write out its symbol...
                        Console.Write($"{sheep.Symbol,2:1}");
                        // And reset the color.
                        Console.ResetColor();
                    }
                    // If there's no piece there...
                    else
                    {
                        // Render out a normal black-white checkered board.
                        if ((x + y) % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
