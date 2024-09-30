namespace Team21Project
{
    public class BattleSystem
    {
        static string answer;
        public static void BattleStart(IPlayerCharacter player)
        {
            Random random = new Random();
            List<Monster> monsters = new List<Monster>();
            int killMonster = 0;
            int spawnMonsterNum = random.Next(1, 5);
            for (int i = 0; i < spawnMonsterNum; i++)
            {
                int monsterIndex = random.Next(0, 3);
                switch (monsterIndex)
                {
                    case 0: monsters.Add(new Monster.Dragon()); break;
                    case 1: monsters.Add(new Monster.Devil()); break;
                    case 2: monsters.Add(new Monster.Ork()); break;
                }
            }
            while (killMonster != monsters.Count || player.Current_Health != 0)
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
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요");
                answer = Console.ReadLine();
                switch (int.Parse(answer))
                {
                    case 1: NomalAttck(player, monsters); break;
                }
                for(int i = 0; i < monsters.Count; i++)
                {
                    if(!monsters[i].IsDead)
                    {
                        Console.WriteLine("Battle!!", ConsoleColor.DarkRed);
                        Console.WriteLine("");
                        Console.WriteLine("Lv.{0} {1}의 공격!", monsters[i].Level, monsters[i].Name);
                        player.TakeDamage(monsters[i].Attack);
                        Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
                        Console.WriteLine("HP {0} -> {1}", player.Max_Health, player.Current_Health);
                        Console.WriteLine("");
                        Console.WriteLine("0. 다음");
                        Console.WriteLine("");
                        answer = Console.ReadLine();
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
                Console.WriteLine("0. 다음");
                Console.WriteLine("");
                answer = Console.ReadLine();
            } else
            {
                Console.WriteLine("You Lose!!", ConsoleColor.Red);
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
                Console.WriteLine("HP {0} -> {1}", player.Max_Health, player.Current_Health);
                Console.WriteLine("");
                Console.WriteLine("0. 다음");
                Console.WriteLine("");
                answer = Console.ReadLine();
            }
        }

        public static void NomalAttck(IPlayerCharacter player, List<Monster> monsters)
        {
            IPlayerCharacter player1 = new Wrroior("");
            Console.Clear();
            Console.WriteLine("Battle!!", ConsoleColor.DarkRed);
            Console.WriteLine("");
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.WriteLine("{0} Lv.{1} {2} HP {3}", i+1,monsters[i].Level, monsters[i].Name, monsters[i].Hp);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[내정보]");
            Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
            Console.WriteLine("HP {0} / {1}", player.Max_Health, player.Current_Health);
            Console.WriteLine("");
            Console.WriteLine("1. 취소");
            Console.WriteLine("");
            Console.WriteLine("원하시는 대상을 선택해주세요.");
            answer = Console.ReadLine();
            if (int.Parse(answer)>0 && int.Parse(answer) <= monsters.Count)
            {
                if (!monsters[int.Parse(answer)-1].IsDead)
                {
                    monsters[int.Parse(answer)].TakeDamage(player.Attack);
                } else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            } else if(int.Parse(answer) != 0)
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

    }
}