using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Homework10
{

    abstract class Alien {
        private int health; //0 = dead, 100 = full
        private string name;

        protected Alien(int health, string name) {
            this.health = health;
            this.name = name;
        }

        public abstract int getDamage();
    }

    class SnakeAlien : Alien {
        public SnakeAlien(int health, string name) : base(health, name) { }

        public override int getDamage() { return 10; }
    }

    class OgreAlien : Alien
    {
        public OgreAlien(int health, string name) : base(health, name) { }

        public override int getDamage() { return 6; }
    }

    class MarshmallowManAlien : Alien
    {
        public MarshmallowManAlien(int health, string name) : base(health, name) { }

        public override int getDamage() { return 1; }
    }

    class AlienPack
    {
        private Alien[] aliens;

        public AlienPack(int numAliens)
        {
            aliens = new Alien[numAliens];
        }

        public void AddAlien(Alien newAlien, int index)
        {
            aliens[index] = newAlien;
        }
        public Alien[] GetAliens()
        {
            return aliens;
        }
        public int CalculateDamage()
        {
            int damage = 0;

            foreach (Alien a in aliens)
            {
                damage += a.getDamage();
            }
            return damage;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            AlienPack pack = new AlienPack(4);
            pack.AddAlien(new SnakeAlien(100,"Joe"),0);
            pack.AddAlien(new OgreAlien(100, "Joe"), 1);
            pack.AddAlien(new MarshmallowManAlien(100, "Joe"), 2);
            pack.AddAlien(new SnakeAlien(100, "Joe"), 3);
            Console.Write(pack.CalculateDamage());
        }
    }
}
