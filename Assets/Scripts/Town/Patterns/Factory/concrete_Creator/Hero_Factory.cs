using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Product;
using ConcreteProduct;

public class Hero_Factory : Abstract_Factory
{
    public Hero CreateHero(int pHeroClass)
    {
        switch (pHeroClass)
        {
            case 1:
                return new Paladin("Paladin", 1, 5, 50, 50, 25);
                break;
            default:
                return new Paladin();
                break;
        }
    }

}
