using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlvl : MonoBehaviour
{
    public float coinsToEnter;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float playerCoins = collision.GetComponent<playersCoins>().coin;
        if (playerCoins >= coinsToEnter )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
                