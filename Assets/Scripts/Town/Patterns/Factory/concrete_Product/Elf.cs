using Product;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConcreteProduct
{
    public class Elf : Hero
    {
        public Elf()
        {
            
        }

        public Elf(string name, int heroClass, int defense, int maxHP, int currentHP, int attack)
        {
            Name = name;
            HeroClass = heroClass;
            Defense = defense;
            MaxHP = maxHP;
            CurrentHP = currentHP;
            Attack = attack;
        }
    }
}


