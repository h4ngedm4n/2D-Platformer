using TMPro;
using UnityEngine;

public class CoinDisplayUI : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public playersCoins playercoins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playercoins.OnCoinChange += OnCoinChange;
        playercoins.OnCoinInnit += Playercoins_OnCoinInnit;
    }

    private void Playercoins_OnCoinInnit(float addCoin)
    {
        CoinText.text = addCoin.ToString();
    }

    public void OnCoinChange(float addCoin)
    {
        CoinText.text = addCoin.ToString();
      
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
