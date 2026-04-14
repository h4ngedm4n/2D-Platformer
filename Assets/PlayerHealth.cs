using JetBrains.Annotations;
using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float health;
    private bool CanReceiveDamage = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float newhealth, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;

    public delegate void HealthInitHandler(float newhealth);
    public event HealthInitHandler OnHealthInisialised;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
    {
        health = maxHealth;
        OnHealthInisialised?.Invoke(health);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddDamage(float damage)
    {
        if (CanReceiveDamage)
        {

            health -= damage;
            OnHealthChanged?.Invoke(health, -damage);
            CanReceiveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
            Debug.Log(health);
        }
    }

    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);  
        callback.Invoke();
    }


    private void ResetInvincibility()
    {
        CanReceiveDamage = true;
    }


    public void AddHealth(float addhealth)
    {
        health += addhealth;
        OnHealthChanged?.Invoke(health, addhealth);

        Debug.Log(health);
    }
}