using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHP
{
    public abstract class Entity : INotifyPropertyChanged
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
        public int MaxHealthPoints { get { return maxHealthPoints; } 
            set {
                if (!Equals(value, maxHealthPoints))
                {
                    maxHealthPoints = value;
                    OnCanviDinsDeLaPropietat();
                }
            } 
        }
        public int HealthPoints { get{ return healthPoints; }
            set
            {
                if (!Equals(value, healthPoints))
                {
                    healthPoints = value;
                    OnCanviDinsDeLaPropietat();
                }
            }
        }
        public int Velocity { get{ return velocity; } set { velocity = value; } }
        public bool IsAlive => healthPoints > 0;
        public int Dmg => atack * (Level / 2);
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


        








    }
}
