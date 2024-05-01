using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class Potion
    {
        public void UsePotion()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("포션을 사용하면 체력을 30 회복 할 수 있습니다. (남은 포션 : {0} )\n", Program.PlayerData.Potion);
                Console.WriteLine("1. 사용하기\n0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                switch (Console.ReadLine())
                {
                    case "0": exit = true; break;
                    case "1":
                        if (Program.PlayerData.Potion > 0) { recoverHealth(); Console.WriteLine("회복을 완료했습니다."); Thread.Sleep(1000); }
                        else { Console.WriteLine("포션이 부족합니다."); Thread.Sleep(1000); }; break;
                }
            }
        }

        private void recoverHealth()
        {
            Program.PlayerData.Potion--;
            Program.PlayerData.Health += 30;
            if (Program.PlayerData.Health > 100)
                Program.PlayerData.Health = 100;
        }
    }
}
