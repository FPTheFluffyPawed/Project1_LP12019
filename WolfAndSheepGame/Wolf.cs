﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    class Wolf : Sheep
    {
        public Wolf(ConsoleColor color) : base(color)
        {
            Symbol = 'W';
            Color = color;
        }

        public override void Move(Board board)
        {
            Position destination;
            string aux;

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
