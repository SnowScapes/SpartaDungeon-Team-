using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpartaDungeon_Team_
{
    internal class SaveLoad
    {
        
        string itemInfoPath = "ItemInfo.Json";
        public bool LoadPlayerInfo()
        {
            string playerInfoPath = "PlayerInfo.Json";
            while (true)
            {
                Console.Clear();
                Console.WriteLine(".____                       .___      ________                           ");
                Console.WriteLine("|    |     ____ _____     __| _/     /  _____/ _____     _____    ____   ");
                Console.WriteLine("|    |    /  _ \\\\__  \\   / __ |     /   \\  ___ \\__  \\   /     \\ _/ __ \\  ");
                Console.WriteLine("|    |___(  <_> )/ __ \\_/ /_/ |     \\    \\_\\  \\ / __ \\_|  Y Y  \\\\  ___/  ");
                Console.WriteLine("|_______ \\\\____/(____  /\\____ |      \\______  /(____  /|__|_|  / \\___  > ");
                Console.WriteLine("        \\/           \\/      \\/             \\/      \\/       \\/      \\/  ");
                Console.WriteLine("1. 1번 데이터 불러오기");
                Console.WriteLine("2. 2번 데이터 불러오기");
                Console.WriteLine("3. 3번 데이터 불러오기");
                Console.WriteLine("4. 돌아가기");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1: playerInfoPath = "Slot1PlayerInfo.Json"; break;
                    case ConsoleKey.D2: playerInfoPath = "Slot2PlayerInfo.Json"; break;
                    case ConsoleKey.D3: playerInfoPath = "Slot3PlayerInfo.Json"; break;
                    case ConsoleKey.D4: return false;
                }
                
                if (File.Exists(playerInfoPath))
                {
                    // PlayerInfo.Json 파일이 존재할 경우 캐릭터 정보 불러오기
                    string jsonText = File.ReadAllText(playerInfoPath);

                    JObject jsonObject = JObject.Parse(jsonText);

                    Program.PlayerData.Name = (string)jsonObject["name"];
                    Program.PlayerData.Job = (Jobs)(int)jsonObject["job"];
                    Program.PlayerData.Level = (int)jsonObject["level"];
                    Program.PlayerData.Attack = (float)jsonObject["attack"];
                    Program.PlayerData.Defense = (float)jsonObject["defense"];
                    Program.PlayerData.Critical = (float)jsonObject["critical"];
                    Program.PlayerData.Avoid = (float)jsonObject["avoid"];
                    Program.PlayerData.Health = (int)jsonObject["health"];
                    Program.PlayerData.Gold = (int)jsonObject["gold"];
                    Program.PlayerData.Potion = (int)jsonObject["potion"];
                    Program.PlayerData.Exp = (int)jsonObject["exp"];
                    LoadItemInfo();
                    return true;
                }
                else
                {
                    Console.WriteLine("\n저장 데이터가 존재하지 않습니다.");
                    Thread.Sleep(1000);
                }
            }
        }

        public void SavePlayerInfo()
        {
            
            JObject playerData = new JObject(
                new JProperty("name", Program.PlayerData.Name),
                new JProperty("job", Program.PlayerData.Job),
                new JProperty("level", Program.PlayerData.Level),
                new JProperty("attack", Program.PlayerData.Attack),
                new JProperty("defense", Program.PlayerData.Defense),
                new JProperty("health", Program.PlayerData.Health),
                new JProperty("gold", Program.PlayerData.Gold),
                new JProperty("potion", Program.PlayerData.Potion)
            );

            File.WriteAllText("test.json", playerData.ToString());
        }

        public void LoadItemInfo()
        {
            string jsonText = File.ReadAllText(itemInfoPath);

            Shop.Equipments = JsonConvert.DeserializeObject<Equipment[]>(jsonText);
        }
    }
}
