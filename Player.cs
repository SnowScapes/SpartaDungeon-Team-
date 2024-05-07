using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    enum Jobs
    {
        �사 = 1,
        궁수 = 2,
        마법= 3
    }

    struct Player
    {
        public int Level; // ?�레?�어 ?�벨
        public Jobs Job; // ?�레?�어 직업
        public string Name; // ?�레?�어 ?�름
        public float LevelUpAtk;    // ?�벨 ????증�???공격??
        public float LevelUpDef;    // ?�벨 ????증�???방어??
        public float Attack; // ?�레?�어 공격??
        public float Defense; // ?�레?�어 방어??
        public float Critical; // ?�레?�어 치명?�
        public float Accuracy; // ?�레?�어 명중�?
        public float Avoid; // ?�레?�어 ?�피??
        public int Health; // ?�레?�어 체력
        public int Gold; // ?�레?�어 골드
        public int Potion; // ?�레?�어 ?�션 ??
        public Equipment Armor; // ?�재 ?�착 �?방어�?
        public Equipment Weapon; // ?�재 ?�착 �?무기
        public int Exp;     // ?�재 ??경험�?
        public int GainExp;   // ?��? 경험�?
        public int RequireExp;   // ?�음?�벨까�???경험�?
        public int MaxLevel;    // 최고 ?�벨
        public List<Skill> SkillList;   // ?�레?�어 ?�킬 리스??
        public int Mana;        //?�레?�어 마나

        private static Equipment unEquip = new Equipment(); // ?�무 ?�비???�착?��? ?��? ?�태

        //초기 ?�레?�어 ?�탯 ?�정
        public void SetPlayerStat(int _job)
        {
            Level = 1;
            Job = (Jobs)_job;
            Health = 100;
            Attack = 10;
            Defense = 5;
            Gold = 1500;
            Potion = 3;
            Armor = unEquip;
            Weapon = unEquip;
            Exp = 0;
            Mana = 50;
            MaxLevel = 5;
            RequireExp = 10;
            Critical = 50;
            Accuracy = 120;
            Avoid = 50;
            // 직업???�른 초기 ?�탯
            switch(_job)
            {
                case 1: Critical = 10; Accuracy = 100; Avoid = 20; break;
                case 2: Critical = 30; Accuracy = 80; Avoid = 50; break;
                case 3: Critical = 50; Accuracy = 80; Avoid = 30; break;
            }

        }

        public float TotalAtk() // �?공격??= 공격??+ ?�착 ?�비 공격??
        {
            return Program.PlayerData.Attack + Program.PlayerData.Weapon.Stat;
        }

        public float TotalDef()  // �?방어??= 방어??+ ?�착 ?�비 방어??
        {
            return Program.PlayerData.Defense + Program.PlayerData.Armor.Stat;
        }

        public void CheckLevelUp()    //?�벨 ??조건 ?�인
        {
            switch (Program.PlayerData.Level)
            {
                case 1:
                    Program.PlayerData.RequireExp = 10;    // ?�벨 1 ?�때 ?�음 ?�벨 ?�요 경험�?10
                    break;
                case 2:
                    Program.PlayerData.RequireExp = 35;    // ?�벨 2 ?�때 ?�음 ?�벨 ?�요 경험�?35
                    break;
                case 3:
                    Program.PlayerData.RequireExp = 65;    // ?�벨 3 ?�때 ?�음 ?�벨 ?�요 경험�?65
                    break;
                case 4:
                    Program.PlayerData.RequireExp = 100;   // ?�벨 4 ?�때 ?�음 ?�벨 ?�요 경험�?100
                    break;
            }


        }
        public void LevelUp()   // ?�레?�어 ?�벨 ??
        {
            float LevelUpAtk = 0.5f;
            float LevelUpDef = 1f;
            Program.PlayerData.Level++;
            Program.PlayerData.Attack += LevelUpAtk;
            Program.PlayerData.Defense += LevelUpDef;
            Program.PlayerData.Exp = 0;
            CheckLevelUp();
            

            Console.WriteLine($"?�벨 ?? Lv. {Program.PlayerData.Level - 1} -> Lv. {Program.PlayerData.Level}");
            Console.WriteLine($"공격??: {Program.PlayerData.TotalAtk()} (+ 0.5)");
            Console.WriteLine($"방어??: {Program.PlayerData.TotalDef()} (+ 1)");
        }
        //?�이???�착, ?�제 기능
        //type(방어구or무기)???�라 �??�치???�착
        //?�매 ?��? ?�제??경우??초기??
        public void ManageEquipments(Equipment _equip)
        {
            if (_equip.Type == EquipmentType.Armor)
            {
                if (Armor.Equals(_equip))
                    Armor = unEquip;
                else
                    Armor = _equip;
            }
            else
            {
                if (Weapon.Equals(_equip))
                    Weapon = unEquip;
                else
                    Weapon = _equip;
            }
        }

        public Equipment UnEquip()
        {
            return unEquip;
        }
    }
}
