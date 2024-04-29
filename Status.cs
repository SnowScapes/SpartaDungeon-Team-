using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class Status
    {
        bool NotValid = false;
        public void StatusMenu()  //플레이어 상태창 
        {
            notValid:      // 레이블 정의   프로그램의 실행 흐름을 제어하기 위해 사용
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine("Lv. " + Program.PlayerData.Level.ToString("00"));
            Console.WriteLine("{0} (전사)", Program.PlayerData.Name);
            Console.WriteLine("공격력 : {0}{1}", Program.PlayerData.TotalAtk().ToString(), Program.PlayerData.Weapon.Name != null ? string.Format(" (+{0})", Program.PlayerData.Weapon.value) : "");
            Console.WriteLine("방어력 : {0}{1}", Program.PlayerData.TotalDef().ToString(), Program.PlayerData.Armor.Name != null ? string.Format(" (+{0})", Program.PlayerData.Armor.value) : "");
            Console.WriteLine("체  력 : " + Program.PlayerData.Health.ToString());
            Console.WriteLine("Gold : {0} G",Program.PlayerData.Gold.ToString());
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            if (NotValid)     //잘못된 입력일 때 잘못된 입력 출력 및 화면 재출력
            {
                Console.WriteLine("잘못된 입력입니다.");
                NotValid = false;
            }
            Console.WriteLine("원하시는 행동을 입력해주세요 : ");
            Console.Write(">>");
            if (Console.ReadLine() != "0")
            {
                NotValid = true;
                goto notValid;     //notValid 레이블로 이동시키기
            }
        }
    }
}
