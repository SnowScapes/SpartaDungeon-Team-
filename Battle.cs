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
        BattlecCalcu buttlecCalcu = new BattlecCalcu();
        Random rand = new Random();
        Player player = new Player();
        
        //monster init()
        Minion minion = new Minion();
        VoidBug bug = new VoidBug();
        CannonMinion CannonMinion = new CannonMinion();
        
        List<NewMonster> newMonster = new List<NewMonster>();
        //test
        public static List<NewMonster> battleMonsters = new List<NewMonster>();

        public List<NewMonster> GetNewMonster()
        {
            return newMonster;
        }

        int[] testPlayer = new int[6] { 1, 10, 5, 100, 1500, 3 };

        public int monsterNumber = 1;

        int playerHP;
       
        int monsterLifeCount = 0;
        int monsterConunt=0;
        int monsterExp = 0;
       
        
        bool isfirst = true;

        bool isVictory = false;

        public bool GetIsVictory()
        {
            return isVictory;
        }

    
        public void BattleEntering(int _monsterNumber) // 전투 메뉴 입장 
        {
            monsterNumber = _monsterNumber;
            bool notValid = false;
           
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine();

                playerHP = Program.PlayerData.Health;

                for (int i = 0; i <= _monsterNumber; i++)
                {
                    int randnum = rand.Next(1, (int)MonsterType.End);
                    switch (randnum)
                    {
                        case 1:
                            newMonster.Add(minion.Clone(Stage.GetStageLevel()));                       
                            break;
                        case 2:
                            newMonster.Add(bug.Clone(Stage.GetStageLevel()));
                            break;
                        case 3:
                            newMonster.Add(CannonMinion.Clone(Stage.GetStageLevel()));
                            break;
                    }
                    monsterLifeCount++;
                }

               
                foreach(var item in newMonster)
                {
                    if (item.IsDead())
                    {
                        Console.WriteLine("Lv.{0} {1} Dead", item.GetLevel(),item.GetName());
                    }
                    else
                    {
                        Console.WriteLine("Lv.{0} {1} HP{2}", item.GetLevel(), item.GetName(),item.GetHp());
                    }
                    
                }



                monsterConunt = monsterLifeCount;
             

                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv.{0} {1} ({2})", Program.PlayerData.Level, Program.PlayerData.Name, Program.PlayerData.Job);
                Console.WriteLine("HP {0}/{1}", Program.PlayerData.Health, playerHP);
                Console.WriteLine();

                if (notValid)
                {
                    Console.WriteLine("잘못된 입력 입니다.");
                    notValid = false;
                }

                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬");

                switch (Console.ReadLine())
                {
                    case "1":
                        BattleSet();
                        break;
                    default: 
                        notValid = true; 
                        break;
                }
            }
            
        }

        private void BattleSet() // 전투 진행
        {
            
            int battleIdx = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine();


                foreach(var item in newMonster)
                {
                    battleIdx++;
                    if (item.IsDead())
                    {
                        Console.WriteLine("{0}. Lv.{1} {2} Dead", battleIdx, item.GetLevel(),item.GetName());
                    }
                    else
                    {
                        Console.WriteLine("{0}. Lv.{1} {2} HP {3}", battleIdx, item.GetLevel(), item.GetName(),item.GetHp());
                    }
                }

                battleIdx = 0;

                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv.{0} Chad (전사)", Program.PlayerData.Name);
                Console.WriteLine("HP {0}/{1}", Program.PlayerData.Health, playerHP);
                Console.WriteLine();
                Console.WriteLine("0. 취소");
                Console.WriteLine();
                Console.WriteLine("대상을 선택해주세요.");
                Console.Write(">>");
            
         
                int inputMenu = int.Parse(Console.ReadLine());
                
                switch (inputMenu)
                {
                    case 0:
                        newMonster.Clear();
                        MainScreen mainScreen = new MainScreen();
                        mainScreen.ShowMain();
                        return;
                    default:
                        PlayerPhase(inputMenu - 1); 
                        break;
                }
            }

            
        }


        private void PlayerPhase(int battleMonsterIdx)
        {


            bool isAtkP = false;

            NewMonster targetMonster = newMonster[battleMonsterIdx];
            int monsterHP = targetMonster.GetHp();  // 맞기전 몬스터 체력 받을 변수

            int playerAtk = buttlecCalcu.DamageCalcu((int)Program.PlayerData.Critical, (int)Program.PlayerData.TotalAtk());

            
            if (buttlecCalcu.Avoid((int)Program.PlayerData.Accuracy, targetMonster.avoid) == true)
            {
                //monsterHP -= playerAtk;
                targetMonster.OnDamaged(playerAtk);
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
                Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. (데미지 : {2})", targetMonster.GetLevel(), targetMonster.GetName(), playerAtk);
            }
            else
            {
                Console.WriteLine("빗나감!");
            }
            Console.WriteLine();
            Console.WriteLine("Lv.{0} {1}", targetMonster.GetLevel(), targetMonster.GetName()) ; //몬스터 레벨, 이름

            // 공격 결과 출력
            if (targetMonster.IsDead())
                Console.WriteLine("HP {0} -> Dead", targetMonster.GetHp());
            else
                Console.WriteLine("HP {0} -> {1}\n", monsterHP, targetMonster.GetHp()); // 공격력 만큼 뺀 채력

            //targetMonster.GetDamage(playerAtk);

            Console.WriteLine("아무 키나 눌러 진행");
            Console.ReadKey();

            if (targetMonster.IsDead())
            {
                monsterLifeCount--;
            }

            if (monsterLifeCount == 0) // 전투 종료 (승리)
            {
                EndPhase(1);
                
            }

            foreach (var monster in newMonster)
            {
                if (!monster.IsDead())
                {
                    int monsterAkt = buttlecCalcu.DamageCalcu(0, monster.attack);
                    bool isAtkM = false;

                    // 모든 몬스터가 아닌 targetMonster의 accuracy만을 반영해서 수정함
                    if (buttlecCalcu.Avoid(monster.accuracy, (int)Program.PlayerData.Avoid) == true)
                    {
                        playerHP = playerHP - monsterAkt;
                        isAtkM = true;
                    }

                    if (playerHP <= 0)
                        playerHP = 0;

                   

                    Console.Clear();
                    Console.WriteLine("Battle!!");
                    Console.WriteLine();
                    Console.WriteLine("몬스터 공격!!");
                    Console.WriteLine();
                    Console.WriteLine("Lv.{0} {1} 의 공격!", monster.GetLevel(), monster.GetName());
                    if (isAtkM == true)
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
                    {
                        EndPhase(2);
                        
                    }
                }
            }
        }

        public int MonsterTotalExp()  // 전투 중 잡은 몬스터 레벨의 총합을 monsterExp에 넣어주기
        {
            for (int i = 0; i < newMonster.Count; i++)
            {
                if (newMonster[i].IsDead())
                {
                    monsterExp += newMonster[i].GetLevel();
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
                player.LevelUp();
            }

            if (Program.PlayerData.Level >= Program.PlayerData.MaxLevel)   // 최고 레벨 도달 시
            {
                // 현재 경험치 더 이상 안오르게 하기
                Program.PlayerData.Exp = 0;
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
                    GetExp(MonsterTotalExp());
                    Console.WriteLine("Lv.{0} {1}", Program.PlayerData.Level, Program.PlayerData.Name);
                    Console.WriteLine("HP {0} -> {1}", Program.PlayerData.Health, playerHP);
                    Console.WriteLine("[{0}]의 경험치를 얻었습니다.", monsterExp);
                    Console.WriteLine();
                    isVictory = true;
                    break;
                case 2:
                    Console.WriteLine("You Lose");
                    Console.WriteLine("Lv.{0} {1}", Program.PlayerData.Level, Program.PlayerData.Name);
                    Console.WriteLine("HP {0} -> {1}", Program.PlayerData.Health, playerHP);
                    Console.WriteLine();
                    isVictory = false;
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("0. 다음");
            Console.WriteLine();
            Console.Write(">>");

            
            switch (Console.ReadLine())
            {
                case "0":
                    Stage stage=new Stage();
                    newMonster.Clear();
                    if (isVictory == false)
                    {
                        Console.WriteLine("패배 하였습니다");
                        Thread.Sleep(1000);
                        Console.Clear();
                        stage.MainStage();
                    
                    }
                    else//이겼을때 난이도 올리기 
                    {
                        Console.WriteLine("이김");
                        Stage.SetStageLevel(Stage.GetStageLevel() + 1);
                        Thread.Sleep(1000);
                        Console.Clear();
                        stage.MainStage();
                    
                    }
                    break;
                
            }
            
        }
    }
}
