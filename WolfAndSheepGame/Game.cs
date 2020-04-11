using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    class Game
    {

        private Board board = new Board();
        private Wolf wolf; 
        private Sheep sheep1;
        private Sheep sheep2;
        private Sheep sheep3;
        private Sheep sheep4;

        private int turn = 1;

        private Game()
        {
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
        private void Play()
        {   
            string Hdirection;
            string Vdirection;

            while (true)
            {

                if(turn == 0)
                {
                    Console.WriteLine("Its player 2 turn!");
                    Console.WriteLine("Witch sheep will you choose?");
                    Console.WriteLine("1- Red sheep");
                    Console.WriteLine("2- Yellow sheep");
                    Console.WriteLine("3- White sheep");
                    Console.WriteLine("4- Blue sheep");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            (Hdirection, Vdirection) = Directions();
                            sheep1.Move(Hdirection, Vdirection);
                            break;

                        case "2":
                            (Hdirection, Vdirection) = Directions();
                            sheep2.Move(Hdirection, Vdirection);
                            break;

                        case "3":
                            (Hdirection, Vdirection) = Directions();
                            sheep3.Move(Hdirection, Vdirection);
                            break;
                        case "4":
                            (Hdirection, Vdirection) = Directions();
                            sheep4.Move(Hdirection, Vdirection);
                            break;

                        default:
                            break;
                    }

                    turn = 1;
                }

                else if(turn == 1)
                {
                    Console.WriteLine("Its player 2 turn!");
                    (Hdirection, Vdirection) = Directions();
                    wolf.Move(Hdirection, Vdirection);

                    turn = 0;
                }

                //check for wolf win condition
                if (wolf.CheckWin == 1)
                {
                    Console.WriteLine("The Player 1 Won!!!");
                    break;
                }

                //check for wolf lose condition
                if (wolf.CheckLose == 1)
                {
                    Console.WriteLine("The Player 2 Won!!!");
                    break;
                }

            }
        }

    }
}
