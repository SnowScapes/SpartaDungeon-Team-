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
                Console.WriteLine(" _______                         ________                           ");
                Console.WriteLine(" \\      \\    ____ __  _  __     /  _____/ _____     _____    ____   ");
                Console.WriteLine(" /   |   \\ _/ __ \\\\ \\/ \\/ /    /   \\  ___ \\__  \\   /     \\ _/ __ \\  ");
                Console.WriteLine("/    |    \\\\  ___/ \\     /     \\    \\_\\  \\ / __ \\_|  Y Y  \\\\  ___/  ");
                Console.WriteLine("\\____|__  / \\___  > \\/\\_/       \\______  /(____  /|__|_|  / \\___  > ");
                Console.WriteLine("        \\/      \\/                     \\/      \\/       \\/      \\/  ");
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n원하시는 이름을 설정해주세요.");
                Console.Write(">> ");
                string nameInput = Console.ReadLine();
                if (nameInput != "")
                {
                    Program.PlayerData.Name = nameInput;
                    break;
                }
            }
            while (true) {
                int jobCode;
                Console.Clear();
                Console.WriteLine("직업을 선택해주세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 궁수");
                Console.WriteLine("3. 마법사");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1: jobCode = 1; break;
                    case ConsoleKey.D2: jobCode = 2; break;
                    case ConsoleKey.D3: jobCode = 3; break;
                    default:continue;
                }
                Console.Clear();
                Console.WriteLine("선택하신 직업({0})으로 진행하시겠습니까?", (Jobs)jobCode);
                Console.WriteLine("1. 예");
                Console.WriteLine("2. 아니오");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1: break;
                    case ConsoleKey.D2: continue;
                    default: continue;
                }
                Program.PlayerData.SetPlayerStat(jobCode);
                break;
            }
        }
    }
}
