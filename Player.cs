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
        public float Attack; // 플레이어 공격력
        public float Defense; // 플레이어 방어력
        public int Health; // 플레이어 체력
        public int Gold; // 플레이어 골드
        public int Potion; // 플레이어 포션 수
        public Equipment Armor; // 현재 장착 중 방어구
        public Equipment Weapon; // 현재 장착 중 무기

        //초기 플레이어 스탯 설정
        public void SetPlayerStat()
        {
            Level = 1;
            Attack = 10;
            Defense = 5;
            Health = 100;
            Gold = 1500;
            Potion = 3;
        }
    }
}
