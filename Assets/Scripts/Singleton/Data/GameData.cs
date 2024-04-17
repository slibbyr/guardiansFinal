using Product;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public string name;
    public int heroClass;
    public int defense;
    public int maxHP;
    public int currentHP;
    public int attack;
    public List<Hero> heroes;

    public Hero[] heroes;

    public bool gameCompleted;

    public GameData()
    {
        this.name = "Arian";
        playerPosition = Vector3.zero;
        this.heroClass = 0;
        this.defense = 0;
        this.maxHP = 0;
        this.currentHP = 0;
        this.attack = 0;

        this.gameCompleted = false;
    }

    public void PrintGameData()
    {
        Debug.Log($"Hero Name: {heroName}");
        Debug.Log($"Hero Class: {heroClass}");
        Debug.Log($"Defense: {defense}");
        Debug.Log($"Max HP: {maxHP}");
        Debug.Log($"Current HP: {currentHP}");
        Debug.Log($"Attack: {attack}");
        Debug.Log($"Game Completed: {gameCompleted}");
        Debug.Log($"Your team is:  {heroes}");
    }
}