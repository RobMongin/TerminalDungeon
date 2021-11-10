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
        public bool continueToRun = true;
        public int playerWeapons = 0;
        public int playerArmor = 0;
        public int playerSpeedPotions = 0;

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
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
            bool encounterComplete = false;

            while (encounterComplete == false)
            {
                if (currentRoom.StatusEffect == true)
                {
                    switch (currentRoom.Name)
                    {
                        case "Treasure Room":
                            Console.WriteLine("You found a treasure room! What luck!");
                            break;

                        case "Clearing":
                            Console.WriteLine("The air feels nice in the open field.");
                            currentPlayer.Speed = currentPlayer.Speed + 5;
                            break;

                        case "Poison Mushrooms":
                            Console.WriteLine("You're surrounded by poison mushrooms. You feel ill. Lose 5hp.");
                            currentPlayer.Health = currentPlayer.Health - 5;
                            Console.ReadLine();
                            Console.WriteLine("Your new life total is: " + currentPlayer.Health);
                            Console.ReadLine();
                            break;

                        case "DeepMud":
                            Console.WriteLine("It must have rained recently. You feel slow in the mud.");
                            currentPlayer.Speed = currentPlayer.Speed - 5;
                            Console.ReadLine();
                            break;
                        
                        case "Small Cave":
                            Console.WriteLine("You've stumbled into a dark cave. It's hard to see.");
                            if (playerArmor >= 1)
                            {
                                Console.WriteLine("It's dark. You dropped a weapon and can't find it");
                                playerWeapons--;
                                currentPlayer.Damage = currentPlayer.Damage - 10;
                            }
                            else { }
                            break;

                        case "Heavy Fog":
                            Console.WriteLine("A heavy fog is rolling in. Watch your step!");
                            if (playerArmor >= 1)
                            {
                                Console.WriteLine("You lost a piece of your armor! You can't seem to find it.");
                                currentPlayer.Health = currentPlayer.Health - 15;
                                Console.ReadLine();
                                Console.WriteLine("You're more vulnerable now and have " + currentPlayer.Health + " life left");
                            }
                            break;
                              
                        default:
                            Console.WriteLine("game broken");
                            break;
                    }
                }
                else if (currentRoom.StatusEffect == false)
                {
                    switch (currentRoom.Name)
                    {
                        case "Treasure Room":
                            Console.WriteLine("You found a treasure room! What luck!");
                            break;

                        case "Clearing":
                            Console.WriteLine("The air feels nice in the open field.");
                            currentPlayer.Speed = currentPlayer.Speed + 5;
                            break;
                        default:
                            Console.WriteLine("game broken");
                            break;
                    }
                }
                if (currentRoom.HasEnemy == true)
                {
                    Console.WriteLine("A " + currentEnemy.Name + " has appeared!");
                    Console.ReadLine();

                }
                else
                {
                    //you find items
                }
            }
        }
    }
}
