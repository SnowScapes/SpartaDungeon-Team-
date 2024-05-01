using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal enum EquipmentType
    {
        Armor = 0,
        Weapon = 1
    }

    internal struct Equipment
    {
        public string Name; // 장비 이름
        public EquipmentType Type; // 장비 타입(방어구, 무기)
        public int Stat; // 장비 스탯
        public string Description; // 장비 설명
        public int Price; // 장비 가격
        public bool Purchased; // 구매 여부
    }
}
