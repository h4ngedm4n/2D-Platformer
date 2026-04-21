using System;
using TMPro;
using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnHealthInisialised += OnHealthInit;
    }

    private void OnHealthInit(float newhealth)
    {
       healthText.text = newhealth.ToString();
    }

    public void OnHealthChanged(float newhealth, float amountChanged)
    {
        // Debug.Log("On Health Changed Event");
        healthText.text = newhealth.ToString();
    }

    
}
