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
        void TakeDamage(int damge);
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

        public List<WrroiorItme> wrroiorItmes { get; set; }
        public WrroiorItme EquippedWeapon { get; set; }
        public WrroiorItme EquippedArmor { get; set; }

        public Wrroior(string name)
        {
            Name = name;
            Job = "전사";
            Attack = 10;
            Defense = 6;
            Max_Health = 100;
            Current_Health = 100;
            Gold = 1500;
            wrroiorItmes = new List<WrroiorItme>();
        }

        public void TakeDamage(int damage)
        {
            //Current_Health -= damage;
            Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력 {Current_Health} -> {Current_Health - damage}");
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

        public void ShowInven()
        {
            if (wrroiorItmes.Count > 0)
            {
                for (int i = 0; i < wrroiorItmes.Count; i++)
                {
                    Console.WriteLine($"{wrroiorItmes[i].GetItemInfo()}");
                }
            }
            else
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
            }
        }

        void EquippedItem(int itemIdx)
        {
            WrroiorItme items = wrroiorItmes[itemIdx];
            if (!items.IsEquipped && items.ItemType == ItemType.Weapon && EquippedWeapon == null)
            {
                Attack += items.AttackBouns;
                Defense += items.DefenseBouns;
                items.IsEquipped = true;
                Console.WriteLine($"{items.Name}을(를) 장착했습니다.");
                EquippedWeapon = items;
            }
            else if (!items.IsEquipped && items.ItemType == ItemType.Armor && EquippedArmor == null)
            {
                Attack += items.AttackBouns;
                Defense += items.DefenseBouns;
                items.IsEquipped = true;
                Console.WriteLine($"{items.Name}을(를) 장착했습니다.");
                EquippedWeapon = items;
            }
            else if(!items.IsEquipped && items.ItemType == ItemType.Weapon && EquippedWeapon != null)
            {
                Console.Write("무기를 이미 장착중 입니다.");
            }
            else if(!items.IsEquipped && items.ItemType == ItemType.Armor && EquippedArmor != null)
            {
                Console.Write("방어구를 이미 장착중 입니다.");
            }
            else if (items.IsEquipped)
            {
                if (items.ItemType == ItemType.Weapon)
                {
                    EquippedWeapon = null;
                }
                else
                {
                    EquippedArmor = null;
                }
                Attack -= items.AttackBouns;
                Defense -= items.DefenseBouns;
                items.IsEquipped = false;
                Console.WriteLine($"{items.Name}(을)를 해체했습니다.");
            }
        }

        public void ShowEquipped(string selectInput)
        {
            bool isExit = false;

            while(!isExit)
            {
                switch (selectInput)
                {
                    case "1":
                        if (int.TryParse(Console.ReadLine(), out int equipIdx)
                            && equipIdx >= 1 && equipIdx <= wrroiorItmes.Count)
                        {
                            EquippedItem(equipIdx - 1);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                    break;
                    case "0":
                        isExit = true; 
                    break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                    break;
                }
            }
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

        public List<ThiefItme> thiefItmes { get; set; }
        public ThiefItme EquippedWeapon { get; set; }
        public ThiefItme EquippedArmor { get; set; }

        public Thief(string name)
        {
            Name = name;
            Job = "도적";
            Attack = 7;
            Defense = 4;
            Max_Health = 100;
            Current_Health = 100;
            Gold = 1500;
            thiefItmes = new List<ThiefItme>();
        }

        public void TakeDamage(int damage)
        {
            //Current_Health -= damage;
            Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력 {Current_Health} -> {Current_Health - damage}");
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

        public void ShowInven()
        {
            if (thiefItmes.Count > 0)
            {
                for (int i = 0; i < thiefItmes.Count; i++)
                {
                    Console.WriteLine($"{thiefItmes[i].GetItemInfo()}");
                }
            }
            else
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
            }
        }

        void EquippedItem(int itemIdx)
        {
            ThiefItme items = thiefItmes[itemIdx];
            if (!items.IsEquipped && items.ItemType == ItemType.Weapon && EquippedWeapon == null)
            {
                Attack += items.AttackBouns;
                Defense += items.DefenseBouns;
                items.IsEquipped = true;
                Console.WriteLine($"{items.Name}을(를) 장착했습니다.");
                EquippedWeapon = items;
            }
            else if (!items.IsEquipped && items.ItemType == ItemType.Armor && EquippedArmor == null)
            {
                Attack += items.AttackBouns;
                Defense += items.DefenseBouns;
                items.IsEquipped = true;
                Console.WriteLine($"{items.Name}을(를) 장착했습니다.");
                EquippedWeapon = items;
            }
            else if (!items.IsEquipped && items.ItemType == ItemType.Weapon && EquippedWeapon != null)
            {
                Console.Write("무기를 이미 장착중 입니다.");
            }
            else if (!items.IsEquipped && items.ItemType == ItemType.Armor && EquippedArmor != null)
            {
                Console.Write("방어구를 이미 장착중 입니다.");
            }
            else if (items.IsEquipped)
            {
                if (items.ItemType == ItemType.Weapon)
                {
                    EquippedWeapon = null;
                }
                else
                {
                    EquippedArmor = null;
                }
                Attack -= items.AttackBouns;
                Defense -= items.DefenseBouns;
                items.IsEquipped = false;
                Console.WriteLine($"{items.Name}(을)를 해체했습니다.");
            }
        }

        public void ShowEquipped(string selectInput)
        {
            bool isExit = false;

            while (!isExit)
            {
                switch (selectInput)
                {
                    case "1":
                        if (int.TryParse(Console.ReadLine(), out int equipIdx)
                            && equipIdx >= 1 && equipIdx <= thiefItmes.Count)
                        {
                            EquippedItem(equipIdx - 1);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        break;
                    case "0":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
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

        public List<ArcherItme> ArcherItmes { get; set; }
        public ArcherItme EquippedWeapon { get; set; }
        public ArcherItme EquippedArmor { get; set; }

        public Archer(string name)
        {
            Name = name;
            Job = "궁수";
            Attack = 8;
            Defense = 3;
            Max_Health = 100;
            Current_Health = 100;
            Gold = 1500;
            ArcherItmes = new List<ArcherItme>();
        }

        public void TakeDamage(int damage)
        {
            //Current_Health -= damage;
            Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력 {Current_Health} -> {Current_Health - damage}");
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

        public void ShowInven()
        {
            if (ArcherItmes.Count > 0)
            {
                for (int i = 0; i < ArcherItmes.Count; i++)
                {
                    Console.WriteLine($"{ArcherItmes[i].GetItemInfo()}");
                }
            }
            else
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
            }
        }

        void EquippedItem(int itemIdx)
        {
            ArcherItme items = ArcherItmes[itemIdx];
            if (!items.IsEquipped && items.ItemType == ItemType.Weapon && EquippedWeapon == null)
            {
                Attack += items.AttackBouns;
                Defense += items.DefenseBouns;
                items.IsEquipped = true;
                Console.WriteLine($"{items.Name}을(를) 장착했습니다.");
                EquippedWeapon = items;
            }
            else if (!items.IsEquipped && items.ItemType == ItemType.Armor && EquippedArmor == null)
            {
                Attack += items.AttackBouns;
                Defense += items.DefenseBouns;
                items.IsEquipped = true;
                Console.WriteLine($"{items.Name}을(를) 장착했습니다.");
                EquippedWeapon = items;
            }
            else if (!items.IsEquipped && items.ItemType == ItemType.Weapon && EquippedWeapon != null)
            {
                Console.Write("무기를 이미 장착중 입니다.");
            }
            else if (!items.IsEquipped && items.ItemType == ItemType.Armor && EquippedArmor != null)
            {
                Console.Write("방어구를 이미 장착중 입니다.");
            }
            else if (items.IsEquipped)
            {
                if (items.ItemType == ItemType.Weapon)
                {
                    EquippedWeapon = null;
                }
                else
                {
                    EquippedArmor = null;
                }
                Attack -= items.AttackBouns;
                Defense -= items.DefenseBouns;
                items.IsEquipped = false;
                Console.WriteLine($"{items.Name}(을)를 해체했습니다.");
            }
        }

        public void ShowEquipped(string selectInput)
        {
            bool isExit = false;

            while (!isExit)
            {
                switch (selectInput)
                {
                    case "1":
                        if (int.TryParse(Console.ReadLine(), out int equipIdx)
                            && equipIdx >= 1 && equipIdx <= ArcherItmes.Count)
                        {
                            EquippedItem(equipIdx - 1);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        break;
                    case "0":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }
}