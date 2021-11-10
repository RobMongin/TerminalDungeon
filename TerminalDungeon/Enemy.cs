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
            {"Troll", new Enemy("Troll",35,20,5) },
            {"Centaur", new Enemy("Centaur",30,15,20) },
            {"Giant Toad", new Enemy("Giant Toad",20,20,5) },
            {"Chimera", new Enemy("Chimera", 30, 15, 25) },
            {"Treant", new Enemy("Treant",40,20,1) },
            {"Ogre", new Enemy("Ogre",35, 25, 5) },
            {"Witch", new Enemy("Witch", 20, 10, 25) },
            {"Savage Bear", new Enemy("Savage Bear",30, 20, 10) },
            {"Wild Boar", new Enemy("Wild Boar", 15, 10, 10) },
            {"Giant Snake", new Enemy("Giant Snake", 15, 15, 15) }
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
            return generatedEnemy;
        }
    }
}
