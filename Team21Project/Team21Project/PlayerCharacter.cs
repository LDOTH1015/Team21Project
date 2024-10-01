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
        int Gold { get; set; }
        public Inventory Inventory { get; set; }
        void TakeDamage(int damge);
        public void ShowStatus();
    }

    public class Wrroior : IPlayerCharacter
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Max_Health { get; set; }
        public int Current_Health { get; set; }
        public int Gold { get; set; }
        public Inventory Inventory { get; set; }

        public Wrroior(string name)
        {
            Level = 1;
            Name = name;
            Job = "전사";
            Attack = 10;
            Defense = 6;
            Max_Health = 100;
            Current_Health = 100;
            Gold = 1500;
            Inventory = new Inventory();
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
                Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력 {Current_Health} -> {Current_Health - damage}");
                Current_Health -= damage;
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"\nLV. {Level:D2}");
            Console.WriteLine($"{Name} {{ {Job} }}");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체력 : {Max_Health}");
            Console.WriteLine($"Gold : {Gold}");
        }
    }

    public class Thief : IPlayerCharacter
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Max_Health { get; set; }
        public int Current_Health { get; set; }
        public int Gold { get; set; }
        public Item EquippedWeapon { get; set; }
        public Item EquippedArmor { get; set; }
        public Inventory Inventory { get; set; }

        public Thief(string name)
        {
            Level = 1;
            Name = name;
            Job = "도적";
            Attack = 7;
            Defense = 4;
            Max_Health = 100;
            Current_Health = 100;
            Gold = 1500;
            Inventory = new Inventory();
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
                Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력 {Current_Health} -> {Current_Health - damage}");
                Current_Health -= damage;
            }
        }

        public void ShowStatus()
        {
            int equippedAtk = EquippedWeapon != null ? EquippedWeapon.AttackBouns : 0;
            int equippedDef = EquippedArmor != null ? EquippedArmor.DefenseBouns : 0;

            Console.WriteLine($"\nLV. {Level:D2}");
            Console.WriteLine($"{Name} {{ {Job} }}");
            Console.WriteLine($"공격력 : {Attack} {(equippedAtk > 0 ? $"(+{equippedAtk})" : "")}");
            Console.WriteLine($"방어력 : {Defense} {(equippedDef > 0 ? $"(+{equippedDef})" : "")}");
            Console.WriteLine($"체력 : {Max_Health}");
            Console.WriteLine($"Gold : {Gold}");
        }
    }

    public class Archer : IPlayerCharacter
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Max_Health { get; set; }
        public int Current_Health { get; set; }
        public int Gold { get; set; }
        public Item EquippedWeapon { get; set; }
        public Item EquippedArmor { get; set; }
        public Inventory Inventory { get; set; }

        public Archer(string name)
        {
            Level = 1;
            Name = name;
            Job = "궁수";
            Attack = 8;
            Defense = 3;
            Max_Health = 100;
            Current_Health = 100;
            Gold = 1500;
            Inventory = new Inventory();
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
                Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력 {Current_Health} -> {Current_Health - damage}");
                Current_Health -= damage;
            }
        }

        public void ShowStatus()
        {
            int equippedAtk = EquippedWeapon != null ? EquippedWeapon.AttackBouns : 0;
            int equippedDef = EquippedArmor != null ? EquippedArmor.DefenseBouns : 0;

            Console.WriteLine($"\nLV. {Level:D2}");
            Console.WriteLine($"{Name} {{ {Job} }}");
            Console.WriteLine($"공격력 : {Attack} {(equippedAtk > 0 ? $"(+{equippedAtk})" : "")}");
            Console.WriteLine($"방어력 : {Defense} {(equippedDef > 0 ? $"(+{equippedDef})" : "")}");
            Console.WriteLine($"체력 : {Max_Health}");
            Console.WriteLine($"Gold : {Gold}");
        }
    }
}