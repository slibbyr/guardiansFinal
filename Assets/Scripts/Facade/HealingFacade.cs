using Product;
using System.Collections.Generic;

public class HealingFacade
{
    private List<Hero> heroes;

    public HealingFacade(List<Hero> heroes)
    {
        this.heroes = heroes;
    }

    public void HealAllHeroes()
    {
        foreach (Hero hero in heroes)
        {
            hero.CurrentHP = hero.MaxHP;
        }
    }
}