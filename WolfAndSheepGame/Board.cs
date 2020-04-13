using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    public class Board
    {
        // Variables.
        // We can say that the board is made up of sheeps, since these are our
        // players.
        private Sheep[,] board;

        // Create our board for use. For now, it'll be limited to 7,7 (8x8).
        public Board()
        {
            board = new Sheep[8, 8];
        }

        public void AssignPositions(int x, int y, Sheep sheep)
        {
            board[x, y] = sheep;
            sheep.Pos = new Position(x, y);
        }

        // Check if a board's position is occupied.
        public bool IsOccupied(Position pos)
        {
            // Check if the position is out of bounds of our board.
            if(pos.Y > board.GetLength(1) - 1 || pos.Y < 0 || pos.X > board.GetLength(0) || pos.X < 0)
                return true;
            else
                return board[pos.X, pos.Y] != null;
        }

        // Add a piece to a board's position.
        //public void AddPiece(Sheep piece)
        //{
        //    board[piece.Pos.X, piece.Pos.Y] = piece;
        //}

        public Sheep GetPieceAt(Position pos)
        {
            return board[pos.X, pos.Y];
        }

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
                    Position position = new Position(x, y);

                    if (IsOccupied(position))
                    {
                        //Console.BackgroundColor = ConsoleColor.DarkGray;
                        Sheep sheep = GetPieceAt(position);
                        Console.BackgroundColor = sheep.Color;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"{sheep.Symbol,2:1}");
                        Console.ResetColor();
                    }
                    else
                    {
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
