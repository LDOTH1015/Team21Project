using System.ComponentModel.Design;

namespace Team21Project
{
    public interface IPlayerCharacter
    {
        int Level { get; set; }
        string Name {  get; set; }
        string Job { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
        int Max_Health { get; set; }
        int Current_Health {  get; set; }
        int Max_Mp { get; set; }
        int Current_MP { get; set; }
        int Gold { get; set; }
        public bool IsDead { get; set; }
        public Inventory Inventory { get; set; }       
        void TakeDamage(int damge);
        public void ShowStatus();
        public void LevelUp(int getExp);
        public int SkillDamage();
        public int AttackDamage();
    }

    public class Warrior : IPlayerCharacter
    {
        public int Max_Exp { get; set; }
        public int Current_Exp { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Max_Health { get; set; }
        public int Current_Health { get; set; }
        public int Max_Mp { get; set; }
        public int Current_MP { get; set; }
        public int Gold { get; set; }
        public bool IsDead { get; set; }
        public Inventory Inventory { get; set; }

        public Warrior(string name)
        {
            Max_Exp = 50;
            Current_Exp = 0;
            Level = 1;
            Name = name;
            Job = "전사";
            Attack = 10;
            Defense = 6;
            Max_Health = 100;
            Current_Health = 100;
            Max_Mp = 50;
            Current_MP = 50;
            Gold = 1500;
            IsDead = false;
            Inventory = new Inventory();
        }

        public void LevelUp(int getExp)
        {
            Current_Exp += getExp;
            Console.WriteLine($"{Name}이(가) {getExp}를 획득 했습니다.");
            if (Current_Exp >= Max_Exp)
            {
                Console.WriteLine($"{Name}이(가) 레벨업 했습니다. {Level} -> {Level + 1}");
                Level += 1;
                Current_Exp = 0;
                Max_Exp = Max_Exp * 2;
                Max_Mp += Max_Mp;
                Attack += Attack;
                Max_Health += 50;
            }
        }

        public void TakeDamage(int damage)
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(0, 100);

            if (rndNum < 10)
            {
                Console.WriteLine($"{Name}이(가) Monster의 공격을 회피했습니다.");
            }
            else
            {
                if (Current_Health <= damage)
                {
                    IsDead = true;
                }
                Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력 {Current_Health} -> {Current_Health - damage}");
                Current_Health -= damage;

            }
        }

        public int SkillDamage()
        {
            Random random = new Random();
            int randSkill = random.Next(0, 100);
            int skillDamage = 0;

            if (Current_MP >= 20)
            {
                Current_MP -= 20;
                if (randSkill < 30) // 30% 확률로 4배 발동
                {
                    skillDamage = Attack * 4;
                    Console.WriteLine($"{Name}이(가) 전사 스킬 '파워 스트라이크'를 사용중 치명적인 힘이 스며들어 {skillDamage}의 피해를 입혔습니다.");
                }
                else
                {
                    skillDamage = Attack * 3;
                    Console.WriteLine($"{Name}이(가) 전사 스킬 '파워 스트라이크'를 사용하여 {skillDamage}의 피해를 입혔습니다.");
                }
            }
            else
            {
                Console.Write("스킬을 사용할 MP가 모자랍니다.");
            }
            return skillDamage;
        }

        public int AttackDamage()
        {
            Random random = new Random();
            int rndCritical = random.Next(0, 100);
            int attackDamage;
            if (rndCritical < 10) // 30% 확률로 4배 발동
            {
                attackDamage = Attack * 2;
                Console.WriteLine($"치명타 발동! {Name}이(가) 치명타 {attackDamage}의 피해를 입혔습니다.");
            }
            else
            {
                attackDamage = Attack;
                Console.WriteLine($"{Name}이(가) {attackDamage}의 피해를 입혔습니다.");
            }
            return attackDamage;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"\nLV. {Level:D2}");
            Console.WriteLine($"현재 Exp : {Current_Exp} / {Max_Exp}");
            Console.WriteLine($"{Name} {{ {Job} }}");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체력 : {Current_Health}");
            Console.WriteLine($"마나 : {Current_MP}");
            Console.WriteLine($"Gold : {Gold}");
        }
    }

    public class Thief : IPlayerCharacter
    {
        public int Max_Exp { get; set; }
        public int Current_Exp { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Max_Health { get; set; }
        public int Current_Health { get; set; }
        public int Max_Mp { get; set; }
        public int Current_MP { get; set; }
        public int Gold { get; set; }
        public bool IsDead { get; set; }
        public Inventory Inventory { get; set; }

        public Thief(string name)
        {
            Max_Exp = 50;
            Current_Exp = 0;
            Level = 1;
            Name = name;
            Job = "도적";
            Attack = 7;
            Defense = 4;
            Max_Health = 100;
            Current_Health = 100;
            Max_Mp = 70;
            Current_MP = 70;
            Gold = 1500;
            Inventory = new Inventory();
        }

        public void LevelUp(int getExp)
        {
            Current_Exp += getExp;
            Console.WriteLine($"{Name}이(가) {getExp}를 획득 했습니다.");
            if (Current_Exp >= Max_Exp)
            {
                Console.WriteLine($"{Name}이(가) 레벨업 했습니다. {Level} -> {Level + 1}");
                Level += 1;
                Current_Exp = 0;
                Max_Exp = Max_Exp * 2;
                Max_Mp += Max_Mp;
                Attack += Attack;
                Max_Health += 50;
            }
        }

        public void TakeDamage(int damage)
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(0, 100);

            if (rndNum < 20)
            {
                Console.WriteLine($"{Name}이(가) Monster의 공격을 회피했습니다.");
            }
            else
            {
                if (Current_Health <= damage)
                {
                    IsDead = true;
                }
                Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력 {Current_Health} -> {Current_Health - damage}");
                Current_Health -= damage;
            }
        }

        public int SkillDamage()
        {
            Random random = new Random();
            int randSkill = random.Next(0, 100);
            int stealGold = 20;
            int skillDamage = 0;

            if (Current_MP >= 15)
            {
                Current_MP -= 15;

                if (randSkill < 30)
                {
                    skillDamage = Attack * 2;
                    Console.WriteLine($"{Name}이(가) 도적 스킬 '스틸'을 사용중 행운이 발동하여 평소보다 많은 {stealGold * 2} G를 훔쳤습니다.");
                    Gold += stealGold;
                }
                else
                {
                    skillDamage = Attack * 2;
                    Console.WriteLine($"{Name}이(가) 도적 스킬 '스틸'을 사용하여 {stealGold} G를 훔쳤습니다.");
                    Gold += stealGold;
                }
            }
                
            return skillDamage;
        }

        public int AttackDamage()
        {
            Random random = new Random();
            int rndCritical = random.Next(0, 100);
            int attackDamage;
            if (rndCritical < 40) // 30% 확률로 4배 발동
            {
                attackDamage = Attack * 2;
                Console.WriteLine($"치명타 발동! {Name}이(가) 치명타 {attackDamage}의 피해를 입혔습니다.");
            }
            else
            {
                attackDamage = Attack;
                Console.WriteLine($"{Name}이(가) {attackDamage}의 피해를 입혔습니다.");
            }
            return attackDamage;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"\nLV. {Level:D2}");
            Console.WriteLine($"현재 Exp : {Current_Exp} / {Max_Exp}");
            Console.WriteLine($"{Name} {{ {Job} }}");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체력 : {Current_Health}");
            Console.WriteLine($"마나 : {Current_MP}");
            Console.WriteLine($"Gold : {Gold}");
        }
    }

    public class Archer : IPlayerCharacter
    {
        public int Max_Exp { get; set; }
        public int Current_Exp { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Max_Health { get; set; }
        public int Current_Health { get; set; }
        public int Max_Mp { get; set; }
        public int Current_MP { get; set; }
        public int Gold { get; set; }
        public bool IsDead { get; set; }
        public Inventory Inventory { get; set; }

        public Archer(string name)
        {
            Max_Exp = 50;
            Current_Exp = 0;
            Level = 1;
            Name = name;
            Job = "궁수";
            Attack = 8;
            Defense = 3;
            Max_Health = 100;
            Current_Health = 100;
            Max_Mp = 60;
            Current_MP = 60;
            Gold = 1500;
            IsDead = false;
            Inventory = new Inventory();
        }

        public void LevelUp(int getExp)
        {
            Current_Exp += getExp;
            Console.WriteLine($"{Name}이(가) {getExp}를 획득 했습니다.");
            if (Current_Exp >= Max_Exp)
            {
                Console.WriteLine($"{Name}이(가) 레벨업 했습니다. {Level} -> {Level + 1}");
                Level += 1;
                Current_Exp = 0;
                Max_Exp = Max_Exp * 2;
                Max_Mp += Max_Mp;
                Attack += Attack;
                Max_Health += 50;
            }
        }

        public void TakeDamage(int damage)
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(0, 100);

            if (rndNum < 15)
            {
                Console.WriteLine($"{Name}이(가) Monster의 공격을 회피했습니다.");
            }
            else
            {
                if (Current_Health <= damage)
                {
                    IsDead = true;
                }
                Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력 {Current_Health} -> {Current_Health - damage}");
                Current_Health -= damage;
            }
        }

        public int SkillDamage()
        {
            Random random = new Random();
            int randSkill = random.Next(0, 100);
            int skillDamage = 0;
            if (Current_MP >= 20)
            {
                Current_MP -= 20;
                if (randSkill < 30) // 30% 확률로 4배 발동
                {
                    skillDamage = Attack * 4;
                    Console.WriteLine($"{Name}이(가) 궁수 스킬 '스나이핑'을 사용중 바람의 힘이 깃들어 {skillDamage}의 피해를 입혔습니다.");
                }
                else
                {
                    skillDamage = Attack * 3;
                    Console.WriteLine($"{Name}이(가) 궁수 스킬 '스나이핑'을 사용하여 {skillDamage}의 피해를 입혔습니다.");
                }
            }

            return skillDamage;
        }

        public int AttackDamage()
        {
            Random random = new Random();
            int rndCritical = random.Next(0, 100);
            int attackDamage;
            if (rndCritical < 20) // 30% 확률로 4배 발동
            {
                attackDamage = Attack * 2;
                Console.WriteLine($"치명타 발동! {Name}이(가) 치명타 {attackDamage}의 피해를 입혔습니다.");
            }
            else
            {
                attackDamage = Attack;
                Console.WriteLine($"{Name}이(가) {attackDamage}의 피해를 입혔습니다.");
            }
            return attackDamage;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"\nLV. {Level:D2}");
            Console.WriteLine($"현재 Exp : {Current_Exp} / {Max_Exp}");
            Console.WriteLine($"{Name} {{ {Job} }}");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체력 : {Current_Health}");
            Console.WriteLine($"마나 : {Current_MP}");
            Console.WriteLine($"Gold : {Gold}");
        }
    }
}