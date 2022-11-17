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
            atack = 10 * level;
            defence = 5 * level;
            velocity = 5 * level;
            healthPoints = MaxHealthPoints;
            isAlive = true;
        }




    }
}
