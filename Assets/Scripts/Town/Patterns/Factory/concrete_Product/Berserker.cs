using Product;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Hero
{
    public Berserker(string name, int heroClass, int defense, int maxHP, int currentHP, int attack)
        : base(name, heroClass, defense, maxHP, currentHP, attack)
    {
        Name = name;
        HeroClass = heroClass;
        Defense = defense;
        MaxHP = maxHP;
        CurrentHP = currentHP;
        Attack = attack;
    }


}
