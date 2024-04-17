using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Product;

public interface Abstract_Factory
{
    Hero CreateHero(int pHeroClass);
}
