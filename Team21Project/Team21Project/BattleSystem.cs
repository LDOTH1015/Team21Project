namespace Team21Project
{
    public class BattleSystem
    {
        static int result;
        static Util util = new Util();
        public static void BattleStart(IPlayerCharacter player)
        {
            Random random = new Random();
            List<Monster> monsters = new List<Monster>();
            int killMonster = 0;
            int spawnMonsterNum = random.Next(1, 5);
            for (int i = 0; i < spawnMonsterNum; i++)
            {
                int monsterIndex = random.Next(0, 5);
                switch (monsterIndex)
                {
                    case 0: monsters.Add(new Monster.Dragon()); break;
                    case 1: monsters.Add(new Monster.Devil()); break;
                    case 2: monsters.Add(new Monster.Ork()); break;
                    case 3: monsters.Add(new Monster.Minion()); break;
                    case 4: monsters.Add(new Monster.CannonMinion()); break;
                    case 5: monsters.Add(new Monster.Voidling()); break;
                }
            }
            Console.Write("던전에 입장중 입니다");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500); // Pause for 500 milliseconds
                Console.Write("."); // Print a dot to simulate loading
                Console.Beep();
            }
            while (killMonster != monsters.Count || player.Current_Health != 0)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Battle!!", ConsoleColor.DarkRed);
                    Console.WriteLine("");
                    for (int i = 0; i < monsters.Count; i++)
                    {
                        Console.WriteLine("Lv.{0} {1} HP {2}", monsters[i].Level, monsters[i].Name, monsters[i].Hp);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("[내정보]");
                    Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
                    Console.WriteLine("HP {0} / {1}", player.Max_Health, player.Current_Health);
                    Console.WriteLine("");
                    Console.WriteLine("1. 공격");
                    Console.WriteLine("2. 스킬 공격");
                    Console.WriteLine("");
                    result = util.AskAnswer();
                    switch (result)
                    {
                        case 1: result = Attck(player, monsters, false); break;
                        case 2: result = Attck(player, monsters, true); break;
                        default:
                            Console.WriteLine("잘못된 입력입니다");
                            Console.ReadKey();
                            result = 0;
                            break;

                    }
                } while (result == 0);
                Console.WriteLine("아무키나 눌러주세요.");
                Console.ReadKey();

                for (int i = 0; i < monsters.Count; i++)
                {
                    if (!monsters[i].IsDead)
                    {
                        Console.Clear();
                        Console.WriteLine("Battle!!", ConsoleColor.DarkRed);
                        Console.WriteLine("");
                        Console.WriteLine("Lv.{0} {1}의 공격!", monsters[i].Level, monsters[i].Name);
                        player.TakeDamage(monsters[i].Attack);
                        Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
                        Console.WriteLine("HP {0} -> {1}", player.Max_Health, player.Current_Health);
                        Console.WriteLine("");
                        Console.WriteLine("아무키나 눌러주세요.");
                        Console.ReadKey();
                    }
                    if (player.Current_Health == 0)
                    {
                        break;
                    }
                }
            }
            BattleEnd(player, monsters);
        }

        public static void BattleEnd(IPlayerCharacter player, List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("Battle!! - Result", ConsoleColor.DarkRed);
            Console.WriteLine("");
            int gold = 0;
            for(int i = 0; i < monsters.Count; i++)
            {
                gold += monsters[i].Level * 50;
            }
            if (player.Current_Health != 0)
            {
                Console.WriteLine("Victory!!", ConsoleColor.DarkGreen);
                Console.WriteLine("");
                Console.WriteLine("던전에서 몬스터 {0}마리를 잡았습니다.", monsters.Count);
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
                Console.WriteLine("HP {0} -> {1}", player.Max_Health, player.Current_Health);
                Console.WriteLine("");
                Console.WriteLine("- 보상 -");
                Console.WriteLine("\t{0}G", gold);
                Console.WriteLine("\t회복포션");
                player.Inventory.Items.Add(new Item("회복포션","체력을 50 회복 시켜준다.",0,0,0,ItemType.Potion));
                Console.WriteLine("");
                Console.WriteLine("아무키나 입력해주세요");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You Lose!!", ConsoleColor.Red);
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
                Console.WriteLine("HP {0} -> {1}", player.Max_Health, player.Current_Health);
                Console.WriteLine("");
                Console.WriteLine("아무키나 입력해주세요");
                Console.ReadKey();
            }
        }

        public static int Attck(IPlayerCharacter player, List<Monster> monsters, bool skill)
        {
            Console.Clear();
            Console.WriteLine("Battle!!", ConsoleColor.DarkRed);
            Console.WriteLine("");
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine("{0} Lv.{1} {2} HP {3}", i + 1, monsters[i].Level, monsters[i].Name, monsters[i].Hp);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[내정보]");
            Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
            Console.WriteLine("HP {0} / {1}", player.Max_Health, player.Current_Health);
            Console.WriteLine("");
            Console.WriteLine("0. 취소");
            Console.WriteLine("");
            result = util.AskAnswer() ;
            if (result > 0 && result <= monsters.Count)
            {
                if (!monsters[result - 1].IsDead)
                {
                    if (skill)
                    {
                        monsters[result-1].TakeDamage(player.SkillDamage());
                    }
                    else
                    {
                        Console.WriteLine("{0}가 기본 공격을 사용했습니다.", player.Attack);
                        monsters[result-1].TakeDamage(player.Attack);
                    }
                }
                else
                {
                    Console.WriteLine("이미 죽은 몬스터입니다. .");
                }
            }
            else if (result != 0)
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            else if (result == 0)
            {
                Console.WriteLine("행동을 취소합니다.");
            }
            return result;
        }

    }
}