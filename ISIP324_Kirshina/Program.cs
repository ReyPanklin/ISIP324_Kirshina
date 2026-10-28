using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static void Main(string[] args)
        {
        }
    }
}
