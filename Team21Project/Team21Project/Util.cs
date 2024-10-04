namespace Team21Project
{
    public class Util
    {
        static int result;
        static string answer;
        public int AskAnswer()
        {
            do
            {
                Console.WriteLine("원하시는 대상을 선택해주세요.");
                answer = Console.ReadLine();
                if (!int.TryParse(answer, out result))
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요");
                } else
                {
                    result = int.Parse(answer);
                }
            }
            while (!int.TryParse(answer, out result));
            return result;
        }
    }
}