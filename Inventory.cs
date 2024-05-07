using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class Inventory
    {
        public static List<int> MyItems = new List<int>();
        public void ShowInventory()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                for (int i = 0; i < MyItems.Count; i++)
                {
                    int index = MyItems[i];
                    Console.Write("- {0}", Shop.Equipments[index].Equals(Program.PlayerData.Armor) || Shop.Equipments[index].Equals(Program.PlayerData.Weapon) ? "[E]" : "");
                    Console.WriteLine("{0}  | {1} +{2}  | {3}", Shop.Equipments[index].Name, Shop.Equipments[index].Type == EquipmentType.Armor ? "방어력" : "공격력", Shop.Equipments[index].Stat, Shop.Equipments[index].Description);
                }

                Console.WriteLine("\n1. 장착 관리");
                Console.WriteLine("0. 나가기");

                switch (Console.ReadLine())
                {
                    case "0": exit = true; break;
                    case "1": inventoryEquip(); break;
                    default: Console.WriteLine("잘못된 입력입니다."); Thread.Sleep(1000); break;
                }
            }
        }

        void inventoryEquip()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                for (int i = 0; i < MyItems.Count; i++)
                {
                    int index = MyItems[i];
                    Console.Write("- {0} {1}", i + 1, Shop.Equipments[index].Equals(Program.PlayerData.Armor) || Shop.Equipments[index].Equals(Program.PlayerData.Weapon) ? "[E]" : "");
                    Console.WriteLine("{0}  | {1} +{2}  | {3}", Shop.Equipments[index].Name, Shop.Equipments[index].Type == EquipmentType.Armor ? "방어력" : "공격력", Shop.Equipments[index].Stat, Shop.Equipments[index].Description);
                }

                Console.WriteLine("\n 0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                if (int.TryParse(Console.ReadLine(), out int input) && input >= 0 && input <= MyItems.Count)
                {
                    switch (input)
                    {
                        case 0: exit = true; break;
                        case int n when n > 0 && n <= MyItems.Count:
                            int index = MyItems[n - 1];
                            Program.PlayerData.ManageEquipments(Shop.Equipments[index]);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
