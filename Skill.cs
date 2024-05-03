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

    // 전체 공격용 Delegate
    delegate void skillAction(float _damage);

    // Buff 스킬용 Interface
    interface IBuff
    {
        public void BuffStatus();
    }

    // 단일 공격, 또는 적군 대상 디버프 스킬용 Interface
    interface ITargetting
    {
        public void GetTargetIndex(int _index);
    }

    // 스킬 사용 Interface
    interface ISkillActive
    {
        public void UseSkill();
    }

    // 전체 스킬 관리용 Class
    internal class Skill
    {
        public SkillType Type; // 스킬 종류
        public int RequireLevel; // 사용 요구 레벨
        public string UseJob; // 사용 가능 직업
        public string SkillName; // 스킬 이름
        public int RequireMP; // 필요 MP량
        public string Description; // 스킬 설명
        public int Percentage; // 비율 (ex. 스탯 50% 증가, 공격력의 200% 데미지)
    }
    
    internal class SingleAttackSkill : Skill, ITargetting, ISkillActive
    {
        int targetIndex;

        public void UseSkill()
        {
            Battle.battleMonsters[targetIndex].GetDamage(Program.PlayerData.Attack * (Percentage / 100));
        }

        public void GetTargetIndex(int _index)
        {
            targetIndex = _index;
        }
    }

    internal class MultiAttackSkill : Skill, ISkillActive
    {
        public event skillAction giveDamage;
        public void UseSkill()
        {
            foreach (Monster targetMonster in Battle.battleMonsters)
            {
                if (!targetMonster.isDeath)
                    giveDamage += targetMonster.GetDamage;
            }
            giveDamage?.Invoke(Program.PlayerData.Attack*(Percentage/100));
        }
    }

    internal class AtkBuffSkill : Skill, IBuff, ISkillActive
    {
        public void BuffStatus()
        {
            float originalStatus = Program.PlayerData.Attack;
        }

        public void UseSkill()
        {
            BuffStatus();
        }
    }

    internal class DefBuffSkill : Skill, IBuff, ISkillActive
    {
        public void BuffStatus()
        {
            float originalStatus = Program.PlayerData.Defense;
        }

        public void UseSkill()
        {
            BuffStatus();
        }
    }

    internal class CrtBuffSkill : Skill, IBuff, ISkillActive
    {
        public void BuffStatus()
        {
            float originalStatus = Program.PlayerData.Critical;
        }

        public void UseSkill()
        {
            BuffStatus();
        }
    }

    internal class AvdBuffSkill : Skill, IBuff, ISkillActive
    {
        public void BuffStatus()
        {
            float originalStatus = Program.PlayerData.Avoid;
        }

        public void UseSkill()
        {
            BuffStatus();
        }
    }
}
