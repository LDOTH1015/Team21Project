using System.Numerics;
using static Team21Project.Program;

namespace Team21Project
{
    internal partial class Program
    {
        // 플레이어생성
        static IPlayerCharacter player;
        static Item item;
        static string playerName;
        static Inventory inventory = new Inventory();//
        static List<Quest> quests = new List<Quest>();
        static Quest questSystem = new Quest();
        
        static Inventory inventory = new Inventory();
        public static List<Item> itemDb = new List<Item>()
        {
            new Item("TestItem",1,2,"테스트",2000,ItemType.Weapon, JobItemType.Wrroioritem),
            new Item("TestItem",1,2,"테스트",1000,ItemType.Armor, JobItemType.Wrroioritem),
            new Item("TestItem",1,2,"테스트",2000,ItemType.Armor, JobItemType.Wrroioritem),
            new Item("TestItem",1,2,"테스트",1000,ItemType.Weapon, JobItemType.Thiefitem),
            new Item("TestItem",1,2,"테스트",2000,ItemType.Weapon, JobItemType.Thiefitem),
            new Item("TestItem",1,2,"테스트",1000,ItemType.Armor, JobItemType.Thiefitem),
            new Item("TestItem",1,2,"테스트",2000,ItemType.Armor, JobItemType.Thiefitem),
            new Item("TestItem",1,2,"테스트",1000,ItemType.Weapon, JobItemType.Archeritem),
            new Item("TestItem",1,2,"테스트",2000,ItemType.Weapon, JobItemType.Archeritem),
            new Item("TestItem",1,2,"테스트",1000,ItemType.Armor, JobItemType.Archeritem),
            new Item("TestItem",1,2,"테스트",2000,ItemType.Armor, JobItemType.Archeritem),
            new Item("TestItem",1,2,"테스트",1000,ItemType.Weapon, JobItemType.Wrroioritem)
        };

        //static Shop shop = new Shop();//

        static void Main(string[] args)
        {
            questSystem.InsertQuest(quests);
            PlayerNameSettingUI();
            PlayerJobSettingUI();
            GameMainUI();
        }

        /// <summary>
        /// 게임시작화면1 - 플레이어이름설정
        /// </summary>
        static void PlayerNameSettingUI()
        {
            Console.WriteLine("");
            Console.WriteLine("■■■■■■■ WELCOME TO SPARTA ■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.Write(">>");
            playerName = Console.ReadLine();
            Console.WriteLine($"플레이어의 이름은 \"{playerName}\" 입니다");
            Console.WriteLine("다음으로 넘어가시려면 아무키나 입력해주세요.");
            Console.ReadKey();
        }
        /// <summary>
        /// 게임시작화면2 - 플레이어직업설정
        /// </summary>
        static void PlayerJobSettingUI()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("■■■■■■■ SELECT JOB ■■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("원하시는 직업을 선택해주세요.");
            Console.WriteLine("");
            Console.WriteLine($"1. 전사");
            Console.WriteLine($"2. 도적");
            Console.WriteLine($"3. 궁수");
            Console.Write(">>");

            int result = CheckInput(1, 3);

            switch (result)
            {
                case 1:
                    player = new Wrroior(playerName);
                    break;
                case 2:
                    player = new Thief(playerName);
                    break;
                case 3:
                    player = new Archer(playerName);
                    break;
            }
            Console.WriteLine($"플레이어의 직업은 \"{player.Job}\" 입니다");
            Console.WriteLine("다음으로 넘어가시려면 아무키나 입력해주세요.");
            Console.ReadKey();
        }
        
        /// <summary>
        /// 게임메인화면
        /// </summary>
        static void GameMainUI()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("■■■■■■■ GAME MAIN ■■■■■■");
                Console.WriteLine("");
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 전투 시작");
                Console.WriteLine("5. 퀘스트");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int result = CheckInput(1, 4);

                switch (result)
                {
                    case 1:
                        CharacterStatUI();
                        break;
                    case 2:
                        InventoryUI();
                        break;
                    case 3:
                        ShopUI();
                        break;
                    case 4:
                        DungeonUI();
                        break;
                    case 5:
                         questSystem.ShowQuest(quests);
                        break;
                    default:
                        Console.ReadKey();
                        GameMainUI();
                        return;
                }
            }
        }
        /// <summary>
        /// 상태보기화면(팀원-플레이어담당-확인필요)
        /// </summary>
        static void CharacterStatUI()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("■■■■■■■ PLAYER STATUS ■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");

            player.ShowStatus();

            Console.WriteLine($"");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int result = CheckInput(0, 0);

            switch (result)
            {
                case 0:
                    GameMainUI();
                    break;
                default:
                    Console.ReadKey();
                    CharacterStatUI();
                    return;
            }
        }
        /// <summary>
        /// 인벤토리화면
        /// </summary>
        static void InventoryUI()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("■■■■■■■ INVENTORY ■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");

            inventory.ShowInven();

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("2. 상점");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int result = CheckInput(0, 1);

            switch (result)
            {
                case 0:
                    GameMainUI();
                    break;
                case 1:
                    EquippedUI();
                    break;
                case 2:
                    ShopUI();
                    break;
                default:
                    Console.ReadKey();
                    return;
            }

        }
        /// <summary>
        /// 장비장착 관리화면
        /// </summary>
        static void EquippedUI()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("■■■■■■■ INVENTORY ■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("보유중인 아이템을 장착할 수 있습니다.");
            Console.WriteLine("");

            inventory.ShowInven();

            Console.WriteLine("\n0. 나가기");

            inventory.ShowEquipped(player);

            int result = CheckInput(0, 0);

            switch (result)
            {
                case 0:
                    GameMainUI();
                    break;
                default:
                    Console.ReadKey();
                    return;
            }
        }
        /// <summary>
        /// 상점화면
        /// </summary>
        static void ShopUI()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("■■■■■■■ STORE ■■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine(" ");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("");

            ShowItem();

            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine("1. 아이템구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int result = CheckInput(0, 1);

            switch (result)
            {
                case 1:
                    ShopBuyUI();
                    break;
                case 0:
                    GameMainUI();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    Console.ReadKey();
                    CharacterStatUI();
                    return;
            }
        }
        /// <summary>
        /// 상점구매화면
        /// </summary>
        static void ShopBuyUI()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■ STORE ■■■■■■■■");
            Console.Write("구매할 아이템 번호를 입력해주세요 : ");
            Console.WriteLine("");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("");

            ShowItem();

            Console.WriteLine($"");

            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int result = CheckInput(0, itemDb.Count);

            switch (result)
            {
                case 0:
                    GameMainUI();
                    break;
                default:


                    Console.ReadKey();
                    ShopBuyUI();
                    return;
            }

        }
        /// <summary>
        /// 던전입장화면
        /// </summary>
        static void DungeonUI()
        {
            BattleSystem.BattleStart(player);
        }

        /// <summary>
        /// 사용자 입력값 받기
        /// </summary>        
        static int CheckInput(int min, int max)
        {
            int result;
            while (true)
            {
                string input = Console.ReadLine();
                bool isNum = int.TryParse(input, out result);
                if (isNum)
                {
                    if (result >= min && result <= max)
                        return result;
                }
                Console.WriteLine("잘못된 입력입니다");
            }
        }
        public static void ShowItem()
        {

            for (int i = 0; i < itemDb.Count; i++)
            {
                Item curItem = itemDb[i];
                string displayPrice = player.HasItem(curItem) ? "구매완료" : $"{curItem.Price} G";
                Console.WriteLine($" [ {i + 1} ] {curItem.ItemInfoText()} | {displayPrice}");
            }
        }

        public static void BuyItem()
        {
            int result = CheckInput(0, itemDb.Count);
            Item targetItem = itemDb[result - 1];
            if (itemDb.Contains(targetItem))
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
            else
            {
                if (player.Gold <= item.Price[targetItem])
                {
                    Console.WriteLine("구매를 완료했습니다.");
                    player.Gold -= item.Price[targetItem];
                }
                else
                    Console.WriteLine("골드가 부족합니다.");
            }
        }


    }
}