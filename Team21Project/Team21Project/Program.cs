﻿using System.Numerics;

namespace Team21Project
{
    internal partial class Program
    {
        // 플레이어생성
        static IPlayerCharacter player;
        static string playerName;
        
        static void Main(string[] args)
        {
            PlayerNameSettingUI();
            PlayerJobSettingUI();
            GameMainUI();
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
            playerName = Console.ReadLine();
            Console.WriteLine($"플레이어의 이름은 \"{playerName}\" 입니다");
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
            Console.WriteLine($"1. 전사");
            Console.WriteLine($"2. 궁수");
            Console.WriteLine($"3. 도적");
            Console.Write(">>");
            string input = Console.ReadLine();
            switch (int.Parse(input))
            {
                case 1: player = new Wrroior(playerName); break;
                case 2: player = new Thief(playerName); break;
                case 3: player = new Archer(playerName); break;
            }
            Console.WriteLine($"플레이어의 직업은 \"{player.Job}\" 입니다");
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
            player.ShowStatus();
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
            BattleSystem.BattleStart(player);
        }


    }
}