namespace SpartaDungeon_Team_
{
    internal class Program
    {
        public static Player PlayerData;
        
        static void Main(string[] args)
        {
            // ?�요???�래?�들 불러?�기
            SaveLoad saveLoad = new SaveLoad();
            Intro introScreen = new Intro();
            MainScreen mainScreen = new MainScreen();
            Shop shopScreen = new Shop();
            Inventory inventoryScreen = new Inventory();
            Status statusScreen = new Status();
            Battle battle = new Battle();
            Stage stage = new Stage();


            //?�트�??�면 로드
            introScreen.IntroScreen(saveLoad);

            // ?�동 ?�택?�기
            while (true)
            {
                //메인?�면 출력 �?메뉴 ?�택
                switch (mainScreen.ShowMain())
                {
                    case Screen.Status: statusScreen.StatusMenu(); break; // ?�태 보기 ?�면 메서??불러?�기
                    case Screen.Dungeon:stage.MainStage(); break; // ?�투 ?�작 ?�면 메서??불러?�기
                    case Screen.Inventory:inventoryScreen.ShowInventory(); break; // ?�벤?�리 ?�면 메서??불러?�기
                    case Screen.Shop: shopScreen.ViewShop(); break; // ?�점 ?�면 메서??불러?�기
                    case Screen.Save: saveLoad.SavePlayerInfo();break; // ?�??메소??불러?�기
                    case Screen.Load: saveLoad.LoadPlayerInfo();break; // ?�?�데?�터 로드 메소??불러?�기
                }
            }
        }
    }
}