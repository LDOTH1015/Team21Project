﻿namespace Team21Project
{
    public class BattleSystem
    {
        static int result;
        static Util util = new Util();
        static int killMonster = 0;
        public static void BattleStart(IPlayerCharacter player)
        {
            Random random = new Random();
            List<Monster> monsters = new List<Monster>();

            killMonster = 0;

            int spawnMonsterNum = random.Next(1, 5);
            for (int i = 0; i < spawnMonsterNum; i++)
            {
                int monsterIndex = random.Next(0, 3);
                switch (monsterIndex)
                {
                    case 0: monsters.Add(new Monster.Minion()); break;
                    case 1: monsters.Add(new Monster.CannonMinion()); break;
                    case 2: monsters.Add(new Monster.Voidling()); break;
                    case 3: monsters.Add(new Monster.Ork()); break;
                    case 4: monsters.Add(new Monster.Devil()); break;
                    case 5: monsters.Add(new Monster.Dragon()); break;
                }
            }
            Console.Write("던전에 입장중 입니다");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500); // Pause for 500 milliseconds
                Console.Write("."); // Print a dot to simulate loading
                Console.Beep();
            }
            while (killMonster != spawnMonsterNum && !player.IsDead)
            {
                
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("■■■■■■■■■■ Battle!! ■■■■■■■■■■");
                    Console.ResetColor();
                    Console.WriteLine("");
                    for (int i = 0; i < monsters.Count; i++)
                    {
                        if (monsters[i].IsDead)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Lv.{0} {1} Dead", monsters[i].Level, monsters[i].Name);
                            Console.ResetColor();
                        } else
                        {
                            Console.WriteLine("Lv.{0} {1} HP {2}", monsters[i].Level, monsters[i].Name, monsters[i].Hp);
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("===================================================");
                    Console.WriteLine("");
                    Console.WriteLine("[내정보]");
                    Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
                    Console.WriteLine("HP {0} / {1}", player.Max_Health, player.Current_Health);
                    Console.WriteLine("MP {0} / {1}", player.Max_Mp, player.Current_MP);
                    Console.WriteLine("");
                    Console.WriteLine("===================================================");
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
                    if (!monsters[i].IsDead && !player.IsDead)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("■■■■■■■■■■ Battle!! ■■■■■■■■■■");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("Lv.{0} {1}의 공격!", monsters[i].Level, monsters[i].Name);
                        player.TakeDamage(monsters[i].Attack);
                        Console.WriteLine("");
                        Console.WriteLine("===================================================");
                        Console.WriteLine("");
                        Console.WriteLine("[내정보]");
                        Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
                        Console.WriteLine("HP {0} -> {1}", player.Max_Health, player.Current_Health);
                        Console.WriteLine("MP {0} -> {1}", player.Max_Mp, player.Current_MP);
                        Console.WriteLine("");
                        Console.WriteLine("===================================================");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Battle!! - Result");
            Console.ResetColor();
            Console.WriteLine("");
            int gold = 0;
            if (!player.IsDead)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("■■■■■■■■■■ Victory!! ■■■■■■■■■■", ConsoleColor.DarkGreen);
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("던전에서 몬스터 {0}마리를 잡았습니다.", monsters.Count);
                Console.WriteLine("");
                Console.WriteLine("===================================================");
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
                Console.WriteLine("HP {0} -> {1}", player.Max_Health, player.Current_Health);
                Console.WriteLine("MP {0} -> {1}", player.Max_Mp, player.Current_MP);
                Console.WriteLine("");
                Console.WriteLine("===================================================");
                Console.WriteLine("");
                for (int i = 0; i < monsters.Count; i++)
                {
                    gold += monsters[i].Level * 50;
                    player.LevelUp(monsters[i].Exp);
                    for (int j = 0; j < player.quest.Count; j++)
                    {
                        if (player.quest[j].questTaget == monsters[i].Name)
                        {
                            if (player.quest[j].killTagetNum != player.quest[j].questNum)
                            {
                                player.quest[j].killTagetNum++;
                            }
                        }

                    }
                }
                for (int j = 0; j < player.quest.Count; j++)
                {
                    if (player.quest[j].killTagetNum == player.quest[j].questNum)
                    {
                        Console.WriteLine("- 퀘스트 완료 보상 -");
                        for(int k = 0; k < player.quest[j].compensation.Count; k++)
                        {
                            if (player.quest[j].compensation[k].EndsWith("G"))
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            Console.WriteLine(player.quest[j].compensation[k]);
                            Console.ResetColor();
                            switch (player.quest[j].compensation[k])
                            {
                                case "회복포션": 
                                    player.Inventory.Items.Add(new Item("회복포션", 0, 0, "체력을 50 회복 시켜준다.", 0, ItemType.Potion, JobItemType.All)); 
                                    break;
                            }
                            if (player.quest[j].compensation[k].EndsWith("G"))
                            {
                                player.Gold += int.Parse(player.quest[j].compensation[k].Substring(0, player.quest[j].compensation[k].Length - 1));
                            } 
                        }
                        player.quest.RemoveAt(j);
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("- 보상 -");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t{0}G", gold);
                player.Gold += gold;
                Console.ResetColor();
                Console.WriteLine("\t회복포션");
                player.Inventory.Items.Add(new Item("회복포션",0,0, "체력을 50 회복 시켜준다.", 0,ItemType.Potion, JobItemType.All));
                Console.WriteLine("");
                Console.WriteLine("아무키나 입력해주세요");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("■■■■■■■■■■ You Lose!! ■■■■■■■■■■", ConsoleColor.Red);
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("===================================================");
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
                Console.WriteLine("HP {0} -> {1}", player.Max_Health, player.Current_Health);
                Console.WriteLine("MP {0} -> {1}", player.Max_Mp, player.Current_MP);
                Console.WriteLine("");
                Console.WriteLine("===================================================");
                Console.WriteLine("");
                Console.WriteLine("아무키나 입력해주세요");
                Console.ReadKey();
            }
        }

        public static int Attck(IPlayerCharacter player, List<Monster> monsters, bool skill)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("■■■■■■■■■■ Battle!! ■■■■■■■■■■", ConsoleColor.DarkRed);
            Console.ResetColor();
            Console.WriteLine("");
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("{0} Lv.{1} {2} Dead", i + 1, monsters[i].Level, monsters[i].Name);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("{0} Lv.{1} {2} HP {3}", i + 1, monsters[i].Level, monsters[i].Name, monsters[i].Hp);
                }
                
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("===================================================");
            Console.WriteLine("");
            Console.WriteLine("[내정보]");
            Console.WriteLine("Lv.{0} {1}", player.Level, player.Name);
            Console.WriteLine("HP {0} / {1}", player.Max_Health, player.Current_Health);
            Console.WriteLine("MP {0} -> {1}", player.Max_Mp, player.Current_MP);
            Console.WriteLine("");
            Console.WriteLine("===================================================");
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
                        int damage = player.SkillDamage();
                        if (damage != 0)
                        {
                            monsters[result - 1].TakeDamage(damage);
                        } else
                        {
                            monsters[result - 1].TakeDamage(player.AttackDamage());
                        }
                    }
                    else
                    {
                        //Console.WriteLine("{0}가 기본 공격을 사용했습니다.", player.Attack);
                        monsters[result-1].TakeDamage(player.AttackDamage());
                    }
                    if (monsters[result - 1].IsDead)
                    {
                        killMonster++;
                    }
                }
                else
                {
                    Console.WriteLine("이미 죽은 몬스터입니다.");
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