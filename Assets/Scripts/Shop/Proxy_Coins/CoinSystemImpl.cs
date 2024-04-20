public class CoinSystemImpl : ICoinSystem
{
    private int coins;

    public CoinSystemImpl(int initialCoins)
    {
        coins = initialCoins;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
        }
    }

    public int GetCoinBalance()
    {
        return coins;
    }
}
