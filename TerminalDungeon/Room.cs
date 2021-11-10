using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalDungeon
{


    public class Room
    {
        public Room(string name, bool statusEffect, bool enemyIsAlive, bool hasReward)
        {
            Name = name;
            StatusEffect = statusEffect;
            EnemyIsALive = enemyIsAlive;
            HasReward = hasReward;
        }
        public string Name { get; set; }
        public bool StatusEffect { get; set; }
        public bool EnemyIsALive { get; set; }
        public bool HasReward { get; set; }

     
    }
}

