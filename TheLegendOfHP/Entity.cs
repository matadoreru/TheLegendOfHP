using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHP
{
    
    public abstract class Entity
    {
        protected int maxHealthPoints, atack, defence, velocity, level, healthPoints, probAtack, experience;
        protected bool isAlive;
        private Random r = new Random();


        public Entity(int lvl)
        {
            level = lvl;
            maxHealthPoints = 15 * level;
            atack = 1* level;
            defence = 1* level;
            velocity = 1* level;
            healthPoints = MaxHealthPoints;
            experience = 0;
            isAlive = true;
        }


        public int Level { get { return level; } set { level = value; } }
        public int Atack { get { return atack; } set { atack = value; } }
        public int Defence { get { return defence; } set { defence = value; } }
        public int MaxHealthPoints { get { return maxHealthPoints; } 
            set {
                maxHealthPoints = value;
                }
        }
        public int HealthPoints { get{ return healthPoints; }
            set
            {
                    healthPoints = value;
            }
        }
        public int Velocity { get{ return velocity; } set { velocity = value; } }
        public bool IsAlive => healthPoints > 0;
        public int Dmg {
            get {
                probAtack = r.Next(1,21);
                if(probAtack == 1) 
                    return 0;
                else if (probAtack == 20) 
                    return Atack * 2;
                else 
                    return Atack;
            }
        
        
        }

        public int MaxExperience => 100 + 10 * level;
        public int Experience { get { return experience; } set { experience = value; } }


        public int substracHealth(int dmg)

        {
            int damageDealt = 0;
            if(defence < dmg)
            {
                damageDealt = dmg - defence;
                HealthPoints = healthPoints - damageDealt;

            }
            return damageDealt;
        }

        
        public void addXP(int xp)
        {
            Experience = Experience + xp;
            while (Experience > MaxExperience) LevelUp();
        }

        private void LevelUp()
        {
            Experience = Experience - MaxExperience;
            Level++;

        }
    }
}
