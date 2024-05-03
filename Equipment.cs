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

    //internal struct Equipment
    class Equipment
    {
        public int? index; // ?�비 착용 ?�태 ?�?�용 ?�덱??
        public string Name; // ?�비 ?�름
        public EquipmentType Type; // ?�비 ?�??방어�? 무기)
        public int Stat; // ?�비 ?�탯
        public string Description; // ?�비 ?�명
        public int Price; // ?�비 가�?
        public bool Purchased; // 구매 ?��?
    }
}
