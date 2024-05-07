using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    enum Jobs
    {
        „ì‚¬ = 1,
        ê¶ìˆ˜ = 2,
        ë§ˆë²•= 3
    }

    struct Player
    {
        public int Level; // ?Œë ˆ?´ì–´ ?ˆë²¨
        public Jobs Job; // ?Œë ˆ?´ì–´ ì§ì—…
        public string Name; // ?Œë ˆ?´ì–´ ?´ë¦„
        public float LevelUpAtk;    // ?ˆë²¨ ????ì¦ê???ê³µê²©??
        public float LevelUpDef;    // ?ˆë²¨ ????ì¦ê???ë°©ì–´??
        public float Attack; // ?Œë ˆ?´ì–´ ê³µê²©??
        public float Defense; // ?Œë ˆ?´ì–´ ë°©ì–´??
        public float Critical; // ?Œë ˆ?´ì–´ ì¹˜ëª…?€
        public float Accuracy; // ?Œë ˆ?´ì–´ ëª…ì¤‘ë¥?
        public float Avoid; // ?Œë ˆ?´ì–´ ?Œí”¼??
        public int Health; // ?Œë ˆ?´ì–´ ì²´ë ¥
        public int Gold; // ?Œë ˆ?´ì–´ ê³¨ë“œ
        public int Potion; // ?Œë ˆ?´ì–´ ?¬ì…˜ ??
        public Equipment Armor; // ?„ì¬ ?¥ì°© ì¤?ë°©ì–´êµ?
        public Equipment Weapon; // ?„ì¬ ?¥ì°© ì¤?ë¬´ê¸°
        public int Exp;     // ?„ì¬ ??ê²½í—˜ì¹?
        public int GainExp;   // ?»ì? ê²½í—˜ì¹?
        public int RequireExp;   // ?¤ìŒ?ˆë²¨ê¹Œì???ê²½í—˜ì¹?
        public int MaxLevel;    // ìµœê³  ?ˆë²¨
        public List<Skill> SkillList;   // ?Œë ˆ?´ì–´ ?¤í‚¬ ë¦¬ìŠ¤??
        public int Mana;        //?Œë ˆ?´ì–´ ë§ˆë‚˜

        private static Equipment unEquip = new Equipment(); // ?„ë¬´ ?¥ë¹„???¥ì°©?˜ì? ?Šì? ?íƒœ

        //ì´ˆê¸° ?Œë ˆ?´ì–´ ?¤íƒ¯ ?¤ì •
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
            // ì§ì—…???°ë¥¸ ì´ˆê¸° ?¤íƒ¯
            switch(_job)
            {
                case 1: Critical = 10; Accuracy = 100; Avoid = 20; break;
                case 2: Critical = 30; Accuracy = 80; Avoid = 50; break;
                case 3: Critical = 50; Accuracy = 80; Avoid = 30; break;
            }

        }

        public float TotalAtk() // ì´?ê³µê²©??= ê³µê²©??+ ?¥ì°© ?¥ë¹„ ê³µê²©??
        {
            return Program.PlayerData.Attack + Program.PlayerData.Weapon.Stat;
        }

        public float TotalDef()  // ì´?ë°©ì–´??= ë°©ì–´??+ ?¥ì°© ?¥ë¹„ ë°©ì–´??
        {
            return Program.PlayerData.Defense + Program.PlayerData.Armor.Stat;
        }

        public void CheckLevelUp()    //?ˆë²¨ ??ì¡°ê±´ ?•ì¸
        {
            switch (Program.PlayerData.Level)
            {
                case 1:
                    Program.PlayerData.RequireExp = 10;    // ?ˆë²¨ 1 ?¼ë•Œ ?¤ìŒ ?ˆë²¨ ?„ìš” ê²½í—˜ì¹?10
                    break;
                case 2:
                    Program.PlayerData.RequireExp = 35;    // ?ˆë²¨ 2 ?¼ë•Œ ?¤ìŒ ?ˆë²¨ ?„ìš” ê²½í—˜ì¹?35
                    break;
                case 3:
                    Program.PlayerData.RequireExp = 65;    // ?ˆë²¨ 3 ?¼ë•Œ ?¤ìŒ ?ˆë²¨ ?„ìš” ê²½í—˜ì¹?65
                    break;
                case 4:
                    Program.PlayerData.RequireExp = 100;   // ?ˆë²¨ 4 ?¼ë•Œ ?¤ìŒ ?ˆë²¨ ?„ìš” ê²½í—˜ì¹?100
                    break;
            }


        }
        public void LevelUp()   // ?Œë ˆ?´ì–´ ?ˆë²¨ ??
        {
            float LevelUpAtk = 0.5f;
            float LevelUpDef = 1f;
            Program.PlayerData.Level++;
            Program.PlayerData.Attack += LevelUpAtk;
            Program.PlayerData.Defense += LevelUpDef;
            Program.PlayerData.Exp = 0;
            CheckLevelUp();
            

            Console.WriteLine($"?ˆë²¨ ?? Lv. {Program.PlayerData.Level - 1} -> Lv. {Program.PlayerData.Level}");
            Console.WriteLine($"ê³µê²©??: {Program.PlayerData.TotalAtk()} (+ 0.5)");
            Console.WriteLine($"ë°©ì–´??: {Program.PlayerData.TotalDef()} (+ 1)");
        }
        //?„ì´???¥ì°©, ?´ì œ ê¸°ëŠ¥
        //type(ë°©ì–´êµ¬orë¬´ê¸°)???°ë¼ ê°??„ì¹˜???¥ì°©
        //?ë§¤ ?¹ì? ?´ì œ??ê²½ìš°??ì´ˆê¸°??
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
