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

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        this.name = "Arian";
        playerPosition = Vector3.zero;
    }

}