using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    internal class Shop
    {
        public static Equipment[] Equipments;

        public void ViewShop()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 구매하거나 판매할 수 있는 상점입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine("{0} G\n", Program.PlayerData.Gold);
                Console.WriteLine("[아이템 목록]");

                foreach (Equipment e in Equipments)
                    Console.WriteLine("- {0}  | {1} +{2}  | {3} | {4}", e.Name, e.Type == EquipmentType.Armor ? "방어력" : "공격력", e.Stat, e.Description, e.Purchased ? "구매완료" : e.Price + " G");

                Console.WriteLine("\n1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                switch (Console.ReadLine())
                {
                    case "0": exit = true; break;
                    case "1": shopBuy(); break;
                    case "2": shopSell(); break;
                    default: Console.WriteLine("잘못된 입력입니다."); Thread.Sleep(1000); break;
                }
            }
        }

        private void shopBuy()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 구매하거나 판매할 수 있는 상점입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine("{0} G\n", Program.PlayerData.Gold);
                Console.WriteLine("[아이템 목록]");

                for (int i = 0; i < Equipments.Length; i++)
                    Console.WriteLine("- {0} {1}  | {2} +{3}  | {4} | {5}", i + 1, Equipments[i].Name, Equipments[i].Type == EquipmentType.Armor ? "방어력" : "공격력", Equipments[i].Stat, Equipments[i].Description, Equipments[i].Purchased ? "구매완료" : Equipments[i].Price + " G");

                Console.WriteLine("\n0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                if (int.TryParse(Console.ReadLine(), out int input) && input >= 0 && input <= Equipments.Length)
                {
                    switch (input)
                    {
                        case 0: exit = true; break;
                        case int n when n > 0 && n <= Equipments.Length:
                            if (Equipments[n - 1].Purchased)
                            {
                                Console.WriteLine("이미 구매한 아이템입니다.");
                                Thread.Sleep(1000);
                            }
                            else if (!Equipments[n - 1].Purchased && Equipments[n - 1].Price <= Program.PlayerData.Gold)
                            {
                                Inventory.MyItems.Add(n - 1);
                                Equipments[n - 1].Purchased = true;
                                Program.PlayerData.Gold -= Equipments[n - 1].Price;
                                Console.WriteLine("구매를 완료했습니다.");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.WriteLine("Gold가 부족합니다.");
                                Thread.Sleep(1000);
                            }
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

        private void shopSell()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("필요한 아이템을 구매하거나 판매할 수 있는 상점입니다.\n");
                Console.WriteLine("[아이템 목록]");

                for (int i = 0; i < Inventory.MyItems.Count; i++)
                {
                    int index = Inventory.MyItems[i];
                    Console.WriteLine("- {0} {1}  | {2} +{3}  | {4} | {5} G", i + 1, Equipments[index].Name, Equipments[index].Type == EquipmentType.Armor ? "방어력" : "공격력", Equipments[index].Stat, Equipments[index].Description, Equipments[index].Price);
                }

                Console.WriteLine("\n0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                if (int.TryParse(Console.ReadLine(), out int input) && input >= 0 && input <= Inventory.MyItems.Count)
                {
                    switch (input)
                    {
                        case 0: exit = true; break;
                        case int n when n > 0 && n <= Inventory.MyItems.Count:
                            int index = Inventory.MyItems[n - 1];
                            // 판매하려는 무기 또는 방어구가 착용 중인 아이템이라면 장착 해제
                            if (Program.PlayerData.Armor.Equals(Equipments[index]) || Program.PlayerData.Weapon.Equals(Equipments[index]))
                                Program.PlayerData.ManageEquipments(Equipments[index]);
                            Equipments[index].Purchased = false;
                            // 판매 가격은 구입 가격의 85%
                            Program.PlayerData.Gold += (int)(Equipments[Inventory.MyItems[n - 1]].Price * 0.85);
                            // 인벤토리 리스트에서 제거
                            Inventory.MyItems.RemoveAt(n - 1);
                            Console.WriteLine("판매에 성공했습니다.");
                            Thread.Sleep(1000);
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
