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
            maxHealthPoints = 12 * level;
            atack = 3 * level;
            defence = 1 * level;
            velocity = 1 * level;
            healthPoints = MaxHealthPoints;
        }

        public int GivenExperience => 45 + 10 * Level;

    }
}
