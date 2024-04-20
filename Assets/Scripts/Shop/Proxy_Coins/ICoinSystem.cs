using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoinSystem
{
    void AddCoins(int amount);
    void SpendCoins(int amount);
    int GetCoinBalance();
}
