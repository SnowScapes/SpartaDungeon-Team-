using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class Intro
    {
        NewPlayer newPlayer = new NewPlayer();

        public void IntroScreen(SaveLoad _saveLoad)
        {
            bool gameStart = false;
            while (!gameStart)
            {
                Console.Clear();
                Console.WriteLine("=============================================================================================");
                Console.WriteLine("|     _                                   _____                                             |");
                Console.WriteLine("|    | |                     _           (____ \\                                            |");
                Console.WriteLine("|     \\ \\  ____   ____  ____| |_  ____    _   \\ \\ _   _ ____   ____  ____ ___  ____         |");
                Console.WriteLine("|      \\ \\|  _ \\ / _  |/ ___)  _)/ _  |  | |   | | | | |  _ \\ / _  |/ _  ) _ \\|  _ \\        |");
                Console.WriteLine("|  _____) ) | | ( ( | | |   | |_( ( | |  | |__/ /| |_| | | | ( ( | ( (/ / |_| | | | |       |");
                Console.WriteLine("| (______/| ||_/ \\_||_|_|    \\___)_||_|  |_____/  \\____|_| |_|\\_|| |\\____)___/|_| |_|       |");
                Console.WriteLine("|         |_|                                                (_____|                        |");
                Console.WriteLine("=============================================================================================");
                Console.WriteLine("                                +-+-+ +-+-+-+ +-+-+-+-+");
                Console.WriteLine("                                |1|.| |N|e|w| |G|a|m|e|");
                Console.WriteLine("                                +-+-+ +-+-+-+-+ +-+-+-+-+");
                Console.WriteLine("                                |2|.| |L|o|a|d| |G|a|m|e|");
                Console.WriteLine("                                +-+-+ +-+-+-+-+ +-+-+-+-+");
                Console.WriteLine("                                |3|.| |E|x|i|t| |G|a|m|e|");
                Console.WriteLine("                                +-+-+ +-+-+-+-+ +-+-+-+-+");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1: if (newPlayer.CreatePlayer()) gameStart = true; _saveLoad.LoadItemInfo() ; _saveLoad.LoadSkillList(); break;
                    case ConsoleKey.D2: if(_saveLoad.LoadPlayerInfo()) gameStart = true; break;
                    case ConsoleKey.D3: Environment.Exit(0); break;
                }
            }
        }
    }
}
