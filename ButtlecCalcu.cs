using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class ButtlecCalcu
    {
        public bool Avoid(int accuracy, int evasion)
        {
            int ea = evasion - accuracy;
            Random accuracyRand = new Random();

            if (ea <= 0)
            {
                return false;
            }
            else
            {
                if(accuracyRand.Next(1,101) <= ea)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int DamageCalcu(int critical, int power)
        {
            Random criticalRand = new Random();
            Random powerRandmP = new Random();
            int powerRandom = power * powerRandmP.Next(90, 111) / 100;

            if(criticalRand.Next(1,101) <= critical)
            {
                Console.WriteLine("CriticalHit!!");
                return powerRandom * 2;
            }
            else
            {
                return powerRandom;
            }
        }
    }
}
