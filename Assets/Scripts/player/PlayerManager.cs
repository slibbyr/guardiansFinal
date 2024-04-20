using Product;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Hero_Factory mainHeroFactory;
    private Hero mainHero;
    private ICoinSystem coinSystem;
    private List<Hero> heroTeam = new List<Hero>();

    public static PlayerManager Instance { get; private set; }

    private void Awake()
    {
        mainHeroFactory = new Hero_Factory();
        mainHero = mainHeroFactory.CreateHero(1);
        coinSystem = new CoinSystemProxy(100);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        
        

        if (mainHero != null)
        {
            Debug.Log("Nombre del Heroe: " + mainHero.Name);
            Debug.Log("Defensa: " + mainHero.Defense);
            Debug.Log("Puntos de Vida Máximos: " + GetHeroMaxHP().ToString());
            Debug.Log("Puntos de Vida Actuales: " + GetHeroCurrentHP().ToString());
            Debug.Log("Ataque: " + mainHero.Attack);


            Debug.Log("Balance de Monedas Inicial: " + coinSystem.GetCoinBalance());
        }
        else
        {
            Debug.LogWarning("El héroe no se ha creado correctamente en PlayerManager.");
        }



    }

    public void AddCoins(int amount)
    {
        coinSystem.AddCoins(amount);
        UI.Instance.UpdateUI();
        Debug.Log("Added " + amount + " coins. Total coins: " + coinSystem.GetCoinBalance());
    }

    public void SpendCoins(int amount)
    {
        coinSystem.SpendCoins(amount);
        UI.Instance.UpdateUI();

    }
    public int GetCoinBalance()
    {
        return coinSystem.GetCoinBalance();
    }

    public int GetHeroCurrentHP()
    {
        Debug.Log(mainHero.Defense);

        if (mainHero != null)
        {
            return mainHero.CurrentHP;
        }
        else
        {
            Debug.LogWarning("Main Hero reference is null. Returning 0.");
            return 0;
        }
    }

    public int GetHeroMaxHP()
    {

        if (mainHero != null)
        {
            return mainHero.MaxHP;
        }
        else
        {
            Debug.LogWarning("Main Hero reference is null. Returning 0.");
            return 0;
        }
    }

    public void IncreaseHeroHealth(int amount)
    {
        mainHero.MaxHP += amount;
        UI.Instance.UpdateUI();
    }

    public void RestoreHeroHP()
    {
        mainHero.CurrentHP = mainHero.MaxHP;
        UI.Instance.UpdateUI();
        Debug.Log("HP RESTORED");
    }

    // Método para actualizar la salud del héroe
    public void UpdateHeroHealth(int amount)
    {
        if (mainHero != null)
        {
            mainHero.CurrentHP += amount;
            Debug.Log("Salud del héroe actualizada: " + mainHero.CurrentHP);
        }
        else
        {
            Debug.LogWarning("No se puede actualizar la salud del héroe porque la referencia es nula.");
        }
    }

    public void AddHeroToTeam(int heroClass)
    {
        Hero newHero = mainHeroFactory.CreateHero(heroClass);
        if (heroTeam.Count < 3)
        {
            heroTeam.Add(newHero);
            Debug.LogWarning("Añadido " + newHero.Name + " al equipo.");
            UI.Instance.UpdateUI();
        } else
        {
            Debug.LogWarning("Maxima Cantidad de Heroes en el Equipo Alcanzada");
        }
        
    }


    public string GetHeroesTeam()
    {
        string heroTeamString = "";

        if(heroTeam.Count > 0)
        {
            for (var i = 0; i < heroTeam.Count; i++)
            {
                heroTeamString += heroTeam[i].Name + "\n";
            }
            return heroTeamString;
        } else
        {
            Debug.LogWarning("No Team created");
            return null;
        }
        
    }

    public void DisplayTeamInfo()
    {
        Debug.Log("Equipo de Héroes:");
        foreach (Hero hero in heroTeam)
        {
            Debug.Log("Nombre: " + hero.Name + " | Clase: " + hero.HeroClass);
        }
    }

}
