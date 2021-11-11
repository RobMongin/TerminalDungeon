using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalDungeon
{
    public class Player
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }

        public Player()
        {
            this.Health = 100;
            this.Damage = 10;
            this.Speed = 15;
            //setting default values for player
        }
        

    }
}