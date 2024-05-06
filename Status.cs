using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class Status
    {
        MainScreen MainScreen = new MainScreen();
        Battle Battle = new Battle();

        public void StatusMenu()  //플레이어 상태창 
        {         
 
            while(true)
            {
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("Lv. {0}", Program.PlayerData.Level >= Program.PlayerData.MaxLevel ? $"{Program.PlayerData.Level.ToString("00")} [최고 레벨]" : Program.PlayerData.Level.ToString("00"));
                Console.WriteLine("{0} {1}", Program.PlayerData.Name, Program.PlayerData.Job);
                Console.WriteLine("공격력 : {0}{1}", Program.PlayerData.TotalAtk().ToString(), Program.PlayerData.Weapon.Name != null ? string.Format(" (+{0})", Program.PlayerData.Weapon.Stat) : "");
                Console.WriteLine("방어력 : {0}{1}", Program.PlayerData.TotalDef().ToString(), Program.PlayerData.Armor.Name != null ? string.Format(" (+{0})", Program.PlayerData.Armor.Stat) : "");
                Console.WriteLine("체  력 : {0}", Program.PlayerData.Health.ToString());
                Console.WriteLine("마  력 : {0}", Program.PlayerData.Mana.ToString());
                Console.WriteLine("Gold : {0} G", Program.PlayerData.Gold.ToString());
                Console.WriteLine("Exp : {0}", Program.PlayerData.Exp.ToString());
                Console.WriteLine("다음 레벨 업까지 필요한 Exp : {0}", Program.PlayerData.Level >= Program.PlayerData.MaxLevel ? "0" : (Program.PlayerData.RequireExp - Program.PlayerData.Exp).ToString());
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                switch (Console.ReadLine())
                {
                    case "0":
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }
}
