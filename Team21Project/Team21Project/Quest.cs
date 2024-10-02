namespace Team21Project
{
    internal partial class Program
    {
        static Util util = new Util();
        static int result = 0;
        public class Quest
        {
            public string questName { get; set; }
            public string questDescription { get; set; }
            public string questTaget { get; set; }
            public int guestNum { get; set; }
            public int killTagetNum { get; set; }
            public List<string> compensation { get; set; }

            public Quest(string questName, string questDescription, string questTaget, int guestNum, int killTagetNum, List<string> compensation)
            {
                this.questName = questName;
                this.questDescription = questDescription;
                this.questTaget = questTaget;
                this.guestNum = guestNum;
                this.killTagetNum = killTagetNum;
                this.compensation = compensation;
            }

            public void InsertQuest(List<Quest> quests)
            {
                quests.Add(new Quest("마을을 위협하는 미니언 처치", "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\n" +
                    "마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n" +
                    "모험가인 자네가 좀 처치해주게!", "미니언", 5, 0, new List<string> {"쓸만한 방패", "5G" }));
                quests.Add(new Quest("", "", "", 5, 0, new List<string> { "쓸만한 방패", "5G" }));
                quests.Add(new Quest("", "", "", 5, 0, new List<string> { "쓸만한 방패", "5G" }));
                quests.Add(new Quest("", "", "", 5, 0, new List<string> { "쓸만한 방패", "5G" }));
                quests.Add(new Quest("", "", "", 5, 0, new List<string> { "쓸만한 방패", "5G" }));
            }
            public void showQuest(List<Quest> quests)
            {
                do
                {
                    Console.WriteLine("Quest!!");
                    Console.WriteLine("");
                    for (int i = 0; i < quests.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", i + 1, quests[i].questName);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("0. 나가기");
                    result = util.AskAnswer();
                    if(result != 0 && result < quests.Count)
                    {
                        showQuestDetail(quests[result - 1]);
                    }
                }while (result == 2);
            }

            public void showQuestDetail(Quest quest)
            {
                Console.WriteLine("Quest!!");
                Console.WriteLine("");
                Console.WriteLine("{0}", quest.questName);
                Console.WriteLine("");
                Console.WriteLine("{0}", quest.questDescription);
                Console.WriteLine("");
                Console.WriteLine("- {0} {1}마리 처치 ({2}/{1})", quest.questTaget, quest.guestNum, quest.killTagetNum);
                Console.WriteLine("");
                Console.WriteLine("- 보상 -");
                for (int i = 0; i < quest.compensation.Count; i++)
                {
                    Console.WriteLine("\t{0}", quest.compensation[i]);
                }
                Console.WriteLine("");
                Console.WriteLine("1. 수락");
                Console.WriteLine("2. 거절");
                result = util.AskAnswer();
            }

        }
    }
}