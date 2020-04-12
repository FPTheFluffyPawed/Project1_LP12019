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
            if (sheep.Symbol == 'W')
                board[x, y] = sheep;
            else
                board[x, y] = sheep;

            // Assign the beginning positions.
            // For now, wolf starts in a specific spot for testing purposes.
            //board[0, 4] = new Wolf();

            // Add the Sheeps.
            //board[7, 1] = new Sheep();
            //board[7, 3] = new Sheep();
            //board[7, 5] = new Sheep();
            //board[7, 7] = new Sheep();
        }

        // Check if a board's position is occupied.
        private bool IsOccupied(Position pos)
        {
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
