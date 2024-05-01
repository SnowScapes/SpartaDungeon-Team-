using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class SaveLoad
    {
        string playerInfoPath = "PlayerInfo.Json";
        string itemInfoPath = "ItemInfo.Json";
        public void LoadPlayerInfo()
        {
            bool fileExist = File.Exists(playerInfoPath);

            if (fileExist)
            {
                // PlayerInfo.Json 파일이 존재할 경우 캐릭터 정보 불러오기
                string jsonText = File.ReadAllText(playerInfoPath);

                JObject jsonObject = JObject.Parse(jsonText);

                Program.PlayerData.Name = (string)jsonObject["name"];
                Program.PlayerData.Level = (int)jsonObject["level"];
                Program.PlayerData.Attack = (float)jsonObject["attack"];
                Program.PlayerData.Defense = (float)jsonObject["defense"];
                Program.PlayerData.Health = (int)jsonObject["health"];
                Program.PlayerData.Gold = (int)jsonObject["gold"];
                Program.PlayerData.Potion = (int)jsonObject["potion"];
                Stage.SetStageLevel((int)jsonObject["dungenLevel"]);
            }
            else
            {
                // PlayerInfo.Json 파일이 없을 경우 새로운 캐릭터 생성
                NewPlayer createNewPlayer = new NewPlayer();
                createNewPlayer.CreatePlayer();
            }
        }

        public void SavePlayerInfo()
        {
            JObject playerData = new JObject(
                new JProperty("name", Program.PlayerData.Name),
                new JProperty("level", Program.PlayerData.Level),
                new JProperty("attack", Program.PlayerData.Attack),
                new JProperty("defense", Program.PlayerData.Defense),
                new JProperty("health", Program.PlayerData.Health),
                new JProperty("gold", Program.PlayerData.Gold),
                new JProperty("potion", Program.PlayerData.Potion),
                new JProperty("dungenLevel", Stage.GetStageLevel())
            );

            File.WriteAllText(playerInfoPath, playerData.ToString());
        }

        public void LoadItemInfo()
        {
            string jsonText = File.ReadAllText(itemInfoPath);

            Shop.Equipments = JsonConvert.DeserializeObject<Equipment[]>(jsonText);
        }
    }
}
