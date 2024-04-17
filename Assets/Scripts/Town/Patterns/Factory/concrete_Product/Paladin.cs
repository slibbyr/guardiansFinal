using Product;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConcreteProduct
{
    public class Paladin : Hero
    {
        public Paladin(string nombre, int heroClass, int defense, int maxHP, int currentHP, int attack)
        {
            this.HeroClass = 1;
            this.Nombre = "Paladin";
        }
    }
}


