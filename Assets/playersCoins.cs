using UnityEngine;

public class playersCoins : MonoBehaviour
{
    public float MaxCoin = 100;
    private float coin;
    

    public delegate void CoinChangeHandler(float addCoin);
    public event CoinChangeHandler OnCoinChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
