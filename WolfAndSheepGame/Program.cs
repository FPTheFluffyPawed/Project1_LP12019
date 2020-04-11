using System;

namespace WolfAndSheepGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Console.WriteLine("\nBoard rendering...");
            board.Render();
        }
    }
}
