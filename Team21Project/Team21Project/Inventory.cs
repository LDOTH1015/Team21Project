using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team21Project
{
    public class Inventory
    {
        public List<Item> Items { get; set; }
        public Item EquippedWeapon { get; set; }
        public Item EquippedArmor { get; set; }

        public Inventory()
        {
            Items = new List<Item>();
        }

        public void ShowInven()
        {
            if (Items.Count > 0)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine($"[ {i+1} ] {Items[i].GetItemInfo()}");
                }
            }
            else
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
            }
        }

        public void EquippedItem(int itemIdx, IPlayerCharacter character)
        {
            Item items = Items[itemIdx];
            if (character.JobType == (items.JobItemType.ToString()) || items.JobItemType.ToString() == "All")
            {
                if (!items.IsEquipped && items.ItemType == ItemType.Weapon && EquippedWeapon == null)
                {
                    character.Attack += items.AttackBouns;
                    character.Defense += items.DefenseBouns;
                    items.IsEquipped = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{items.Name}을(를) 장착했습니다.");
                    Console.ResetColor();
                    EquippedWeapon = items;
                }
                else if (!items.IsEquipped && items.ItemType == ItemType.Armor && EquippedArmor == null)
                {
                    character.Attack += items.AttackBouns;
                    character.Defense += items.DefenseBouns;
                    items.IsEquipped = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{items.Name}을(를) 장착했습니다.");
                    Console.ResetColor();
                    EquippedArmor = items;
                }
                else if (!items.IsEquipped && items.ItemType == ItemType.Weapon && EquippedWeapon != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("무기를 이미 장착중 입니다.");
                    Console.ResetColor();
                }
                else if (!items.IsEquipped && items.ItemType == ItemType.Armor && EquippedArmor != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("방어구를 이미 장착중 입니다.");
                    Console.ResetColor();
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
                    character.Attack -= items.AttackBouns;
                    character.Defense -= items.DefenseBouns;
                    items.IsEquipped = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{items.Name}(을)를 해체했습니다.");
                    Console.ResetColor();
                }
                else if (items.ItemType == ItemType.Potion)
                {
                    items.Used(50, character);
                    character.Inventory.Items.Remove(items);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("이 직업의 아이템이 아닙니다.");
                Console.ResetColor();
            }
        }
    }
}
