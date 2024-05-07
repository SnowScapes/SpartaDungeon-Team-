namespace SpartaDungeon_Team_
{
    internal class Program
    {
        public static Player PlayerData;
        
        static void Main(string[] args)
        {
            // 필요 클래스들 불러오기
            SaveLoad saveLoad = new SaveLoad();
            Intro introScreen = new Intro();
            MainScreen mainScreen = new MainScreen();
            Shop shopScreen = new Shop();
            Inventory inventoryScreen = new Inventory();
            Status statusScreen = new Status();
            Battle battle = new Battle();
            Stage stage = new Stage();


            // 인트로 화면 로드
            introScreen.IntroScreen(saveLoad);

            // 화면 이동 선택하기
            while (true)
            {
                //메인화면 출력 및 이동할 화면 선택
                switch (mainScreen.ShowMain())
                {
                    case Screen.Status: statusScreen.StatusMenu(); break; // 상태 보기 화면 메소드 불러오기
                    case Screen.Dungeon:stage.MainStage(); break; // 전투 시작 화면 메소드 불러오기
                    case Screen.Inventory:inventoryScreen.ShowInventory(); break; // 인벤토리 화면 메소드 불러오기
                    case Screen.Shop: shopScreen.ViewShop(); break; // 상점 화면 메소드 불러오기
                    case Screen.Save: saveLoad.SavePlayerInfo();break; // 저장 화면 메소드 불러오기
                    case Screen.Load: saveLoad.LoadPlayerInfo();break; // 저장(불러오기) 화면 메소드 불러오기
                }
            }
        }
    }
}