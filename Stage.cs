using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace SpartaDungeon_Team_
{

    internal class Stage
    {

        bool StageClear = true;
        static int stageLevel = 1;
        Battle battle = new Battle();
        Random random = new Random();

        public Stage() { }
        public Stage(int _stageLevel)
        {
            stageLevel = _stageLevel;
        }

        static public int GetStageLevel() { return stageLevel; }
        static public void SetStageLevel(int _stageLevel) { stageLevel = _stageLevel; }

        void SpawnMonsters(int _stageLevel)
        {
            //battle.BattleEntering();
            // 기본 몬스터 등장 확률
            double baseMonsterSpawnRate = 0.5;
            // 추가 몬스터 등장 확률
            double extraMonsterSpawnRate = 0.1 * _stageLevel; // 던전 레벨에 따라 증가
            // 최대 추가 몬스터 등장 확률 제한
            double maxExtraMonsterSpawnRate = 0.4; // 최대 40%

            if (extraMonsterSpawnRate > maxExtraMonsterSpawnRate)
            {
                extraMonsterSpawnRate = maxExtraMonsterSpawnRate;
            }
            double bossMonsterSpawnRate = 0.05 * _stageLevel; // 던전 레벨에 따라 증가

            // 최대 보스 몬스터 등장 확률 제한
            double maxBossMonsterSpawnRate = 0.3; // 최대 30%

            if (bossMonsterSpawnRate > maxBossMonsterSpawnRate)
            {
                bossMonsterSpawnRate = maxBossMonsterSpawnRate;
            }


            // 총 몬스터 등장 확률
            double totalSpawnRate = baseMonsterSpawnRate + extraMonsterSpawnRate;


            // 몬스터 등장 여부 결정
           // Console.WriteLine("몬스터가 등장했습니다!"); // 한 마리는 무조건 등장
            //battle.BattleEntering();

            int totalMonsters = random.Next(1, 4); // 추가 몬스터의 수를 결정하기 위해 1에서 4 사이의 난수 생성
            int Monstercounter = 0;
            for (int i = 1; i <= totalMonsters; i++)
            {
                if (random.NextDouble() < totalSpawnRate) //nextDouble (0.0~1.0)
                {
                    Monstercounter++;
                }
            }
            battle.BattleEntering(Monstercounter);

            // 보스 몬스터 등장 여부 결정
            //if (random.NextDouble() < bossMonsterSpawnRate)
            //{
            //    Console.WriteLine("보스 몬스터가 등장했습니다!");
            //}
        }

        void StageEnter(int _stageLevel)
        {
            SpawnMonsters(_stageLevel);

            if (battle.GetIsVictory() == false)
            {   
                Console.WriteLine("패배 하였습니다");
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }
            else//이겼을때 난이도 올리기 
            {
                Console.WriteLine("이김");
                SetStageLevel(_stageLevel + 1);
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }

        }
        
        void Intro()
        {
            Console.WriteLine("\n스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다..\n\n");
            Console.WriteLine("1.상태 보기");
            Console.WriteLine($"2.전투 시작(현재 진행 : {stageLevel}층)\n");
            Console.WriteLine("3.돌아가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
        }

        public void MainStage()
        {
            Console.Clear();
            while (true)
            {
                Intro();
               
                //if (!battle.GetIsVictory())
                //    return;

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Status status =new Status();
                        status.StatusMenu();
                        break;

                    case "2":
                        Console.Clear();
                        StageEnter(stageLevel);
                        break;

                    case "3":
                        Console.Clear();
                        return;

                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
    }

}
