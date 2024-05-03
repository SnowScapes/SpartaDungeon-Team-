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
        public int? index; // ?¥ë¹„ ì°©ìš© ?íƒœ ?€?¥ìš© ?¸ë±??
        public string Name; // ?¥ë¹„ ?´ë¦„
        public EquipmentType Type; // ?¥ë¹„ ?€??ë°©ì–´êµ? ë¬´ê¸°)
        public int Stat; // ?¥ë¹„ ?¤íƒ¯
        public string Description; // ?¥ë¹„ ?¤ëª…
        public int Price; // ?¥ë¹„ ê°€ê²?
        public bool Purchased; // êµ¬ë§¤ ?¬ë?
    }
}
