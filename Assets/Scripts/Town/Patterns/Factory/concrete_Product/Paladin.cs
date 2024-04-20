using Product;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConcreteProduct
{
    public class Paladin : Hero
    {
        public Paladin()
        {
            
        }

        public Paladin(string name, int heroClass, int defense, int maxHP, int currentHP, int attack)
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


