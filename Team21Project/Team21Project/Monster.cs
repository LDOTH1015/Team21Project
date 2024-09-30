using System.Numerics;

namespace Team21Project
{
    public class Monster
    {
        // 이름, 레벨, hp, 공격력, 경험치, 스피드
        public string Name { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public bool IsDead { get; set; }
        public int Exp { get; set; }


        public Monster(string name, int level, int hp, int attack, int exp)
        {
            Name = name;
            Level = level;
            Hp = hp;
            Attack = attack;
            Exp = exp;
            IsDead = false;
        }

        public void AttackPlayer()
        {
            Console.WriteLine($"{Name}이(가) {Attack}의 데미지를 입혔습니다!");
            AttackDamage();
        }

        public int AttackDamage() // 데미지를 줄때
        {
            return Attack; // 공격력만큼의 데미지를 반환
        }

        public void TakeDamage(int damage) // 데미지 받을때
        {
            Hp -= damage;
            if (Hp <= 0)
            {
                Hp = 0;
                Console.WriteLine($"{Name}이(가) 쓰러졌습니다!");
            }
            else
            {
                Console.WriteLine($"{Name}이(가) {damage}의 피해를 입었습니다. 남은 HP: {Hp}");
            }
        }

        public class Dragon : Monster
        {
            public Dragon() : base("드래곤", 12, 100, 20, 40) // 이름, 레벨, HP, 공격력, 경험치
            {

            }
        }

        public class Devil : Monster
        {
            public Devil() : base("악마", 10, 80, 15, 30)
            {

            }
        }

        public class Ork : Monster
        {
            public Ork() : base("오크", 8, 50, 10, 15)
            {

            }
        }
    }
}