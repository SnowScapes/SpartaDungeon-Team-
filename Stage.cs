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

        int stageLevel = 1;
        float monsterAppearPercent;
        float epicMonsterAppearPercent = 0.6f;

        public Stage()
        {

        }
        public Stage(int _stageLevel)
        {
            stageLevel = _stageLevel;
        }

        public int GetStageLevel() { return stageLevel; }
        public void SetStageLevel(int _stageLevel) { stageLevel = _stageLevel; }


        public void FirstEnter()
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다..\n\n");
        }
        public void StageEnter(int stageLevel, float monsterAP, float epicmonstAP)
        {

        }
        public enum MonsterType
        {
            None = 0,
            Slime,
            Skeleton,
            Dragon,

            End

        };
        public class Monster
        {
            public MonsterType monsterType;
            public string name;
            int attackPower;
            int def;
            public Monster() { }
            public Monster(MonsterType monsterType, string name, int attackPower, int def)
            {
                this.monsterType = monsterType;
                this.name = name;
                this.attackPower = attackPower;
                this.def = def;
            }

        }
        public void MainStage()
        {

            while (true)
            {
                FirstEnter();

                Console.WriteLine("1.상태 보기");
                Console.WriteLine($"2.전투 시작(현재 진행 : {stageLevel}층)\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        //상태 보기

                        break;
                    case "2":
                        Console.Clear();

                        int level = stageLevel; //스테이지 단계
                        StageEnter(level, level * monsterAppearPercent, level * epicMonsterAppearPercent);

                        Random random = new Random();
                        int randomMonsterNumber = random.Next(1, (int)MonsterType.End);

                        List<Monster> monsterList = new List<Monster>();

                        for (int i = 0; i <= randomMonsterNumber; i++)
                        {
                            int rd = random.Next(1, (int)MonsterType.End);
                            monsterList.Add(new Monster());

                            monsterList[i].monsterType = (MonsterType)rd;
                            monsterList[i].name = monsterList[i].monsterType.ToString();
                            monsterList.Add(monsterList[i]);
                            Console.WriteLine((i + 1) + "." + monsterList[i].name);

                        }


                        //던전에 들어가면 높은 던전일 수록 많은 몬스터와 강한 몬스터가 나올 확률이 증가한다.
                        //monster를 받아와서 랜덤으로 뿌려준다.
                        /*
                         * 1.공허충
                         * 2.사냥개
                         * 3.오크    
                           중복해서 나올수있다.
                            Lv.2 미니언  HP 15

                        1.공격 을 선택하면
                             숫자 등장
                            1.Lv.2 미니언  HP 15

                        - 던전을 클리어할 때마다 한단계 더 높은 던전으로 입장합니다.
                        - 더 높은 던전은 층으로 표시합니다.
                        - 높은 던접에서는 더 많은 몬스더가 나올 확률과 강한 몬스터가 등장할 수 있습니다.
                       
                         */


                        if (StageClear == false)
                        {
                            Console.WriteLine("패배 하였습니다");
                            return;
                        }
                        else
                        {
                            stageLevel++;
                        }
                        break;

                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        break;
                }

            }
        }


    }

}
