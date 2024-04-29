using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class Battle
    {
        MonsterInfo monsterInfo = new MonsterInfo();
        List<MonsterInfo> monsters;
        List<Monster> battleMonsters = new List<Monster>();
        int[] textMonsterIdx = new int[3] { 1, 2, 3 };

        public void BattleEntering()
        {
            bool notValid = false;
        Battle:
            Console.WriteLine("Battle!!");
            Console.WriteLine();

            //배틀 몬스터 정보 불러오기
            for (int i = 0; i< textMonsterIdx.Length; i++)
            {
                battleMonsters.Add(monsterInfo.getMonsterInfo(i));
            }
            foreach(var monsterIdx in battleMonsters)
            {
                Console.WriteLine("Lv.{0} {1} HP{2}", monsterIdx.level, monsterIdx.name, monsterIdx.hp);
            }
            Console.WriteLine();
            Console.WriteLine("[내정보]");
            //플레이어 레벨, 직업, 체력
            Console.WriteLine();

            Console.WriteLine("1. 공격");
            Console.WriteLine();
            if(notValid)
            {
                Console.WriteLine("잘못된 입력 입니다.");
                notValid = false;
            }
            Console.WriteLine("대상을 선택해주세요.");
            Console.Write(">>");
            int inputMeum = int.Parse(Console.ReadLine());
            switch(inputMeum)
            {
                case 1: BattlePhase(inputMeum); goto Battle;
                default: goto Battle;
            }
        }

        private void BattlePhase(int battleMonsterIdx)
        {
            bool notValid = false;
        Battle:
            Console.WriteLine("플레이어 공격!!");
            Console.WriteLine();
            Console.WriteLine("{0} 의 공격!"); // 플레이어 이름
            Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. {데미지 : {2}"); // 몬스터 레벨, 이름, 데미지
            Console.WriteLine();
            Console.WriteLine("Lv.{0} {1}");//몬스터 레벨, 이름
            Console.WriteLine("HP {0} -> {1}");
            Console.WriteLine();
            if (notValid)
            {
                Console.WriteLine("잘못된 입력 입니다.");
                notValid = false;
            }
            Console.WriteLine("0. 다음");
            Console.WriteLine();
            Console.Write(">>");
            switch (Console.ReadLine())
            {
                case "0":  break;
                default: goto Battle;
            }
        }
    }
}
