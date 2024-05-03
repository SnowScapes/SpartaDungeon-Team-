using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    enum SkillType
    {
        SingleAttack,
        MultiAttack,
        AttackBuff,
        DefenceBuff,
        CriticalBuff,
        AvoidBuff
    }
    delegate void skillAction(float _damage);
    interface IBuff
    {
        public void BuffStatus();
    }

    interface ITargetting
    {
        public int GetTargetIndex(int _index);
    }

    internal abstract class Skill
    {
        public SkillType Type; // 스킬 종류
        public int RequireLevel; // 사용 요구 레벨
        public string UseJob; // 사용 가능 직업
        public string SkillName; // 스킬 이름
        public int RequireMP; // 필요 MP량
        public string Description; // 스킬 설명
        public int Percentage; // 비율 (ex. 스탯 50% 증가, 공격력의 200% 데미지)

        public abstract void UseSkill();
    }
    
    internal class SingleAttackSkill : Skill, ITargetting
    {
        public override void UseSkill()
        {

        }

        public int GetTargetIndex(int _index)
        {
            return _index;
        }
    }

    internal class MultiAttackSkill : Skill
    {
        public event skillAction giveDamage;
        public override void UseSkill()
        {
            foreach (Monster targetMonster in Battle.battleMonsters)
            {
                if (!targetMonster.isDeath)
                    giveDamage += targetMonster.GetDamage;
            }
            giveDamage?.Invoke(Program.PlayerData.Attack*(Percentage/100));
        }
    }

    internal class AtkBuffSkill : Skill, IBuff
    {
        public void BuffStatus()
        {
        }

        public override void UseSkill()
        {

        }
    }

    internal class DefBuffSkill : Skill, IBuff
    {
        public void BuffStatus()
        {
        }

        public override void UseSkill()
        {

        }
    }

    internal class CrtBuffSkill : Skill, IBuff
    {
        public void BuffStatus()
        {
            int originalStatus = (int)Program.PlayerData.Critical;
        }

        public override void UseSkill()
        {

        }
    }

    internal class AvdBuffSkill : Skill, IBuff
    {
        public void BuffStatus()
        {
        }

        public override void UseSkill()
        {

        }
    }
}
