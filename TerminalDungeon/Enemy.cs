using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalDungeon
{

    public class Enemy
    {
        private static Dictionary<string, Enemy> _enemies = new Dictionary<string, Enemy>
        {
            {"Troll", new Enemy("Troll",40,20,5) },
            {"Centaur", new Enemy("Centaur",30,15,20) }
        };

        public Enemy() { }
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

        public Enemy GetEnemy()
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
    }
}
