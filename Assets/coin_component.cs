using UnityEngine;

public class coin_component : MonoBehaviour
{
    public float addcoin = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<playersCoins>().AddCoin(addcoin);
        Destroy(gameObject);
    }





}
