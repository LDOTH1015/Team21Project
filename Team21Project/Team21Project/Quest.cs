namespace Team21Project
{
    
    public class Quest
    {
        public string questName { get; set; }
        public string questDescription { get; set; }
        public string questTaget { get; set; }
        public int questNum { get; set; }
        public int killTagetNum { get; set; }
        public List<string> compensation { get; set; }

        static Util util = new Util();
        static int result = 0;
        public Quest()
        {

        }

        public Quest(string questName, string questDescription, string questTaget, int questNum, int killTagetNum, List<string> compensation)
        {
            this.questName = questName;
            this.questDescription = questDescription;
            this.questTaget = questTaget;
            this.questNum = questNum;
            this.killTagetNum = killTagetNum;
            this.compensation = compensation;
        }

        public void InsertQuest(List<Quest> quests)
        {
            quests.Add(new Quest("마을을 위협하는 미니언 처치", "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\n" +
                "마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n" +
                "모험가인 자네가 좀 처치해주게!", "미니언", 5, 0, new List<string> { "회복 포션", "500G" }));
            quests.Add(new Quest("마을을 위협하는 공허충 처치", "이봐! 마을 근처에 공허충들이 너무 많아졌다고 생각하지 않나?\n" +
                "마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n" +
                "모험가인 자네가 좀 처치해주게!", "공허충", 3, 0, new List<string> { "회복 포션", "500G" }));
        }
        public void ShowQuest(List<Quest> quests, IPlayerCharacter player)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("■■■■■■■■■■ Quest!! ■■■■■■■■■■");
                Console.WriteLine("");
                for (int i = 0; i < quests.Count; i++)
                {
                    string value = "";
                    value = quests[i].questName;
                    if (player.quest.Count != 0)
                    {
                        for (int j = 0; j < player.quest.Count; j++)
                        {
                            if (player.quest[j].questName != value)
                            {
                                Console.WriteLine("{0}. {1}", i + 1, quests[i].questName);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0}. {1}", i + 1, quests[i].questName);
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                result = util.AskAnswer();
                if (result != 0 && result <= quests.Count)
                {
                    ShowQuestDetail(quests[result - 1], player);
                }
                else if (result != 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            } while (result == 0);
        }

        public void ShowQuestDetail(Quest quest, IPlayerCharacter player)
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■■■ Quest!! ■■■■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("{0}", quest.questName);
            Console.WriteLine("");
            Console.WriteLine("{0}", quest.questDescription);
            Console.WriteLine("");
            Console.WriteLine("- {0} {1}마리 처치 ({2}/{1})", quest.questTaget, quest.questNum, quest.killTagetNum);
            Console.WriteLine("");
            Console.WriteLine("- 보상 -");
            for (int i = 0; i < quest.compensation.Count; i++)
            {
                Console.WriteLine("\t{0}", quest.compensation[i]);
            }
            Console.WriteLine("");
            Console.WriteLine("1. 수락");
            Console.WriteLine("2. 거절");
            Console.WriteLine("");
            do
            {
                result = util.AskAnswer();
                if (result == 1)
                {
                    player.quest.Add(quest);
                }
                else if (result != 2)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            } while (result != 1 && result != 2);
        }

    }
}