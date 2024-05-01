namespace SpartaDungeon_Team_
{
    internal class Program
    {
        public static Player PlayerData;
        
        static void Main(string[] args)
        {
            // 필요한 클래스들 불러오기
            SaveLoad saveLoad = new SaveLoad();
            MainScreen mainScreen = new MainScreen();
            Shop shopScreen = new Shop();
            Inventory inventoryScreen = new Inventory();
            Battle battle = new Battle();

            // 플레이어정보(PlayerInfo.Json) 로드
            // 아이템정보(ItemInfo.Json) 로드
            saveLoad.LoadPlayerInfo();
            saveLoad.LoadItemInfo();

            // 행동 선택하기
            while(true)
            {
                //메인화면 출력 및 메뉴 선택
                switch (mainScreen.ShowMain())
                {
                    case Screen.Status: break; // 상태 보기 화면 메서드 불러오기
                    case Screen.Dungeon: battle.BattleEntering(); break; // 전투 시작 화면 메서드 불러오기
                    case Screen.Inventory:inventoryScreen.ShowInventory(); break; // 인벤토리 화면 메서드 불러오기
                    case Screen.Shop: shopScreen.ViewShop(); break; // 상점 화면 메서드 불러오기
                    case Screen.Save: saveLoad.SavePlayerInfo(); Console.WriteLine("저장이 완료되었습니다."); Thread.Sleep(1000); break; // 저장 메소드 불러오기
                }
            }
        }
    }
}