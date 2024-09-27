namespace Team21Project
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Potion
    }
    public interface IItem
    {
        string Name { get; set; }
        string Desc { get; set; }
        int AttackBouns {  get; set; }
        int DefenseBouns { get; set; }
        int Price { get; set; }
        ItemType ItemType { get; set; }
        bool IsEquipped { get; set; }

        void Uesed(int Heal, Wrroior wrroior);
    }

    public class WrroiorItme : IItem
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int AttackBouns { get; set; }
        public int DefenseBouns { get; set; }
        public int Price { get; set; }
        public ItemType ItemType { get; set; }
        public bool IsEquipped { get; set; }

        public WrroiorItme(string name, string desc, int attackBouns, int defenseBouns, int price, ItemType itemType)
        {
            Name = name;
            Desc = desc;
            AttackBouns = attackBouns;
            DefenseBouns = defenseBouns;
            Price = price;
            ItemType = itemType;
            IsEquipped = false;
        }

        public void Uesed(int Heal, Wrroior wrroior)
        {
            Console.WriteLine($"{wrroior.Name}의 체력이 회복 되었습니다. " +
                $"{wrroior.Current_Health} -> {wrroior.Current_Health + Heal}");
        }

        public string GetItemInfo()
        {
            string equippedStatus = IsEquipped ? "[E]" : "";
            return $"- {equippedStatus}{Name}   | {Desc}";
        }
    }

    public class ThiefItme : IItem
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int AttackBouns { get; set; }
        public int DefenseBouns { get; set; }
        public int Price { get; set; }
        public ItemType ItemType { get; set; }
        public bool IsEquipped { get; set; }

        public ThiefItme(string name, string desc, int attackBouns, int defenseBouns, int price, ItemType itemType)
        {
            Name = name;
            Desc = desc;
            AttackBouns = attackBouns;
            DefenseBouns = defenseBouns;
            Price = price;
            ItemType = itemType;
            IsEquipped = false;
        }

        public void Uesed(int Heal, Wrroior wrroior)
        {
            Console.WriteLine($"{wrroior.Name}의 체력이 회복 되었습니다. " +
                $"{wrroior.Current_Health} -> {wrroior.Current_Health + Heal}");
        }

        public string GetItemInfo()
        {
            string equippedStatus = IsEquipped ? "[E]" : "";
            return $"- {equippedStatus}{Name}   | {Desc}";
        }
    }

    public class ArcherItme : IItem
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int AttackBouns { get; set; }
        public int DefenseBouns { get; set; }
        public int Price { get; set; }
        public ItemType ItemType { get; set; }
        public bool IsEquipped { get; set; }

        public ArcherItme(string name, string desc, int attackBouns, int defenseBouns, int price, ItemType itemType)
        {
            Name = name;
            Desc = desc;
            AttackBouns = attackBouns;
            DefenseBouns = defenseBouns;
            Price = price;
            ItemType = itemType;
            IsEquipped = false;
        }

        public void Uesed(int Heal, Wrroior wrroior)
        {
            Console.WriteLine($"{wrroior.Name}의 체력이 회복 되었습니다. " +
                $"{wrroior.Current_Health} -> {wrroior.Current_Health + Heal}");
        }

        public string GetItemInfo()
        {
            string equippedStatus = IsEquipped ? "[E]" : "";
            return $"- {equippedStatus}{Name}   | {Desc}";
        }
    }
}