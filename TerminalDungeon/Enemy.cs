using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalDungeon
{

    public class Enemy
    {
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


    }
}
