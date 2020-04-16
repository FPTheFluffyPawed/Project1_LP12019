using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    /// <summary>
    /// Menu that handles the interface before playing the game.
    /// </summary>
    public class Menu
    {
        // The Dictionary is used to swap between menus.
        Dictionary<string, string> menus = new Dictionary<string, string>();

        // The List is used to save the current menu the user is in so we can
        // go back between the menus.
        List<string> historic = new List<string>();

        // Variable to check the current menu we're at.
        string currentMenu;

        // Create a new game.
        Game game = new Game();

        /// <summary>
        /// The constructor that starts the menu right away.
        /// </summary>
        public Menu()
        {
            MenuInterface();
        }

        /// <summary>
        /// The bulk of the Menu. It handles all options and visuals.
        /// This is where we can start the game, and exit the program.
        /// </summary>
        private void MenuInterface()
        {
            menus.Add("menu1", "1 - Start Game\n2 - Instructions\nb - Exit");
            menus.Add("menu2", "*** How does the game work? ***\n" +
                "\nWolf and Sheep is a PvP tabletop game." +
                "\nWhere one player controls the Wolf.\nWhile the other" +
                " player controls four sheep." +
                "\nBoth Wolf and Sheep move one square per turn." +
                "\nSheep chooses which Sheep to move before moving." +
                "\n\nSheep can move diagonally and only forwards." +
                "\nWolf can move diagonally, but forwards and backwards.\n" +
                "\nWolf picks where to start and goes first." +
                "\nSheep starts on the opposite end and goes second." +
                "\n\n*** Win conditions ***\n" +
                "\nWolf wins if they reach a sheep's starting position." +
                "\nSheep wins if they block wolf's movement.\n" +
                "\nb - Back");

            currentMenu = "menu1";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Wolf And Sheep Game");
                Console.ResetColor();
        
                Console.WriteLine(menus[currentMenu]);
                switch (Console.ReadLine())
                {
                    // This option will start the game.
                    case "1":
                        Console.WriteLine("\n*** Game is starting! ***\n");
                        game.Play();
                        Console.WriteLine("\n*** Game is over! ***\n");
                        break;

                    // Open the instructions menu.
                    case "2":
                        if (currentMenu == "menu1")
                        {
                            historic.Add(currentMenu);
                            currentMenu = "menu2";
                        }
                        break;
                    
                    // Exit the game, if we're at the top level of our menu.
                    case "b":
                        if (currentMenu == "menu1")
                        {
                            System.Environment.Exit(1);
                        }
                        currentMenu = historic[historic.Count - 1];
                        historic.RemoveAt(historic.Count - 1);
                        break;

                    // Always ask for a valid option while in the menu.
                    default:
                        Console.WriteLine("Insert a valid input!");
                        break;
                }
            }
        }   
    }
}