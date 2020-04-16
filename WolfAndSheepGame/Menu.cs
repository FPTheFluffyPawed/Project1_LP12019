using System;
using System.Collections.Generic;
using System.Text;

namespace WolfAndSheepGame
{
    class Menu
    {
        // The Dictionary is used to swap between menus.
        Dictionary<string, string> menus = new Dictionary<string, string>();

        // The List is used to save the current menu the user is in so we can
        // go back between the menus.
        List<string> historic = new List<string>();
        string currentMenu;

        Game game = new Game();

        public Menu()
        {
            MenuInterface();
        }

        private void MenuInterface()
        {
            menus.Add("menu1", "1 - Start Game\n2 - Instructions\nb - Exit");
            menus.Add("menu2", "===How does the game work?===\nWolf and Sheep is a" + 
            " PVP game where one player controls the one wolf and the other" +
            " player controls 4 sheep. The player controlling the wolf has to" +
            " reach one of the original sheep squares, while the sheep player" +
            " has to stop that from happening blocking the wolf movement options"
            + "\n------General Rules------\nThe sheep moves diagonally," +
            " forward one square per turn.\nThe wolf moves diagonally," +
            " forward or backward, one square per turn.\nThe purple sheep is refered with the number 1\n - Back");

            currentMenu = "menu1";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Wolf And Sheep Game");
                Console.ResetColor();
        
                Console.WriteLine(menus[currentMenu]);
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\n*** Game is starting! ***\n");
                        game.Play();
                        Console.WriteLine("\n*** Game is over! ***\n");
                        break;
                    case "2":
                        if (currentMenu == "menu1")
                        {
                            historic.Add(currentMenu);
                            currentMenu = "menu2";
                        }
                        break;
                    
                    case "b":
                        if (currentMenu == "menu1")
                        {
                            System.Environment.Exit(1);
                        }
                        currentMenu = historic[historic.Count - 1];
                        historic.RemoveAt(historic.Count - 1);
                        break;

                    default:
                        Console.WriteLine("Insert a valid input!");
                        break;
                }
            }
        }   
    }
}