using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalDungeon
{
    public class ProgramUI
    {
        public static Player currentPlayer = new Player();
        public bool playerIsAlive = true;

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                 "Enter the number of the option you'd like to select: \n" +
                 "1. New Game \n" +
                 "2. Exit Game");
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                    case "one":
                        StartGame();
                        break;
                    case "2":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number! Press any key to continue");
                        Console.ReadKey();
                        break;
                }

            }
        }
        private void StartGame()
        {
            GetPlayer();
            Console.ReadKey();
            TitleScreen();
            Console.ReadKey();
            while (playerIsAlive == true)
            {
                CreateEncounter();
            }
            else
            {
                //game over method
            }

        }

        private void GetPlayer()
        {
            Console.WriteLine("Enter a name for our hero: ");
            currentPlayer.Name = Console.ReadLine();
            if (currentPlayer.Name == "")
            {
                Console.WriteLine("Our hero still needs a name!!!");
                StartGame();
            }
            else
            {
                Console.WriteLine(" Press any key to enter FeyWild");
            }
        }

        private void TitleScreen()
        {
            Console.WriteLine("FeyWild");
            Console.ReadKey();
            Console.WriteLine("Welcome " + currentPlayer.Name + "!");
            Console.ReadKey();
            Console.WriteLine("FeyWild is a land of lights and wonder.");
            Console.ReadKey();
            Console.WriteLine("Be weary though, not all creatures are as friendly as the fairies");
            Console.ReadKey();
            Console.WriteLine("You will encounter many enemies and hazardous conditions.\n" + "How far can you make it through FeyWild?");
            Console.ReadKey();
            Console.WriteLine("Press any key to start");
        }



        private void CreateEncounter()
        {
            Room currentRoom = new Room().CreateRoom();
            Enemy currentEnemy = new Enemy().GetEnemy();

            if (currentRoom.StatusEffect == true)
            {
                
            }
        }
    }
}
