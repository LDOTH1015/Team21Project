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
                    Console.WriteLine($"{Items[i].GetItemInfo()}");
                }
            }
            else
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
            }
        }

        void EquippedItem(int itemIdx, IPlayerCharacter character)
        {
            Item items = Items[itemIdx];
            if (!items.IsEquipped && items.ItemType == ItemType.Weapon && EquippedWeapon == null)
            {
                character.Attack += items.AttackBouns;
                character.Defense += items.DefenseBouns;
                items.IsEquipped = true;
                Console.WriteLine($"{items.Name}을(를) 장착했습니다.");
                EquippedWeapon = items;
            }
            else if (!items.IsEquipped && items.ItemType == ItemType.Armor && EquippedArmor == null)
            {
                character.Attack += items.AttackBouns;
                character.Defense += items.DefenseBouns;
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
                character.Attack -= items.AttackBouns;
                character.Defense -= items.DefenseBouns;
                items.IsEquipped = false;
                Console.WriteLine($"{items.Name}(을)를 해체했습니다.");
            }
        }

        public void ShowEquipped(IPlayerCharacter character)
        {
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (int.TryParse(input, out int equipIdx)
                        && equipIdx >= 1 && equipIdx <= Items.Count)
                    {
                        EquippedItem(equipIdx - 1, character);
                        ShowEquipped(character);
                    }
                    else
                    {
                        Console.WriteLine("인벤토리에 아이템이 없습니다>>> 상점에서 아이템을 구매해주세요^-^!");
                }
                    break;
                case "0":
                break;
                default:
                Console.WriteLine("인벤토리에 아이템이 없습니다>>> 상점에서 아이템을 구매해주세요^-^!");
                break;
            }
        }

        /// <summary>
        /// 임시 테스트용 인벤토리 List추가
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

    }
}
