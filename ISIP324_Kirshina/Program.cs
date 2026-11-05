using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ISIP324_Kirshina
{
    internal class Program
    {
        public abstract class Entity
        {
            public string Name { get; protected set; }
            public int Health { get; set; }
            public int MaxHealth { get; private set; }
            public int Attack { get; protected set; }
            public int Defense { get; protected set; }
            protected Random random;
            public Entity(string name, int health, int maxHealth, int attack, int defense)
            {
                Name = name;
                Health = health;
                MaxHealth = maxHealth;
                Attack = attack;
                Defense = defense;
                random = new Random();
            }
            public virtual int GetDamage()
            {
                return Attack;
            }
            public virtual string GetSpecialAbility()
            {
                return "Нет особой способности";
            }
        }
        public abstract class Item
        {
            public string Name { get; protected set; }
            protected Item(string name)
            {
                Name = name;
            }
            public abstract void ShowStats();
        }
        public class Weapon : Item
        {
            public int Damage { get; }
            public Weapon(string name, int damage)
                : base(name)
            {
                Damage = damage;
            }
            public override void ShowStats()
            {
                Console.WriteLine($"Оружие: {Name}, урон: {Damage}");
            }
        }
        public class Armor : Item
        {
            public int Defense { get; }
            public Armor(string name, int defense)
                : base(name)
            {
                Defense = defense;
            }
            public override void ShowStats()
            {
                Console.WriteLine($"Броня: {Name}, защита: +{Defense}");
            }
        }
        public class HealingPotion : Item
        {
            public HealingPotion()
                : base("Лечебное зелье")
            {

            }
            public override void ShowStats()
            {
                Console.WriteLine("Лечебное зелье. Полностью восстанавливает здоровье");
            }
        }
        public class Player : Entity
        {
            public Weapon EqWeapon { get; set; }
            public Armor EqArmor { get; set; }
            public bool IsFrozen { get; set; }
            public Player(
                string name = "Игрок",
                int health = 100,
                int maxHealth = 100,
                int attack = 10,
                int defense = 5)
                :base(name, health, maxHealth, attack, defense)
            {
                EqWeapon = new Weapon("Кулаки", 5);
                EqArmor = new Armor("Мешок из под картошки", 0);
            }
            public override int GetDamage()
            {
                return Attack + EqWeapon.Damage;
            }
            public override string GetSpecialAbility()
            {
                return "Нет способности";
            }
            public int GetDefense()
            {
                return Defense + EqArmor.Defense;
            }
            public void Heal()
            {
                Health = MaxHealth;
                Console.WriteLine("Вы полностью исцелены!");
            }
        }
        public abstract class Enemy : Entity
        {
            protected Enemy(string name, int health, int maxHealth, int attack, int defense) 
                : base(name, health, maxHealth, attack, defense)
            {
            }
        }
        public class Goblin : Enemy
        {
            private int critChance = 20;
            public int CritChance
            {
                get { return critChance; }
            }
            public Goblin(
                string name = "Гоблин",
                int health = 30,
                int maxHealth = 30,
                int attack = 8,
                int defense = 3
                )
                : base(name, health, maxHealth, attack, defense)
            {
            }
            public override int GetDamage()
            {
                int damage = Attack;
                if (random.Next(100) < CritChance)
                {
                    damage *= 2;
                    Console.WriteLine("Критический урон!");
                }
                return damage;
            }
            public override string GetSpecialAbility()
            {
                return $"Шанс крита: {CritChance}%";
            }
        }
        public class Skeleton : Enemy
        {
            public Skeleton(
                string name = "Скелет",
                int health = 25,
                int maxHealth = 25,
                int attack = 10,
                int defense = 4
                )
                : base(name, health, maxHealth, attack, defense)
            {
            }
            public override int GetDamage()
            {
                return Attack;
            }
            public override string GetSpecialAbility()
            {
                return "Игнорирует защиту игрока";
            }
        }
        public class Magician : Enemy
        {
            private int freezeChance = 25;
            public int FreezeChance
            {
                get { return freezeChance; }
            }
            public Magician(
                string name = "Маг",
                int health = 40,
                int maxHealth = 40,
                int attack = 12,
                int defense = 2
                )
                : base(name, health, maxHealth, attack, defense)
            {
            }
            public override int GetDamage()
            {
                int damage = Attack;
                if (random.Next(100) < FreezeChance)
                {
                    Console.WriteLine("Вас заморозили! Вы пропускаете следующий ход!");
                    return 0;
                }
                return damage;
            }
            public override string GetSpecialAbility()
            {
                return $"Шанс заморозки: {FreezeChance}%";
            }
        }
        public abstract class Boss : Enemy
        {
            protected Boss(string name, int health, int maxHealth, int attack, int defense)
                : base(name, health, maxHealth, attack, defense) { }
        }
        public class VVG : Boss
        {
            private int critChance = 30;
            public VVG()
                : base("ВВГ", 30, 30, 8, 3)
            {
                this.Health *= 2;
                this.Attack = Convert.ToInt32(this.Attack * 1.5);
                this.Defense = Convert.ToInt32(this.Defense * 1.2);
            }
            public override int GetDamage()
            {
                int damage = Attack;
                if (random.Next(100) < critChance)
                {
                    damage *= 2;
                    Console.WriteLine("Критический удар!");
                }
                return damage;
            }

            public override string GetSpecialAbility()
            {
                return $"Шанс крита: {critChance}%";
            }
        }
        public class Kovalsky : Boss
        {
            public Kovalsky()
                : base("Ковальский", 25, 25, 10, 4)
            {
                this.Health = Convert.ToInt32(this.Health * 2.5);
                this.Attack = Convert.ToInt32(this.Attack * 1.3);
                this.Defense = Convert.ToInt32(this.Defense * 1.4);
            }
            public override int GetDamage()
            {
                return Attack;
            }
            public override string GetSpecialAbility()
            {
                return "Игнорирует защиту игрока";
            }
        }
        public class ArchMagicianCpp : Boss
        {
            private int freezeChance = 35;
            public ArchMagicianCpp()
                : base("Архимаг C++", 40, 40, 12, 2)
            {
                this.Health = Convert.ToInt32(this.Health * 1.8);
                this.Attack = Convert.ToInt32(this.Attack * 1.6);
                this.Defense = Convert.ToInt32(this.Defense * 1.1);
            }
            public override int GetDamage()
            {
                int damage = Attack;
                if (random.Next(100) < freezeChance)
                {
                    Console.WriteLine("Архимаг заморозил вас! Вы пропускаете следующий ход!");
                    return 0;
                }
                return damage;
            }
            public override string GetSpecialAbility()
            {
                return $"Шанс заморозки: {freezeChance}%";
            }
        }
        public class PestovCmm : Boss
        {
            public PestovCmm()
                : base("Пестов C--", 25, 25, 10, 4)
            {
                this.Health = Convert.ToInt32(this.Health * 1.3);
                this.Attack = Convert.ToInt32(this.Attack * 1.8);
                this.Defense = Convert.ToInt32(this.Defense * 0.6);
            }
            public override int GetDamage()
            {
                return Attack;
            }

            public override string GetSpecialAbility()
            {
                return "Игнорирует защиту игрока";
            }
        }
        static void Main(string[] args)
        {
            Player player = new Player();
            Random random = new Random();
            int turnCount = 0;
            bool gameRunning = true;

            Console.WriteLine($"Добро пожаловать, {player.Name}!");
            Console.WriteLine($"Ваши характеристики: HP={player.Health}, Атака={player.Attack}, Защита={player.Defense}");

            while (gameRunning == true && player.Health > 0)
            {
                turnCount++;
                Console.WriteLine($"ХОД {turnCount}");
                Console.WriteLine($"Ваше здоровье: {player.Health}/{player.MaxHealth}");

                if (turnCount % 10 == 0)
                {
                    Console.WriteLine("ВСТРЕЧАЙТЕ БОССА");
                    Boss boss = GetRandomBoss(random);
                    Console.WriteLine($"На вас напал: {boss.Name}!");
                    Console.WriteLine($"Характеристики босса: HP={boss.Health}, Атака={boss.Attack}, Защита={boss.Defense}");
                    Console.WriteLine($"Способность: {boss.GetSpecialAbility()}");

                    Combat(player, boss, random);
                }
                else
                {
                    if (random.Next(2) == 0)
                    {
                        Console.WriteLine("Вы нашли сундук!");
                        OpenChest(player, random);
                    }
                    else
                    {
                        Enemy enemy = GetRandomEnemy(random);
                        Console.WriteLine($"На вас напал: {enemy.Name}!");
                        Console.WriteLine($"Характеристики врага: HP={enemy.Health}, Атака={enemy.Attack}, Защита={enemy.Defense}");
                        Console.WriteLine($"Способность: {enemy.GetSpecialAbility()}");

                        Combat(player, enemy, random);
                    }
                }
                if (player.Health <= 0)
                {
                    Console.WriteLine("ВЫ ПОМЕРЛИ!");
                    Console.WriteLine($"Вы продержались {turnCount} ходов.");
                    gameRunning = false;
                }
                else
                {
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                }
            }
            if (!gameRunning)
            {
                Console.WriteLine("ИГРА ОКОНЧЕНА");
                Console.WriteLine($"Всего ходов: {turnCount}");
            }
        }

        static Enemy GetRandomEnemy(Random random)
        {
            int enemyType = random.Next(3);

            switch (enemyType)
            {
                case 0:
                    return new Goblin();
                case 1:
                    return new Skeleton();
                case 2:
                    return new Magician();
                default:
                    return new Goblin();
            }
        }

    }
}
