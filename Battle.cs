using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class Battle
    {
        Program program = new Program();
        ButtlecCalcu buttlecCalcu = new ButtlecCalcu();
        MonsterInfo monsterInfo = new MonsterInfo();
        public static List<Monster> battleMonsters = new List<Monster>();
        int[] testPlayer = new int[6] { 1, 10, 5, 100, 1500, 3 };
        int monsterExp = 0;   // 몬스터 경험치
        int playerHP;
        int monsterLifeCount = 0;
        int monsterConunt;
        int[] testMonsterIdx = new int[3] { 0, 1, 2 };
        bool isfirst = true;
        Player Player = new Player();
        
        
        public int MonsterTotalExp()  // 전투 중 잡은 몬스터 레벨의 총합을 monsterExp에 넣어주기
        {
            for (int i = 0; i < battleMonsters.Count; i++)
            {
                if (battleMonsters[i].isDeath)
                {
                    monsterExp += battleMonsters[i].level;
                }
                
            }
            return monsterExp;
        }
        public void GetExp(int _monsterExp)       // 경험치 얻기
        {
            Program.PlayerData.GainExp = _monsterExp;
            Program.PlayerData.Exp += Program.PlayerData.GainExp;


            if (Program.PlayerData.Exp >= Program.PlayerData.RequireExp)
            {
                Player.LevelUp();
            }

            if (Program.PlayerData.Level >= Program.PlayerData.MaxLevel)   // 최고 레벨 도달 시
            {
                // 현재 경험치 더 이상 안오르게 하기
                Program.PlayerData.Exp = 0;
            }
        }
        private Monster GetButtleMonsterInfo(int monsterIdx)
        {
            return battleMonsters[monsterIdx]; // 리스트에 없는 몬스터 선택 시 체크 필요
        }

        public void BattleEntering() // 전투 메뉴 입장
        {
            bool notValid = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine();

                //배틀 몬스터 정보 불러오기
                if (isfirst == true)
                {
                    for (int i = 0; i < testMonsterIdx.Length; i++)
                    {
                        monsterLifeCount++;
                        battleMonsters.Add(monsterInfo.GetMonsterInfo(testMonsterIdx[i]));
                    }
                }
                foreach (var monsterIdx in battleMonsters)
                {
                    if (monsterIdx.hp <= 0)
                    {
                        Console.WriteLine("Lv.{0} {1} Dead", monsterIdx.level, monsterIdx.name);
                    }
                    else
                    {
                        Console.WriteLine("Lv.{0} {1} HP{2}", monsterIdx.level, monsterIdx.name, monsterIdx.hp);
                    }
                }

                if (isfirst == true)
                {
                    monsterConunt = monsterLifeCount;
                    playerHP = Program.PlayerData.Health;
                    isfirst = false;
                }

                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv.{0} Chad (전사)", Program.PlayerData.Name);
                Console.WriteLine("HP {0}/{1}", Program.PlayerData.Health, playerHP);
                Console.WriteLine();
                if (notValid)
                {
                    Console.WriteLine("잘못된 입력 입니다.");
                    notValid = false;
                }
                Console.WriteLine("1. 공격");
                Console.Write(">>");
                int inputMeum = int.Parse(Console.ReadLine());
                switch (inputMeum)
                {
                    case 1: BattleSet(); return;
                    default: notValid = true; break;
                }
            }
            
        }

        private void BattleSet() // 전투 진행
        {
            int buttleIdx = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine();
                foreach (var monsterIdx in battleMonsters)
                {
                    buttleIdx++;
                    if (monsterIdx.hp <= 0)
                    {
                        Console.WriteLine("{0}. Lv.{1} {2} Dead", buttleIdx, monsterIdx.level, monsterIdx.name);
                    }
                    else
                    {
                        Console.WriteLine("{0}. Lv.{1} {2} HP {3}", buttleIdx, monsterIdx.level, monsterIdx.name, monsterIdx.hp);
                    }

                }
                buttleIdx = 0;
                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv.{0} {1} {2}", Program.PlayerData.Level, Program.PlayerData.Name, Program.PlayerData.Job);
                Console.WriteLine("HP {0}/{1}", Program.PlayerData.Health, playerHP);
                Console.WriteLine();
                Console.WriteLine("0. 취소");
                Console.WriteLine();
                Console.WriteLine("대상을 선택해주세요.");
                Console.Write(">>");
                int inputMenu = int.Parse(Console.ReadLine());
                switch (inputMenu)
                {
                    case 0: return;
                    default: BattlePhase(inputMenu - 1); break;
                }
            }
             //없는 몬스터 판단하는 부분 필요
            
        }


        private void BattlePhase(int battleMonsterIdx)
        {
            int monsterHP; // 해당 전투에서의 몬스터 HP
            bool isAtkP = false;
            

            Monster targetMonster = battleMonsters[battleMonsterIdx];
            monsterHP = targetMonster.hp;
            int playerAtk = buttlecCalcu.DamageCalcu((int)Program.PlayerData.Critical, (int)Program.PlayerData.TotalAtk());

            
            if (buttlecCalcu.Avoid((int)Program.PlayerData.Accuracy, targetMonster.avoid) == true)
            {
                monsterHP -= playerAtk;
                isAtkP = true;
            }
            else
            {
                playerAtk = 0;
            }
            

            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            Console.WriteLine("플레이어 공격!!");
            Console.WriteLine();
            Console.WriteLine("{0} 의 공격!", Program.PlayerData.Name); // 플레이어 이름
            if(isAtkP == true)
            {
                Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. (데미지 : {2})", targetMonster.level, targetMonster.name, playerAtk);
            }
            else
            {
                Console.WriteLine("빗나감!");
            }
            Console.WriteLine();
            Console.WriteLine("Lv.{0} {1}", targetMonster.level, targetMonster.name); //몬스터 레벨, 이름

            // 공격 결과 출력
            if (monsterHP <= 0)
                Console.WriteLine("HP {0} -> Dead", targetMonster.hp);
            else
                Console.WriteLine("HP {0} -> {1}\n", targetMonster.hp, monsterHP); // 공격력 만큼 뺀 채력

            targetMonster.GetDamage(playerAtk);

            Console.WriteLine("아무 키나 눌러 진행");
            Console.ReadKey();

            if (targetMonster.isDeath == false && targetMonster.hp <= 0)
            {
                monsterLifeCount--;
                targetMonster.SetDeath();
            }

            if (monsterLifeCount == 0) // 전투 종료 (승리)
            {
                EndPhase(1);
                return;
            }

            foreach (var monster in battleMonsters)
            {
                if (monster.isDeath == false)
                {
                    int monsterAkt = buttlecCalcu.DamageCalcu(0, monster.atk);
                    bool isAtkM = false;

                    if (buttlecCalcu.Avoid(targetMonster.accuracy, (int)Program.PlayerData.Avoid) == true)
                    {
                        playerHP = playerHP - monsterAkt;
                        isAtkM = true;
                    }

                    if (playerHP < 0)
                        playerHP = 0;

                    Console.Clear();
                    Console.WriteLine("Battle!!");
                    Console.WriteLine();
                    Console.WriteLine("몬스터 공격!!");
                    Console.WriteLine();
                    Console.WriteLine("Lv.{0} {1} 의 공격!", monster.level, monster.name);
                    if(isAtkM == true)
                    {
                        Console.WriteLine("{0} 을(를) 맞췄습니다. (데미지 : {1})", Program.PlayerData.Name, monsterAkt);
                    }
                    else
                    {
                        Console.WriteLine("빗나감!");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Lv.{0} {1}", Program.PlayerData.Level, Program.PlayerData.Name);
                    Console.WriteLine("HP {0} -> {1}", Program.PlayerData.Health, playerHP);
                    Console.WriteLine();

                    Console.WriteLine("아무 키나 눌러 진행");
                    Console.ReadKey();

                    if (playerHP == 0)
                        EndPhase(2);
                }
            }
        }

        private void EndPhase(int result)
        {
            Console.Clear();
            Console.WriteLine("Battle - Result");
            Console.WriteLine();
            switch (result)
            {
                case 1:
                    Console.WriteLine("Victory");
                    Console.WriteLine();
                    Console.WriteLine("던전에서 몬스터 {0}마리를 잡았습니다.", monsterConunt);
                    Console.WriteLine();
                    GetExp(MonsterTotalExp());
                    break;
                case 2:
                    Console.WriteLine("You Lose");
                    Console.WriteLine();
                    break;
            }
            Console.WriteLine("Lv.{0} {1}", Program.PlayerData.Level, Program.PlayerData.Name);
            Console.WriteLine("HP {0} -> {1}", Program.PlayerData.Health, playerHP);
            Console.WriteLine();
            Console.WriteLine("0. 다음");
            Console.WriteLine();
            Console.Write(">>");
            Console.ReadLine();
            isfirst = true;
            BattleEntering();
        }
    }
}
