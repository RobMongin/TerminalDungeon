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

        private static Dictionary<string, Room> _rooms = new Dictionary<string, Room>
        {
            {"Treaure Room", new Room("Treasure Room!",false,false,true)},
            {"Poison Mushrooms", new Room("Mushroom Patch", true, true, true)},
            {"Deep Mud", new Room("Muddy Path", true, true, true)},
            {"Clearing", new Room("Clearing", false, true, false)},
            {"Small Cave", new Room("Small Cave", true, true, true)},
            {"Heavy Fog", new Room("Heavy Fog", true, false, false) } //lose an item
        };

        private static Dictionary<string, Enemy> _enemies = new Dictionary<string, Enemy>
        {
            {"Troll", new Enemy("Troll",40,20,5) },
            {"Centaur", new Enemy("Centaur",30,15,20) }
        };

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
                switch(userInput)
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
            GetEnemy();
            Console.ReadKey();
            
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

        private Room CreateRoom()
        {
            //Getting random number for room dictionary
            Random random = new Random();
            int randomKey = (random.Next(0, _rooms.Count()));

            //Getting dictionary element by random number
            KeyValuePair<string, Room> keyValuePair = _rooms.ElementAt(randomKey);
            Room generatedRoom = keyValuePair.Value;
            return generatedRoom;  
        }

        private Enemy GetEnemy()
        {
            //This is getting a random number between 0 and amount of _enemies
            Random random = new Random();
            int randomKey = (random.Next(0, _enemies.Count()));

            //Using random number to select enemy from Dictionary 
            KeyValuePair<string, Enemy> keyValuePair = _enemies.ElementAt(randomKey);
            Enemy generatedEnemy = keyValuePair.Value;
            Console.WriteLine(generatedEnemy.Name);
            Console.WriteLine(randomKey);
            return generatedEnemy;

        }

        private void CreateEncounter()
        {

        }
    }
}
