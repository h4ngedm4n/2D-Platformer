using UnityEngine;

public class playersCoins : MonoBehaviour
{
    public float MaxCoin = 999;
    public float coin;
    

    public delegate void CoinChangeHandler(float addCoin);
    public event CoinChangeHandler OnCoinChange;
    public event CoinChangeHandler OnCoinInnit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnCoinInnit?.Invoke(coin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(float addCoin)
    {
        coin += addCoin;
        OnCoinChange?.Invoke(coin);
        Debug.Log(coin);

    }


}
