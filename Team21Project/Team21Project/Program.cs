using System.Numerics;

namespace Team21Project
{
    internal partial class Program
    {
        string Input = "";
        Input = Console.ReadLine();      
        // 플레이어생성
        static IPlayerCharacter player = new Wrroior(Input);
        
        // 직업별클래스 가져오기
        static Wrroior wrrior = new Wrroior(player.Name);
        static Thief thief = new Thief(player.Name); 
        static Archer archer = new Archer(player.Name);
        
        //배틀시스템클래스가져오기
        static BattleSystem battleSystem = new BattleSystem(); 
        
        static void Main(string[] args)
        {
            PlayerNameSettingUI();
        }

        /// <summary>
        /// 게임시작화면1 - 플레이어이름설정
        /// </summary>
        static void PlayerNameSettingUI() 
        {
            Console.WriteLine("■■■■■■■ WELCOME TO SPARTA ■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.Write(">>");
            string Input = Console.ReadLine();
            player.Name = Input;
            Console.WriteLine($"플레이어의 이름은 \"{player.Name}\" 입니다");
            PlayerJobSettingUI();
        }
        /// <summary>
        /// 게임시작화면2 - 플레이어직업설정
        /// </summary>
        static void PlayerJobSettingUI()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■ SELECT JOB ■■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("원하시는 직업을 선택해주세요.");
            Console.WriteLine("");
            Console.WriteLine($"1.{wrrior.Job}");
            Console.WriteLine($"2.{thief.Job}");
            Console.WriteLine($"3.{archer.Job}");
            Console.Write(">>");
            string Input = Console.ReadLine();
            player.Job = Input;
            Console.WriteLine($"플레이어의 직업은 \"{player.Job}\" 입니다");
            GameMainUI();
        }
        /// <summary>
        /// 게임메인화면
        /// </summary>
        static void GameMainUI()
        {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine("■■■■■■■ GAME MAIN ■■■■■■");
            Console.WriteLine(" ");
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 전투 시작");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");            
            string chooseNum = Console.ReadLine();
            int Input = int.Parse(chooseNum);

            switch (Input)
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
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    Console.ReadKey();
                    GameMainUI();
                    return;
            }
        }
        /// <summary>
        /// 상태보기화면(팀원-플레이어담당-확인필요)
        /// </summary>
        static void CharacterStatUI() 
        {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine("■■■■■■■ PLAYER STATUS ■■■■■■■");
            Console.WriteLine(" ");
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");           

            string chooseNum = Console.ReadLine();
            int Input = int.Parse(chooseNum);

            switch (Input)
            {
                case 0:
                    GameMainUI();
                    break;                
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    Console.ReadKey();
                    CharacterStatUI();
                    return;
            }
              /* 
              Lv. 01
              Chad(전사)
              공격력: 10
              방어력: 5
              체 력 : 100
              Gold: 1500 G
              */
        }
        /// <summary>
        /// 인벤토리화면
        /// </summary>
        static void InventoryUI()
        {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine("■■■■■■■ INVENTORY ■■■■■■■");
            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine(" ");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            string chooseNum = Console.ReadLine();
            int Input = int.Parse(chooseNum);

            switch (Input)
            {
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
        /// 상점화면
        /// </summary>
        static void ShopUI()
        {
            Console.Clear();            
            Console.WriteLine(" ");
            Console.WriteLine("■■■■■■■ STORE ■■■■■■■■");
            Console.WriteLine(" ");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine(" ");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine(" ");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine(" ");            
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

            string chooseNum = Console.ReadLine();
            int Input = int.Parse(chooseNum);

            switch (Input)
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
            Console.WriteLine(" ");
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine(" ");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine(" ");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");            
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            string chooseNum = Console.ReadLine();
            int Input = int.Parse(chooseNum);

            switch (Input)
            {
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
        /// 던전입장화면
        /// </summary>
        static void DungeonUI()
        {
            BattleSystem.BattleStart();
        }


    }
}