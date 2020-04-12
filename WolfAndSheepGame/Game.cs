using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    class Game
    {

        private Board board = new Board();
        private Wolf wolf = new Wolf(ConsoleColor.Gray); 
        private Sheep sheep1 = new Sheep(ConsoleColor.Red);
        private Sheep sheep2 = new Sheep(ConsoleColor.Yellow);
        private Sheep sheep3 = new Sheep(ConsoleColor.White);
        private Sheep sheep4 = new Sheep(ConsoleColor.Blue);

        //private int turn = 0;

        public Game()
        {
            //board.AssignPositions(3, 3, wolf);
            //
            //board.AssignPositions(7, 1, sheep1);
            //board.AssignPositions(7, 3, sheep2);
            //board.AssignPositions(7, 5, sheep3);
            //board.AssignPositions(7, 7, sheep4);
            //
            //board.Render();
        }
        private (string, string) Directions()
        {
            string Hdirection;
            string Vdirection;

            Console.WriteLine("Do you wish to move up or down?");
            Console.WriteLine("1- up");
            Console.WriteLine("2- down");
            Vdirection = Console.ReadLine();

            Console.WriteLine("Do you wish to move left or right?");
            Console.WriteLine("1- left");
            Console.WriteLine("2- right");
            Hdirection = Console.ReadLine();
            return (Hdirection, Vdirection);
        }

        private bool WinCondition()
        {
            for (int i = 0; i < 7; i++)
            {
                Position position = new Position(7,i);
                if (board.GetPieceAt(position) == wolf)
                    return true;
            }
            return false;
        }

        private bool LoseCondition()
        {
            return false;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    //
                    Position position = new Position(i,j);

                    //
                    Position position1 = new Position(i+1,j+1);

                    //
                    Position position2 = new Position(i+1,j-1);

                    //
                    Position position3 = new Position(i-1,j+1);

                    //
                    Position position4 = new Position(i-1,j-1);

                   if (board.GetPieceAt(position) == wolf)
                        //adsadadas 
                        if (board.GetPieceAt(position1) == null || board.GetPieceAt(position2) == null
                        || board.GetPieceAt(position3) == null || board.GetPieceAt(position4) == null)
                            return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Method that handles the turn logic between players.
        /// </summary>
        private void Turn()
        {
            int turn = 0;

            while (true)
            {
                turn++;

                // Render the board.
                board.Render();

                // Check win condition, which if either of these is true, we
                // break the loop to finish the game.
                if (WinCondition() || LoseCondition())
                    break;

                // Ask for input
                // If 1, player 1's turn. If 2, player 2's turn.
                if(turn % 2 == 1)
                {
                    Console.WriteLine("Player 1, it's your turn!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Player 2, it's your turn!");
                    Console.ReadLine();
                }
                // Process move
                // Repeat ->
            }
        }

        public void Play()
        {
            // Variables.
            string insert;

            // Assign sheep to their positions...
            board.AssignPositions(7, 1, sheep1);
            board.AssignPositions(7, 3, sheep2);
            board.AssignPositions(7, 5, sheep3);
            board.AssignPositions(7, 7, sheep4);

            // Render it out for players to see...
            board.Render();

            // Ask player 1 to place down their wolf in one of the four
            // possible spots...
            do
            {
                Console.WriteLine("\nPlayer 1, assign your Wolf to one of the" +
                "possible positions on the first row!" +
                "\nOut of the four possible locations, select one.");
                insert = Console.ReadLine();

                switch(insert)
                {
                    case "1":
                        board.AssignPositions(0, 0, wolf);
                        break;
                    case "2":
                        board.AssignPositions(0, 2, wolf);
                        break;
                    case "3":
                        board.AssignPositions(0, 4, wolf);
                        break;
                    case "4":
                        board.AssignPositions(0, 6, wolf);
                        break;
                    default:
                        insert = null;
                        Console.WriteLine("Please insert a valid position.");
                        break;
                }
            }
            while (insert == null);


            // Begin the game after that!
            Turn();


            //string Hdirection;
            //string Vdirection;
            //
            //while (true)
            //{
            //    turn++;
            //    if(turn % 2 == 0)
            //    {
            //        Console.WriteLine("Its player 2 turn!");
            //        Console.WriteLine("Witch sheep will you choose?");
            //        Console.WriteLine("1- Red sheep");
            //        Console.WriteLine("2- Yellow sheep");
            //        Console.WriteLine("3- White sheep");
            //        Console.WriteLine("4- Blue sheep");
            //        switch (Console.ReadLine())
            //        {
            //            case "1":
            //                (Hdirection, Vdirection) = Directions();
            //                //sheep1.Move(Hdirection, Vdirection);
            //                break;
            //
            //            case "2":
            //                (Hdirection, Vdirection) = Directions();
            //                //sheep2.Move(Hdirection, Vdirection);
            //                break;
            //
            //            case "3":
            //                (Hdirection, Vdirection) = Directions();
            //                //sheep3.Move(Hdirection, Vdirection);
            //                break;
            //            case "4":
            //                (Hdirection, Vdirection) = Directions();
            //                //sheep4.Move(Hdirection, Vdirection);
            //                break;
            //
            //            default:
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Its player 1 turn!");
            //        (Hdirection, Vdirection) = Directions();
            //        //wolf.Move(Hdirection, Vdirection);
            //    }
            //
            //    //check for wolf win condition
            //    if (WinCondition() == true)
            //    {
            //        Console.WriteLine("The Player 1 Won!!!");
            //        break;
            //    }
            //
            //   /* //check for wolf lose condition
            //    if (LoseCondition() == true)
            //    {
            //        Console.WriteLine("The Player 2 Won!!!");
            //        break;
            //    }*/
            //}
        }
    }
}
