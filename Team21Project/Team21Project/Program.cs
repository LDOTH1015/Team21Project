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
        
        static List<Quest> quests = new List<Quest>();
        static Quest questSystem = new Quest();      
        public static List<Item> itemDb = new List<Item>()
        {
            new Item("검",4,0,"초보자가 사용하는 기본 검",1000,ItemType.Weapon, JobItemType.WarriorItem),
            new Item("목검",6,0,"고목나무로 만든 검",2000,ItemType.Weapon, JobItemType.WarriorItem),
            new Item("하얀 반팔 면티",0,3,"방어력을 살짝 올려주는 하얀 티",1000,ItemType.Armor, JobItemType.WarriorItem),
            new Item("주황색 스포츠 티셔츠",0,7,"누구나 탐내하는 주황색 티셔츠",2000,ItemType.Armor, JobItemType.WarriorItem),
            new Item("후루츠 대거",4,0,"초보자가 사용하는 기본 단검",1000,ItemType.Weapon, JobItemType.ThiefItem),
            new Item("스팅어",6,0,"도적이라면 탐내하는 은색 단검",2000,ItemType.Weapon, JobItemType.ThiefItem),
            new Item("홍몽",0,3,"도적들만 착용할 수 있는 가벼운 조끼",1000,ItemType.Armor, JobItemType.ThiefItem),
            new Item("검정색 파오",0,7,"유명한 도적이 중국 활동할 때 입은 파오",2000,ItemType.Armor, JobItemType.ThiefItem),
            new Item("워 보우",4,0,"초보자가 사용하는 기본 활",1000,ItemType.Weapon, JobItemType.ArcherItem),
            new Item("라이덴",6,0,"활 숙련도가 놓은 궁수만 쓸 수 있는 활",2000,ItemType.Weapon, JobItemType.ArcherItem),
            new Item("브라운 오버롤 미니",0,3,"방어력이 올라가는 멜빵 바지",1000,ItemType.Armor, JobItemType.ArcherItem),
            new Item("다크 데모닉 수트",0,7,"활을 쏠때 도움을 주는 수트",2000,ItemType.Armor, JobItemType.ArcherItem) 
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
                    player = new Warrior(playerName);
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
                         questSystem.ShowQuest(quests, player);
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

            player.Inventory.ShowInven();

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("2. 상점");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int result = CheckInput(0, 2);

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

            player.Inventory.ShowInven();

            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            ShowEquipped();

            Console.WriteLine("다음으로 넘어가시려면 아무키나 입력해주세요.");
            Console.ReadKey();

            EquippedUI();

            int result = CheckInput(0, 0);
           
            switch (result)
            {
                case 0:
                    InventoryUI();
                    break;
                default:
                    Console.ReadKey();
                    return;
            }
        }

        public static void ShowEquipped()
        {
           
            int result = CheckInput(0, player.Inventory.Items.Count);
            if (result == 0)
            {
                InventoryUI();
            }
            else if (result >= 1 && result <= player.Inventory.Items.Count)
            {
                player.Inventory.EquippedItem(result - 1, player);
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
            Console.WriteLine("");
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
                        

            if (result == 0)
            {
                ShopUI();
            }
            else if (result >= 1 && result <= itemDb.Count)
            {
                BuyItem(result);
                ShopBuyUI();
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
                string displayPrice = player.Inventory.Items.Contains(curItem) ? "구매완료" : $"{curItem.Price} G";
                Console.WriteLine($" [ {i + 1} ] {curItem.ItemInfoText()} | {displayPrice}");
            }
        }

        public static void BuyItem(int result)
        {    
            Item targetItem = itemDb[result - 1];

            if (player.Inventory.Items.Contains(targetItem))
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
            else
            {
                if (player.Gold >= targetItem.Price)
                {
                    Console.WriteLine("구매를 완료했습니다.");
                    player.Gold -= targetItem.Price;
                    player.Inventory.Items.Add(targetItem);                    
                }
                else
                { 
                    Console.WriteLine("골드가 부족합니다.");                                   
                }
            }
        }


    }
}