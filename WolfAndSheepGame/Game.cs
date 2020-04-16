using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    /// <summary>
    /// The Game class. It handles all gameplay logic.
    /// </summary>
    public class Game
    {
        // Create a board.
        private Board board = new Board();

        // Create our wolf and sheeps.
        private Wolf wolf = new Wolf(ConsoleColor.Red); 
        private Sheep sheep1 = new Sheep(ConsoleColor.Magenta);
        private Sheep sheep2 = new Sheep(ConsoleColor.Green);
        private Sheep sheep3 = new Sheep(ConsoleColor.Blue);
        private Sheep sheep4 = new Sheep(ConsoleColor.Yellow);

        /// <summary>
        /// This method just checks for every position on the last row and
        /// checks if there's a wolf in it.
        /// </summary>
        /// <returns>If the wolf reached it, true, else, false.</returns>
        private bool WinCondition()
        {
            for (int i = 0; i < 7; i++)
            {
                Position position = new Position(7,i);
                if (board.GetPieceAt(position) == wolf)
                {
                    Console.WriteLine("The wolf reached the end!\nPlayer 1 wins!");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if the Wolf's possible movement positions are
        /// occupied.
        /// </summary>
        /// <returns>True if all taken, false if one is available.</returns>
        private bool LoseCondition()
        {
            Position destination1, destination2, destination3, destination4;

            // All four destinations that the wolf can move.
            // Backwards and forwards.
            destination1 = new Position(wolf.Pos.X - 1, wolf.Pos.Y - 1);
            destination2 = new Position(wolf.Pos.X - 1, wolf.Pos.Y + 1);
            destination3 = new Position(wolf.Pos.X + 1, wolf.Pos.Y + 1);
            destination4 = new Position(wolf.Pos.X + 1, wolf.Pos.Y - 1);

            // If they're ALL occupied, wolf loses.
            // But if one isn't, wolf is still in the game!
            if (board.IsOccupied(destination1)
                && board.IsOccupied(destination2)
                && board.IsOccupied(destination3)
                && board.IsOccupied(destination4))
            {
                Console.WriteLine("The wolf can't move!\nPlayer 2 wins!");
                return true;
            }
            else
                return false;
        }
        
        /// <summary>
        /// Method that handles the turn logic between players.
        /// </summary>
        private void Turn()
        {
            // Input variable.
            string aux;

            // Turn counter.
            int turn = 0;

            while (true)
            {
                turn++;
                aux = null;

                // Render the board.
                board.Render();

                // Check win condition, which if either of these is true, we
                // break the loop to finish the game.
                if (WinCondition() || LoseCondition())
                    break;

                // Ask for input.
                // If 1, player 1's turn. If 2, player 2's turn.
                if(turn % 2 == 1)
                {
                    Console.WriteLine("\nPlayer 1, it's your turn!");
                    wolf.Move(board);
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Player 2, it's your turn!");
                        Console.WriteLine("Which sheep to move?");
                        Console.WriteLine("1 - Purple\n2 - Green\n3 - Blue" +
                            "\n4 - Yellow\n");
                        aux = Console.ReadLine();

                        aux = CheckMovement(aux);
                    } while (aux == null);
                }
            }
        }

        /// <summary>
        /// The method that checks if the selected sheep can move at all.
        /// Used to avoid the player from picking an immovable sheep.
        /// </summary>
        /// <param name="aux">The selected sheep.</param>
        /// <returns></returns>
        private string CheckMovement(string aux)
        {
            // Return aux as null to indicate that the selected option didn't
            // work.
            switch(aux)
            {
                case "1":
                    if(sheep1.CanMoveAtAll(board))
                    {
                        sheep1.Move(board);
                        return aux;
                    }
                    return aux = null;

                case "2":
                    if (sheep2.CanMoveAtAll(board))
                    {
                        sheep2.Move(board);
                        return aux;
                    }
                    return aux = null;

                case "3":
                    if (sheep3.CanMoveAtAll(board))
                    {
                        sheep3.Move(board);
                        return aux;
                    }
                    return aux = null;

                case "4":
                    if (sheep4.CanMoveAtAll(board))
                    {
                        sheep4.Move(board);
                        return aux;
                    }
                    return aux = null;

                default:
                    Console.WriteLine("Please select a valid option.");
                    return aux = null;
            }
        }

        /// <summary>
        /// The method to be called when starting the game.
        /// It will assign the sheep positions, and then ask for
        /// a wolf position.
        /// </summary>
        public void Play()
        {
            // The insert variable.
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
                Console.WriteLine("\nPlayer 1, assign your Wolf to one of " +
                "the possible positions on the first row!" +
                "\nOut of the four possible locations, select one." +
                "\n(From left to right: 1, 2, 3, 4.)");
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
        }
    }
}
