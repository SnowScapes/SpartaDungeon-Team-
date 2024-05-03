using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
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
        public int RequireLevel;
        public string UseJob;
        public string SkillName;
        public int RequireMP;
        public string Description;
        public int Percentage;

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
            giveDamage?.Invoke(Program.PlayerData.Attack);
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
