public class CoinSystemProxy : ICoinSystem
{
    private CoinSystemImpl coinSystem;

    public CoinSystemProxy(int initialCoins)
    {
        coinSystem = new CoinSystemImpl(initialCoins);
    }

    public void AddCoins(int amount)
    {
        coinSystem.AddCoins(amount);
    }

    public void SpendCoins(int amount)
    {
        coinSystem.SpendCoins(amount);
    }

    public int GetCoinBalance()
    {
        return coinSystem.GetCoinBalance();
    }
}
