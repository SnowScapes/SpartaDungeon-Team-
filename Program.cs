namespace SpartaDungeon_Team_
{
    internal class Program
    {
        public static Player PlayerData;
        
        static void Main(string[] args)
        {
            // ?꾩슂????�???�뱾 ?�덈???�린
            SaveLoad saveLoad = new SaveLoad();
            Intro introScreen = new Intro();
            MainScreen mainScreen = new MainScreen();
            Shop shopScreen = new Shop();
            Inventory inventoryScreen = new Inventory();
            Status statusScreen = new Status();
            Battle battle = new Battle();
            Stage stage = new Stage();


            //?명듃�??붾㈃ 濡쒕�?
            introScreen.IntroScreen(saveLoad);
            
            // ?�동 ?�택?�기
            while (true)
            {
                //硫붿??붾㈃ ?�쒕??�?硫붾???좏깮
                switch (mainScreen.ShowMain())
                {
                    case Screen.Status: statusScreen.StatusMenu(); break; // ?곹깭 蹂닿�??붾㈃ 硫붿�???�덈???�린
                    case Screen.Dungeon:stage.MainStage(); break; // ?꾪닾 ??�옉 ?붾㈃ 硫붿�???�덈???�린
                    case Screen.Inventory:inventoryScreen.ShowInventory(); break; // ?몃깽?좊━ ?붾㈃ 硫붿�???�덈???�린
                    case Screen.Shop: shopScreen.ViewShop(); break; // ?곸젏 ?붾㈃ 硫붿�???�덈???�린
                    case Screen.Save: saveLoad.SavePlayerInfo();break; // ????硫붿????�덈???�린
                    case Screen.Load: saveLoad.LoadPlayerInfo();break; // ???λ???�꽣 濡쒕�?硫붿????�덈???�린
                }
            }
        }
    }
}