﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalDungeon.UI;

namespace TerminalDungeon
{
    public class ProgramUI
    {
        private readonly IConsole _console;

        public ProgramUI(IConsole console)
        {
            _console = console;
        }

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
            playerIsAlive = true;
            while (continueToRun == true)
            {
                Console.Clear();
                Console.WriteLine(
                 "Enter the number of the option you'd like to select and press Enter: \n" +
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
            CreateEncounter();
            Console.ReadKey();

        }

        private void GetPlayer()
        {
            Console.WriteLine("Enter a name for our hero and press Enter: ");
            currentPlayer.Name = Console.ReadLine();
            if (currentPlayer.Name == "")
            {
                Console.WriteLine("Our hero still needs a name!!!");
                StartGame();
            }
            else
            {
                Console.WriteLine(" Press Enter to play FeyWild");
            }
        }

        private void TitleScreen()
        {
            Console.WriteLine(@"
 _______  _______                   _________ _        ______  
(  ____ \(  ____ \|\     /||\     /|\__   __/( \      (  __  \ 
| (    \/| (    \/( \   / )| )   ( |   ) (   | (      | (  \  )
| (__    | (__     \ (_) / | | _ | |   | |   | |      | |   ) |
|  __)   |  __)     \   /  | |( )| |   | |   | |      | |   | |
| (      | (         ) (   | || || |   | |   | |      | |   ) |
| )      | (____/\   | |   | () () |___) (___| (____/\| (__/  )
|/       (_______/   \_/   (_______)\_______/(_______/(______/ 
                                                               
");
            Console.WriteLine("Press Enter to move through the program. /n" + "Some reminders have been left for you.");

            Console.ReadKey();
            Console.WriteLine("Welcome " + currentPlayer.Name + "!");
            Console.ReadKey();
            Console.WriteLine("FeyWild is a land of lights and wonder.");
            Console.ReadKey();
            Console.WriteLine("Be weary though, not all creatures are as friendly as the fairies");
            Console.ReadKey();
            Console.WriteLine("You will encounter many enemies and hazardous conditions.");
            Console.ReadLine();
            Console.WriteLine("This is an endless dungeon meaning it only ends when the player dies!");
            Console.ReadKey();
            Console.WriteLine("How far can you make it through FeyWild?");
            Console.WriteLine("Press Enter to start");
        }



        private void CreateEncounter()
        {
            Console.Clear();
            Console.WriteLine("Press Enter to move through the program.");

            Room currentRoom = new Room().CreateRoom();

            string userInput = Console.ReadLine();

            bool playerHasWeapon = false;
            bool playerHasArmor = false;
            bool removeWeapon = true;
            bool removeArmor = true;

            if (playerWeapons > 0)
            {
                playerHasWeapon = true;
            }

            if (playerArmor > 0)
            {
                playerHasArmor = true;
            }

            while (encounterComplete == false && playerIsAlive == true)
            {

                switch (currentRoom.Name)
                {
                    case "Treasure Room!":
                        {
                            Console.WriteLine("You found a treasure chest! What luck!");
                            Console.WriteLine("Press Enter to continue.");
                            roomsCompleted++;
                            Console.ReadLine();
                            RewardPlayer();
                        }
                        break;

                    case "Clearing":
                        Console.WriteLine("The air feels nice in the open field. You feel slightly faster");
                        currentPlayer.Speed = currentPlayer.Speed + 5;
                        Console.WriteLine("Press Enter to continue.");
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

                    case "Mushroom Patch":
                        Console.WriteLine("You're surrounded by poison mushrooms. You feel ill. Lose 10 Life.");
                        currentPlayer.Health = currentPlayer.Health - 10;
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        Console.WriteLine("Your new life total is: " + currentPlayer.Health);
                        Console.ReadLine();
                        if (currentPlayer.Health < 1)
                        {
                            playerIsAlive = false;
                            GameOver();
                        }
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
                            default:
                                Console.WriteLine("You must choose an option");
                                break;
                        }
                        break;

                    case "Muddy Path":
                        Console.WriteLine("It must have rained recently. You feel slow in the mud.");
                        currentPlayer.Speed = currentPlayer.Speed - 10;
                        Console.WriteLine("Press Enter to continue.");
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
                            default:
                                Console.WriteLine("You must choose an option");
                                break;
                        }
                        break;

                    case "Small Cave":
                        Console.WriteLine("You've stumbled into a dark cave. It's hard to see.");
                        if (playerHasWeapon == true && removeWeapon == true)
                        {
                            Console.WriteLine("It's dark. You dropped a weapon and can't find it");
                            playerWeapons--;
                            currentPlayer.Damage = currentPlayer.Damage - 10;
                            removeWeapon = false;
                        }
                        Console.WriteLine("Press Enter to continue.");
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
                            default:
                                Console.WriteLine("You must choose an option");
                                break;
                        }
                        break;

                    case "Heavy Fog":
                        Console.WriteLine("A heavy fog is rolling in. Watch your step!");
                        if (playerHasArmor == true && removeArmor == true)
                        {
                            Console.WriteLine("You lost a piece of your armor! You can't seem to find it.");
                            currentPlayer.Health = currentPlayer.Health - 10;
                            Console.ReadLine();
                            if (currentPlayer.Health < 1)
                            {
                                playerIsAlive = false;
                                GameOver();
                            }
                            Console.WriteLine("You're more vulnerable now and have " + currentPlayer.Health + " life left");
                            removeArmor = false;
                        }
                        Console.WriteLine("Press Enter to continue.");
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
                            default:
                                Console.WriteLine("You must choose an option");
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine(currentRoom.Name + " is broken");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void Hide()
        {
            Random dice = new Random();
            int randomDice = (dice.Next(1, 21));

            if (randomDice < 8)
            {
                roomsCompleted++;
                Console.WriteLine("You hid from the beast! Press any key to move on.");
                Console.ReadLine();
                CreateEncounter();
            }
            else
            {
                Console.WriteLine("The beast has fixated on you!!!");
                StartCombat();
            }
        }

        public void StartCombat()
        {
            Enemy currentEnemy = new Enemy().GetEnemy();

            int enemyHealth = currentEnemy.Health;

            Console.WriteLine("The beast sees you! Get prepared to fight a " + currentEnemy.Name + "!");
            Console.WriteLine(" Press Enter to continue");
            /*Console.WriteLine(currentEnemy.Health);
            Console.WriteLine(currentPlayer.Damage);*/
            Console.ReadLine();

            bool playerCanFight = true;
            bool enemyCanFight = true;

            while (playerCanFight == true && enemyCanFight == true)
            {
                int enemyRoll = Roll();
                int playerRoll = Roll();
                if (currentPlayer.Speed >= currentEnemy.Speed && playerRoll > 6 && enemyHealth > 0 && currentPlayer.Health > 0)
                {
                    enemyHealth = enemyHealth - currentPlayer.Damage;
                    Console.WriteLine("You struck the " + currentEnemy.Name + ". It has " + enemyHealth + " life left.");
                    Console.ReadLine();
                    if (enemyRoll > 9 && enemyHealth > 0)
                    {
                        currentPlayer.Health = currentPlayer.Health - currentEnemy.Attack;
                        Console.WriteLine("The " + currentEnemy.Name + " struck you. You have " + currentPlayer.Health + " life remaining.");
                        Console.ReadLine();
                    }
                    else if (enemyRoll < 9 && enemyHealth > 0)
                    {
                        Console.WriteLine("The " + currentEnemy.Name + " missed.");
                        Console.ReadLine();
                    }
                }
                else if (currentPlayer.Speed >= currentEnemy.Speed && playerRoll < 6 && enemyHealth > 0 && currentPlayer.Health > 0)
                {
                    Console.WriteLine("Your attack missed!");
                    Console.ReadLine();
                    if (enemyRoll > 9 && currentEnemy.Health > 0)
                    {
                        currentPlayer.Health = currentPlayer.Health - currentEnemy.Attack;
                        Console.WriteLine("The " + currentEnemy.Name + " struck you. You have " + currentPlayer.Health + " life remaining.");
                        Console.ReadLine();
                    }
                    else if (enemyRoll < 9 && enemyHealth > 0)
                    {
                        Console.WriteLine("The " + currentEnemy.Name + " missed.");
                        Console.ReadLine();
                    }
                }
                else if (currentEnemy.Speed > currentPlayer.Speed && enemyRoll > 9 && enemyHealth > 0 && currentPlayer.Health > 0)
                {
                    currentPlayer.Health = currentPlayer.Health - currentEnemy.Attack;
                    Console.WriteLine("The " + currentEnemy.Name + " struck you. You have " + currentPlayer.Health + " life remaining.");
                    Console.ReadLine();
                    if (playerRoll > 6 && currentPlayer.Health >= 1)
                    {
                        enemyHealth = enemyHealth - currentPlayer.Damage;
                        Console.WriteLine("You struck the " + currentEnemy.Name + ". It has " + enemyHealth + " life left.");
                        Console.ReadLine();
                    }
                    else if (playerRoll < 6 && currentPlayer.Health >= 1)
                    {
                        Console.WriteLine("Your attack missed!");
                        Console.ReadLine();
                    }
                }
                else if (currentEnemy.Speed > currentPlayer.Speed && enemyRoll < 9 && enemyHealth > 0 && currentPlayer.Health > 0)
                {
                    Console.WriteLine("The " + currentEnemy.Name + " missed.");
                    Console.ReadLine();
                    if (playerRoll > 6 && currentPlayer.Health >= 1)
                    {
                        enemyHealth = enemyHealth - currentPlayer.Damage;
                        Console.WriteLine("You struck the " + currentEnemy.Name + ". It has " + enemyHealth + " life left.");
                        Console.ReadLine();
                    }
                    else if (playerRoll < 6 && currentPlayer.Health >= 1)
                    {
                        Console.WriteLine("Your attack missed!");
                        Console.ReadLine();
                    }
                }
                else if (currentPlayer.Health < 1)
                {
                    playerIsAlive = false;
                    playerCanFight = false;
                    Console.WriteLine("the beast defeated you");
                    Console.ReadLine();
                    GameOver();
                }
                else if (enemyHealth < 1)
                {
                    roomsCompleted++;
                    encounterComplete = true;
                    enemyCanFight = false;
                    Console.WriteLine("you beat the " + currentEnemy.Name);
                    Console.ReadLine();
                    RewardPlayer();
                }
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
                        Console.WriteLine(" Press Enter to continue");
                        currentPlayer.Damage = currentPlayer.Damage + 10;
                        playerWeapons++;
                        Console.ReadLine();
                        rewardEarned = true;
                        encounterComplete = false;
                        CreateEncounter();
                        break;
                    case "armor":
                        Console.WriteLine("Congratulations!! You found new armor!");
                        Console.WriteLine(" Press Enter to continue");
                        currentPlayer.Health = currentPlayer.Health + 15;
                        playerArmor++;
                        Console.ReadLine();
                        Console.WriteLine("Your new Life Total is: " + currentPlayer.Health);
                        Console.ReadLine();
                        rewardEarned = true;
                        encounterComplete = false;
                        CreateEncounter();
                        break;
                    case "speedPotion":
                        Console.WriteLine("Congratulations!! You found a speed potion! Your speed stat increased!");
                        Console.WriteLine(" Press Enter to continue");
                        currentPlayer.Speed = currentPlayer.Speed + 5;
                        Console.ReadLine();
                        rewardEarned = true;
                        encounterComplete = false;
                        CreateEncounter();
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
            Console.WriteLine("You have died! You completed " + roomsCompleted + " rooms");
            Console.WriteLine(" Press Enter to go back to main menu");
            Console.ReadLine();
            RunMenu();
        }
    }
}

