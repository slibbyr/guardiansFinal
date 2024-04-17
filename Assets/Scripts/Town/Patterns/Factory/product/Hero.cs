using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Product
{
    public abstract class Hero
    {
        private string name;
        private int heroClass;
        private int defense;
        private int maxHP;
        private int currentHP;
        private int attack;

        public Hero(string nombre, int heroClass, int defense, int maxHP, int currentHP, int attack)
        {
            this.name = nombre;
            this.heroClass = heroClass;
            this.defense = defense;
            this.maxHP = maxHP;
            this.currentHP = currentHP;
            this.attack = attack;
        }

        public Hero()
        {
            this.name = "";
            this.heroClass = 0;
            this.defense = 0;
            this.maxHP = 0;
            this.currentHP = 0;
            this.attack = 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int HeroClass
        {
            get { return heroClass; }
            set { heroClass = value; }
        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public int MaxHP
        {
            get { return maxHP; }
            set { maxHP = value; }
        }

        public int CurrentHP
        {
            get { return currentHP; }
            set { currentHP = value; }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

    }
}

