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
        public bool encounterComplete = false;
        
        public int playerWeapons = 0;
        public int playerArmor = 0;
        public int roomsCompleted = 0;


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
                if(encounterComplete == false)
                {
                    CreateEncounter();
                }
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
            


            while (encounterComplete == false)
            {
                switch (currentRoom.Name)
                {
                    case "Treasure Room":
                        Console.WriteLine("You found a treasure room! What luck!");
                        Console.ReadLine();
                        Console.WriteLine("Enter the number of the item you'd like to take from the treasure room! \n" +
                            "1. Armor (Increases Life Total) \n" +
                            "2. Weapon (Increases Damage) \n" +
                            "3. Speed Potion (Increases Speed) \n");
                        string userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                playerArmor++;
                                currentPlayer.Health = currentPlayer.Health + 15;
                                Console.WriteLine(" You chose armor! You gain 15 health.");
                                Console.ReadLine();
                                Console.WriteLine("Your new life total is: " + currentPlayer.Health);
                                Console.ReadLine();
                                Console.WriteLine("Press any key to move on.");
                                Console.ReadLine();
                                roomsCompleted++;
                                encounterComplete = true;
                                break;
                            case "2":
                                playerWeapons++;
                                currentPlayer.Damage = currentPlayer.Damage + 10;
                                Console.WriteLine(" You chose a new weapon! You gain 10 damage.");
                                Console.ReadLine();
                                Console.WriteLine("Press any key to move on.");
                                Console.ReadLine();
                                roomsCompleted++;
                                encounterComplete = true;
                                break;
                            case "3":
                                currentPlayer.Speed = currentPlayer.Speed + 5;
                                Console.WriteLine(" You chose the speed potion! You have a higher chance of attacking first.");
                                Console.ReadLine();
                                Console.WriteLine("Press any key to move on.");
                                Console.ReadLine();
                                roomsCompleted++;
                                encounterComplete = true;
                                break;
                            default:
                                Console.WriteLine("Please pick a valid number between 1-3");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case "Clearing":
                        Console.WriteLine("The air feels nice in the open field. You feel slightly faster");
                        currentPlayer.Speed = currentPlayer.Speed + 5;
                        Console.ReadLine();
                        Console.WriteLine("You see something moving up ahead!");
                        Console.ReadLine();
                        Console.WriteLine("Would you like to: \n" +
                            "1. Attempt to Hide and move on without any potential loot \n" +
                            "2. Fight the beast");
                        userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                Hide();
                                break;
                            case "2":
                                StartCombat();
                                break;
                        }
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
                        if (playerWeapons >= 1)
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
        }
        public void Hide()
        {
            Random dice = new Random();
            int randomDice = (dice.Next(1, 21));

            if (randomDice <= 8)
            {
                Console.WriteLine("You hid from the beast! Press any key to move on.");
                Console.ReadLine();
                encounterComplete = true;
            }
            else
            {
                StartCombat();
            }
        }

        public void StartCombat()
        {
            Enemy currentEnemy = new Enemy().GetEnemy();

            Console.WriteLine("The beast sees you! Get prepared to fight a " + currentEnemy);
            Console.ReadLine();

            while(currentPlayer.Health > 0 && currentEnemy.Health > 0)
            {
                if (currentPlayer.Speed >= currentEnemy.Speed)
                {
                    int playerRoll = Roll();
                    if(playerRoll > 6)
                    {
                        currentEnemy.Health = currentEnemy.Health - currentPlayer.Damage;
                    }
                    else
                    {
                        Console.WriteLine("The " + currentEnemy + " evaded your attack!");
                    }
                }
                else
                {
                    if(currentPlayer.Speed < currentEnemy.Speed)
                    {
                        currentPlayer.Health = currentPlayer.Health - currentEnemy.Attack;
                    }
                    else
                    {
                        Console.WriteLine("The " + currentEnemy + " missed!");
                    }
                }
            }
            if(currentPlayer.Health <= 0)
            {
                playerIsAlive = false;
            }
            else if(currentEnemy.Health <= 0)
            {
                RewardPlayer();
            }
        }

        public void RewardPlayer()
        {
            string[] rewards = { "weapon", "armor", "speedPotion" };
            bool rewardEarned = false;

            Random random = new Random();
            int randomKey = (random.Next(0, rewards.Count()));
            string playerReward = rewards[randomKey];

            while (rewardEarned == false)
            {
                switch (playerReward)
                {
                    case "weapon":
                        Console.WriteLine("Congratulations!! You found a new weapon!");
                        currentPlayer.Damage = currentPlayer.Damage + 10;
                        playerWeapons++;
                        roomsCompleted++;
                        rewardEarned = true;
                        encounterComplete = true;
                        break;
                    case "armor":
                        Console.WriteLine("Congratulations!! You found new armor!");
                        currentPlayer.Health = currentPlayer.Health + 15;
                        playerArmor++;
                        Console.ReadLine();
                        Console.WriteLine("Your new Life Total is: " + currentPlayer.Health);
                        Console.ReadLine();
                        roomsCompleted++;
                        rewardEarned = true;
                        encounterComplete = true;
                        break;
                    case "speedPotion":
                        Console.WriteLine("Congratulations!! You found a speed potion! Your speed stat increased!");
                        currentPlayer.Speed = currentPlayer.Speed + 5;
                        Console.ReadLine();
                        roomsCompleted++;
                        rewardEarned = true;
                        encounterComplete = true;
                        break;
                    default:
                        Console.WriteLine("reward system broken");
                        break;
                }
            }

        }

        public int Roll()
        {
            Random random = new Random();
            int roll = random.Next(0, 21);
            return roll;
        }

        public void GameOver()
        {
            Console.WriteLine("You have died! You completed " + roomsCompleted);
            Console.ReadLine();
            RunMenu();
        }
    }
}


