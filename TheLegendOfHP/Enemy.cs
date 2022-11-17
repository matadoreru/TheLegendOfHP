using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHP
{
    public class Enemy : Entity
    {
        public Enemy(int lvl) : base(lvl)
        {
            level = lvl;
            maxHealthPoints = 9 * level;
            atack = 5 * level;
            defence = 3 * level;
            velocity = 5 * level;
            healthPoints = MaxHealthPoints;
            isAlive = true;
        }


    }
}
