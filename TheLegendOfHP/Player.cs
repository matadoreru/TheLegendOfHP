using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHP
{
    public class Player : Entity
    {
        int nEnemysDefeat = 0;
        int numberOfPotions = 0;
        int expTotal = 0;
        int maxExp = 100;
        public Player(int lvl) : base(lvl)
        {
            level = lvl;
            maxHealthPoints = 15 * level;
            atack = 4 * level;
            defence = 1 * level;
            velocity = 2 * level;
            healthPoints = MaxHealthPoints;
            isAlive = true;
            ExpTotal = 0;
        } 
        public int NumberOfPotions { get => numberOfPotions; set => numberOfPotions = value; }
        public int NEnemysDefeat { get => nEnemysDefeat; set => nEnemysDefeat = value; }
        public int ExpTotal { get => expTotal; set => expTotal = value; }
        public int MaxExp { get => maxExp + (this.Level * 10); set => maxExp = value; }
    }
}
