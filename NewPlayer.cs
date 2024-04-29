using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class NewPlayer
    {
        public void CreatePlayer()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n원하시는 이름을 설정해주세요.");
                Console.Write(">> ");
                string nameInput = Console.ReadLine();
                if (nameInput != "")
                {
                    Program.PlayerData.Name = nameInput;
                    Program.PlayerData.SetPlayerStat();
                    break;
                }
            }
        }
    }
}
