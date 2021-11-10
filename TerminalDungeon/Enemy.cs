using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalDungeon
{

    public class Enemy
    {
        private readonly Dictionary<string, Enemy> _enemies = new Dictionary<string, Enemy>
        {
            {"Troll", new Enemy("Bob",40,20,5) },
            {"Menotaur", new Enemy("Horse",30,15,20) },
            {"Treasure Room", new Enemy("Treasure",0,0,0) }
        };

        public Enemy(string name, int health, int attack, int speed)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Speed = speed;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public void GetEnemy()
        {
            Random random = new Random();
            Console.WriteLine(random.Next(0,4));
            int randomKey = random.Next(0, 4);

            KeyValuePair<string, Enemy> generatedEnemy = _enemies.ElementAt(randomKey);
            Console.WriteLine("You've encountered a mean looking " + generatedEnemy);


            //Picking random from dictionary
        }


    }

}
