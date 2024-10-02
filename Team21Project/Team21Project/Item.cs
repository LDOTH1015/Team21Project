namespace Team21Project
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Potion
    }

    public class Item
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int AttackBouns { get; set; }
        public int DefenseBouns { get; set; }
        public int Price { get; set; }
        public ItemType ItemType { get; set; }
        public bool IsEquipped { get; set; }

        public Item(string name, string desc, int attackBouns, int defenseBouns, int price, ItemType itemType)
        {
            Name = name;
            Desc = desc;
            AttackBouns = attackBouns;
            DefenseBouns = defenseBouns;
            Price = price;
            ItemType = itemType;
            IsEquipped = false;
        }

        public void Used(int Heal, IPlayerCharacter character)
        {
            Console.WriteLine($"{character.Name}의 체력이 회복 되었습니다. " +
                $"{character.Current_Health} -> {character.Current_Health + Heal}");
        }

        public string GetItemInfo()
        {
            string equippedStatus = IsEquipped ? "[E]" : "";
            return $"- {equippedStatus}{Name}   | {Desc}";
        }
    }
}