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
        string playerInfoPath = "PlayerInfo.Json";
        string itemInfoPath = "ItemInfo.Json";
        public bool LoadPlayerInfo()
        {
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
                    case ConsoleKey.D1: playerInfoPath = "Slot1PlayerInfo.Json"; itemInfoPath = "Slot1ItemInfo.Json"; break;
                    case ConsoleKey.D2: playerInfoPath = "Slot2PlayerInfo.Json"; itemInfoPath = "Slot2ItemInfo.Json"; break;
                    case ConsoleKey.D3: playerInfoPath = "Slot3PlayerInfo.Json"; itemInfoPath = "Slot3ItemInfo.Json"; break;
                    case ConsoleKey.D4: itemInfoPath = "ItemInfo.Json"; return false;
                }
                
                if (File.Exists(playerInfoPath))
                {
                    // 아이템 및 인벤토리 정보 불러오기
                    LoadItemInfo();

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

                    // 장비 아이템 장착상태 불러오기
                    // json에 저장된 값이 null일 경우 장비 장착 해제
                    // 장착 해제의 경우 1번 슬롯에서 메뉴를 통해 3번 슬롯을 불러왔을 때를 위해
                    if ((int?)jsonObject["armor"] != null)
                        Program.PlayerData.Armor = Shop.Equipments[(int)jsonObject["armor"]];
                    else
                        Program.PlayerData.Armor = Program.PlayerData.UnEquip();

                    if ((int?)jsonObject["weapon"] != null)
                        Program.PlayerData.Weapon = Shop.Equipments[(int)jsonObject["weapon"]];
                    else
                        Program.PlayerData.Weapon = Program.PlayerData.UnEquip();

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
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("  _________                            ________                           ");
                Console.WriteLine(" /   _____/_____  ___  __  ____       /  _____/ _____     _____    ____   ");
                Console.WriteLine(" \\_____  \\ \\__  \\ \\  \\/ /_/ __ \\     /   \\  ___ \\__  \\   /     \\ _/ __ \\  ");
                Console.WriteLine(" /        \\ / __ \\_\\   / \\  ___/     \\    \\_\\  \\ / __ \\_|  Y Y  \\\\  ___/  ");
                Console.WriteLine("/_______  /(____  / \\_/   \\___  >     \\______  /(____  /|__|_|  / \\___  > ");
                Console.WriteLine("        \\/      \\/            \\/             \\/      \\/       \\/      \\/  ");
                Console.WriteLine("현재 슬롯 : {0}");
                Console.WriteLine("1. 1번 슬롯에 저장");
                Console.WriteLine("2. 2번 슬롯에 저장");
                Console.WriteLine("3. 3번 슬롯에 저장");
                Console.WriteLine("4. 나가기");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1: playerInfoPath = "Slot1PlayerInfo.Json"; itemInfoPath = "Slot1ItemInfo.Json"; break;
                    case ConsoleKey.D2: playerInfoPath = "Slot2PlayerInfo.Json"; itemInfoPath = "Slot2ItemInfo.Json"; break;
                    case ConsoleKey.D3: playerInfoPath = "Slot3PlayerInfo.Json"; itemInfoPath = "Slot3ItemInfo.Json"; break;
                    case ConsoleKey.D4: exit = true; continue;
                    default: continue;
                }
                
                if(File.Exists(playerInfoPath))
                {
                    Console.Clear();
                    Console.WriteLine("선택하신 슬롯에는 이미 저장데이터가 존재합니다.");
                    Console.WriteLine("저장하시겠습니까?");
                    Console.WriteLine("\n1. 예\n2. 아니오");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1: exit = true; break;
                        case ConsoleKey.D2: continue;
                        default: continue;
                    }
                }

                JObject playerData = new JObject(
                    new JProperty("name", Program.PlayerData.Name),
                    new JProperty("job", Program.PlayerData.Job),
                    new JProperty("level", Program.PlayerData.Level),
                    new JProperty("attack", Program.PlayerData.Attack),
                    new JProperty("defense", Program.PlayerData.Defense),
                    new JProperty("critical", Program.PlayerData.Critical),
                    new JProperty("avoid", Program.PlayerData.Avoid),
                    new JProperty("health", Program.PlayerData.Health),
                    new JProperty("gold", Program.PlayerData.Gold),
                    new JProperty("potion", Program.PlayerData.Potion),
                    new JProperty("exp", Program.PlayerData.Exp),
                    new JProperty("armor", Program.PlayerData.Armor.index),
                    new JProperty("weapon", Program.PlayerData.Weapon.index)
                );

                File.WriteAllText(playerInfoPath, playerData.ToString());
                SaveItemInfo();
                Console.WriteLine("저장이 완료되었습니다.");
                Thread.Sleep(2000);
            }
        }

        public void LoadItemInfo()
        {
            Inventory.MyItems.Clear();

            string jsonText = File.ReadAllText(itemInfoPath);

            Shop.Equipments = JsonConvert.DeserializeObject<Equipment[]>(jsonText);

            for (int i = 0; i < Shop.Equipments.Length; i++)
            {
                if (Shop.Equipments[i].Purchased)
                    Inventory.MyItems.Add(i);
            }
        }

        public void SaveItemInfo()
        {
            string jsonText = JsonConvert.SerializeObject(Shop.Equipments);
            File.WriteAllText(itemInfoPath, jsonText);
        }
    }
}
