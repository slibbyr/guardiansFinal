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
            case 2:
                Debug.Log("starting new Paladin");
                return new Paladin("Paladin", 2, 5, 50, 50, 25);
                Debug.Log("created Paladin");
                break;
            case 3:
                Debug.Log("starting new Elf");
                return new Elf("Elf", 3, 5, 50, 50, 25);
                Debug.Log("created Elf");
                break;
            default:
                return new Paladin("Paladin", 2, 5, 50, 50, 25);
                Debug.Log("new Default");
                break;
        }
    }

}
