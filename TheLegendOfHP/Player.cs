using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHP
{
    public class Player : Entity
    {
        public Player(int lvl) : base(lvl)
        {
            level = lvl;
            maxHealthPoints = 15 * level;
            atack = 4 * level;
            defence = 1 * level;
            velocity = 2 * level;
            healthPoints = MaxHealthPoints;
            isAlive = true;
        }
    }
}
