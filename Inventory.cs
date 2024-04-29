using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class Inventory
    {
        public static List<Equipment> MyItems = new List<Equipment>();
        public void ShowInventory()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                foreach (Equipment e in MyItems)
                    Console.WriteLine("- {0}  | {1} +{2}  | {3}", e.Name, e.Type == EquipmentType.Armor ? "방어력" : "공격력", e.Stat, e.Description);

                Console.WriteLine("\n1. 장착 관리");
                Console.WriteLine("0. 나가기");

                switch(Console.ReadLine())
                {
                    case "0": exit = true; break;
                    case "1": inventoryEquip(); break;
                    default: Console.WriteLine("잘못된 입력입니다."); Thread.Sleep(1000); break;
                }
            }
        }

        void inventoryEquip()
        {

        }
    }
}
