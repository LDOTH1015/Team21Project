﻿namespace Team21Project
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Potion
    }
    public enum JobItemType
    {
        WarriorItem,
        ThiefItem,
        ArcherItem,
        All
    }

    public class Item
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int AttackBouns { get; set; }
        public int DefenseBouns { get; set; }
        public int Price { get; set; }
        public ItemType ItemType { get; set; }
        public JobItemType JobItemType { get; set; }
        public bool IsEquipped { get; set; }

        public Item(string name, int attackBouns, int defenseBouns, string desc, int price, ItemType itemType, JobItemType jobItemType)
        {
            Name = name;
            Desc = desc;
            AttackBouns = attackBouns;
            DefenseBouns = defenseBouns;
            Price = price;
            ItemType = itemType;
            JobItemType = jobItemType;
            IsEquipped = false;
        }


        public void Used(int Heal, IPlayerCharacter character)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{character.Name}의 체력이 회복 되었습니다. " +
                $"{character.Current_Health} -> {(character.Current_Health + Heal >= 100 ? $"100" : character.Current_Health + Heal)}");
            Console.ResetColor();
            character.Current_Health += Heal;
            if (character.Current_Health > 100)
            {
                character.Current_Health = 100;
            }
        }

        public string GetItemInfo()
        {
            string equippedStatus = IsEquipped ? "[E]" : "";
            return $"{equippedStatus} {ItemInfoText()}";
        }
        public string ItemInfoText()
        {
            string text = "";

            if (ItemType == ItemType.Weapon)
            {
                text = $"{Name} | 공격력 [+{AttackBouns}] | {Desc} | [{ItemType}] | [{JobItemType}]";
            }
            else if (ItemType == ItemType.Armor)
            {
                text = $"{Name} | 방어력 [+{DefenseBouns}] | {Desc} | [{ItemType}] | [{JobItemType}]";
            }
            else
            {
                text = $"{Name} | 회복력 [+50] | [{ItemType}]";
            }
            return text;
        }
    }
}