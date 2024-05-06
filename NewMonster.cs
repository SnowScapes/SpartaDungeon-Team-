using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{

    public enum MonsterType
    {
        None,
        Minion,
        VoidBug,
        CannonMinion,
        End,
    }
    public enum MonsterGrade
    {
        None,
        Monster,
        Boss
    }

    internal class NewMonster
    {
        MonsterType type = MonsterType.None;

        protected int hp = 0;
        public int attack = 0;
        protected int Level = 1;
        protected int def = 0;
        protected string name="";
        protected bool isDead = false;

        public int avoid; // 회피율
        public int accuracy; // 명중률


        public int GetHp() { return hp; }
        public int GetAttack() { return attack; }
        public bool IsDead() { return isDead; }
        public int GetLevel() { return Level; }
        public string GetName() { return name; } 
        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                hp = 0;
                isDead = true;
            }
                
        }

        //public void SetInfo(int hp, int attack)
        //{
        //    this.hp = hp;
        //    this.attack = attack;
        //}
        //protected NewMonster(MonsterType type)
        //{
        //    this.type = type;
        //}
     
    }


    class Minion : NewMonster
    {

        public Minion Clone(int _stageLevel)
        {
            Minion minion = new Minion();
            minion.hp = 15+_stageLevel;
            minion.name = "미니언";
            minion.attack = 5+_stageLevel;
            minion.avoid = 50;
            minion.accuracy = 70;

            return minion;
        }
    }
    class VoidBug : NewMonster
    {
    
        public VoidBug Clone(int _stageLevel)
        {
            VoidBug voidbug = new VoidBug();
            voidbug.name = "공허충";
            voidbug.hp = 10 + _stageLevel;            
            voidbug.attack = 9 + _stageLevel;
            voidbug.avoid = 70;
            voidbug.accuracy = 100;
           
            return voidbug;
        }
    }

    class CannonMinion : NewMonster
    {
        public CannonMinion Clone(int _stageLevel)
        {
            CannonMinion cannonMinion = new CannonMinion();
            cannonMinion.name = "대포 미니언";
            cannonMinion.hp = 25 + _stageLevel;
            cannonMinion.attack = 8 + _stageLevel;
            cannonMinion.avoid = 80;
            cannonMinion.accuracy = 120;
           
            return cannonMinion;
        }
    }

}
