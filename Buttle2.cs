using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class Buttle2
    {
        public bool Avoid(int accuracy, int evasion, int power)
        {
            int ea = evasion - accuracy;
            Random accuracyRand = new Random();

            if (ea <= 0)
            {
                Console.WriteLine("빗나감!");
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
                    Console.WriteLine("빗나감!");
                    return false;
                }
            }
        }

        public int CriticalHit(int critical, int power)
        {
            Random criticalRand = new Random();

            if(criticalRand.Next(1,101) <= critical)
            {
                Console.WriteLine("CriticalHit!!");
                return power*2;
            }
            else
            {
                return power;
            }
        }
    }
}
