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
        AvoidBuff,
        AccuracyBuff
    }
    
    // 전체 공격용 Delegate
    delegate void skillAction(float _damage);

    // Buff 스킬용 Interface
    interface IBuff
    {
        public void BuffStatus(ref float _originStatus);
        public void BuffEnd(ref float _originStatus);
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
        public Jobs UseJob; // 사용 가능 직업
        public string SkillName; // 스킬 이름
        public int RequireMP; // 필요 MP량
        public string Description; // 스킬 설명
        public int Percentage; // 비율 (ex. 스탯 50% 증가, 공격력의 200% 데미지)
    }

    // 단일 공격 스킬
    internal class SingleAttackSkill : Skill, ITargetting, ISkillActive
    {
        public SingleAttackSkill(SkillType _type, int _requireLevel, Jobs _job, string _name, int _requireMp, string _description, int _percentage)
        {
            Type = _type;
            RequireLevel = _requireLevel;
            UseJob = _job;
            SkillName = _name;
            RequireMP = _requireMp;
            Description = _description;
            Percentage = _percentage;
        }

        BattlecCalcu calc = new BattlecCalcu();
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

    // 전체 공격 스킬
    internal class MultiAttackSkill : Skill, ISkillActive
    {
        public MultiAttackSkill(SkillType _type, int _requireLevel, Jobs _job, string _name, int _requireMp, string _description, int _percentage)
        {
            Type = _type;
            RequireLevel = _requireLevel;
            UseJob = _job;
            SkillName = _name;
            RequireMP = _requireMp;
            Description = _description;
            Percentage = _percentage;
        }
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

    // 공격력 버프 스킬
    internal class BuffSkill : Skill, IBuff, ISkillActive
    {
        public BuffSkill(SkillType _type, int _requireLevel, Jobs _job, string _name, int _requireMp, string _description, int _percentage)
        {
            Type = _type;
            RequireLevel = _requireLevel;
            UseJob = _job;
            SkillName = _name;
            RequireMP = _requireMp;
            Description = _description;
            Percentage = _percentage;
        }
        // 스킬 타입에 따라 버프 대상 스탯 참조 return
        ref float getBuffTargetStat()
        {
            switch(Type)
            {
                case SkillType.AttackBuff: return ref Program.PlayerData.Attack;
                case SkillType.DefenceBuff: return ref Program.PlayerData.Defense;
                case SkillType.CriticalBuff: return ref Program.PlayerData.Critical;
                case SkillType.AvoidBuff: return ref Program.PlayerData.Avoid;
                default: return ref Program.PlayerData.Accuracy;
            }
        }

        float originalStatus;
        public void BuffEnd(ref float _originStatus)
        {
            _originStatus = originalStatus;
        }

        public void BuffStatus(ref float _originStatus)
        {
            originalStatus = _originStatus;
            _originStatus += Percentage;
        }

        public void UseSkill()
        {
            BuffStatus(ref getBuffTargetStat());
        }
    }
}
