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
        //public class Weapon : Item
        //{
        //    public int Damage { get; }
        //    public Weapon(string name, int damage)
        //        :base (name)
        //    {
        //        Damage = damage;
        //    }
        //}
        static void Main(string[] args)
        {
        }
    }
}
