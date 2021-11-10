using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalDungeon
{

    class Program
    {
        public static Player currentPlayer = new Player();

        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Console.WriteLine("Title");
            Console.WriteLine("Enter your Name: ");
            currentPlayer.Name = Console.ReadLine();
            Console.WriteLine("maybe some text");

            if (currentPlayer.Name == "")
            {
                Console.WriteLine("Please enter your name: ");
            }
            else
            {
                Console.WriteLine("Welcome " + currentPlayer.Name + "\n" + "Press ENTER to continue");
                Console.ReadKey();
            }
            

        }
    }
}