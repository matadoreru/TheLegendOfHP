﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHP
{
    public abstract class Entity
    {
        protected int maxHealthPoints, atack, defence, velocity, level, healthPoints;
        protected bool isAlive;


        public Entity(int lvl)
        {
            level = lvl;
            maxHealthPoints = 15 * level;
            atack = 5* level;
            defence = 5* level;
            velocity = 5* level;
            healthPoints = MaxHealthPoints;
            isAlive = true;

        }


        public int Level { get { return level; } set { level = value; } }
        public int Atack { get { return atack; } set { atack = value; } }
        public int Defence { get { return defence; } set { defence = value; } }
        public int MaxHealthPoints { get { return maxHealthPoints; } set { maxHealthPoints = value; } }
        public int HealthPoints { get{ return healthPoints; } set { healthPoints = value; } }
        public int Velocity { get{ return velocity; } set { velocity = value; } }
        public bool IsAlive { get{ return isAlive; } set { isAlive = value; } }
        public int Dmg => atack * (Level / 2);

        public void substracHealth(int dmg)
        {
            HealthPoints = healthPoints - (dmg - defence);
            if (HealthPoints <= 0) IsAlive = false;
        }


        








    }
}
