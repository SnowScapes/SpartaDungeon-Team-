using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    enum Jobs
    {
        전사 = 1,
        궁수 = 2,
        마법사 = 3
    }

    struct Player
    {
        public int Level; // 플레이어 레벨
        public Jobs Job; // 플레이어 직업
        public string Name; // 플레이어 이름
        public float LevelUpAtk;    // 레벨업 시 공격력 증가량
        public float LevelUpDef;    // 레벨업 시 방어력 증가량
        public float Attack; // 플레이어 공격력
        public float Defense; // 플레이어 방어력
        public float Critical; // 플레이어 치명률
        public float Accuracy; // 플레이어 명중률
        public float Avoid; // 플레이어 회피율
        public int Health; // 플레이어 체력
        public int Gold; // 플레이어 골드
        public int Potion; // 플레이어 포션 개수
        public Equipment Armor; // 현재 장착 방어구
        public Equipment Weapon; // 현재 장착 무기
        public int Exp;     // 현재 경험치
        public int GainExp;   // 습득 경험치
        public int RequireExp;   // 레벨업 필요 경험치
        public int MaxLevel;    // 최고 레벨
        public List<Skill> SkillList;   // 플레이어 스킬 리스트
        public int Mana;        // 플레이어 마나

        private static Equipment unEquip = new Equipment(); // 장비 미착용 상태를 위한 클래스

        //초기 플레이어 스탯 설정
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
            // 직업에 따른 초기 스탯
            switch(_job)
            {
                case 1: Critical = 10; Accuracy = 100; Avoid = 20; break;
                case 2: Critical = 30; Accuracy = 80; Avoid = 50; break;
                case 3: Critical = 50; Accuracy = 80; Avoid = 30; break;
            }

        }

        public float TotalAtk() // 총 공격력 = 플레이어 공격력 + 장비 공격력
        {
            return Program.PlayerData.Attack + Program.PlayerData.Weapon.Stat;
        }

        public float TotalDef()  // 총 방어력 = 플레이어 방어력 + 장비 방어력
        {
            return Program.PlayerData.Defense + Program.PlayerData.Armor.Stat;
        }

        public void CheckLevelUp()    //레벨업 필요 경험치 설정
        {
            switch (Program.PlayerData.Level)
            {
                case 1:
                    Program.PlayerData.RequireExp = 10;    // 레벨 1일 때 필요 경험치 10
                    break;
                case 2:
                    Program.PlayerData.RequireExp = 35;    // 레벨 2일 때 필요 경험치 35
                    break;
                case 3:
                    Program.PlayerData.RequireExp = 65;    // 레벨 3일 때 필요 경험치 65
                    break;
                case 4:
                    Program.PlayerData.RequireExp = 100;   // 레벨 4일 때 필요 경험치 100
                    break;
            }


        }
        public void LevelUp()   // 플레이어 레벨 업
        {
            float LevelUpAtk = 0.5f;
            float LevelUpDef = 1f;
            Program.PlayerData.Level++;
            Program.PlayerData.Attack += LevelUpAtk;
            Program.PlayerData.Defense += LevelUpDef;
            Program.PlayerData.Exp = 0;
            CheckLevelUp();
            

            Console.WriteLine($"레벨 업 Lv. {Program.PlayerData.Level - 1} -> Lv. {Program.PlayerData.Level}");
            Console.WriteLine($"공격력: {Program.PlayerData.TotalAtk()} (+ 0.5)");
            Console.WriteLine($"방어?력: {Program.PlayerData.TotalDef()} (+ 1)");
        }
        // 플레이어 장비 장착, 해제 기능
        // type(방어구or무기)에 따라 자동 장착
        // 판매시 방어구 장착 해제
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
