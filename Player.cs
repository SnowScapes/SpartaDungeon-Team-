using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    struct Player
    {
        public int Level; // 플레이어 레벨
        public string Name; // 플레이어 이름
        public float LevelUpAtk;    // 레벨 업 시 증가할 공격력
        public float LevelUpDef;    // 레벨 업 시 증가할 방어력
        public float Attack; // 플레이어 공격력
        public float Defense; // 플레이어 방어력
        public int Health; // 플레이어 체력
        public int Gold; // 플레이어 골드
        public int Potion; // 플레이어 포션 수
        public Equipment Armor; // 현재 장착 중 방어구
        public Equipment Weapon; // 현재 장착 중 무기
        public int Exp;     // 현재 내 경험치

        //초기 플레이어 스탯 설정
        public void SetPlayerStat()
        {
            Level = 1;
            Health = 100;
            Attack = 10;
            Defense = 5;
            Gold = 1500;
            Potion = 3;
            Exp = 0;
        }

        public float TotalAtk() // 총 공격력 = 공격력 + 장착 장비 공격력
        {
            return Program.PlayerData.Attack + Weapon.value;
        }

        public float TotalDef()  // 총 방어력 = 방어력 + 장착 장비 방어력
        {
            return Program.PlayerData.Defense + Armor.value;
        }

        public void LevelUp()   // 플레이어 레벨 업
        {
            float LevelUpAtk = 0.5f;
            float LevelUpDef = 1f;
            Program.PlayerData.Level++;
            Program.PlayerData.Attack += LevelUpAtk;
            Program.PlayerData.Defense += LevelUpDef;

            Console.WriteLine($"레벨 업! Lv. {Program.PlayerData.Level - 1} -> Lv. {Program.PlayerData.Level}    공격력 : {Program.PlayerData.TotalAtk()} (+ 0.5)   방어력 : {Program.PlayerData.TotalDef()} (+ 1)");
        }
        //아이템 장착, 해제 기능
        //type(방어구or무기)에 따라 각 위치에 장착
        //판매 혹은 해제할 경우엔 초기화
        public void ManageEquipments(Equipment _equip)
        {
            if (_equip.Type == EquipmentType.Armor)
            {
                if (Armor.Equals(_equip))
                    Armor = new Equipment();
                else
                    Armor = _equip;
            }
            else
            {
                if (Weapon.Equals(_equip))
                    Weapon = new Equipment();
                else
                    Weapon = _equip;
            }
        }
    }
}
