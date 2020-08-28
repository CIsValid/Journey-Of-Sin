using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Health
    public int health = 5;
    private int m_health = 5;
    public delegate void OnHealthChangeDelegate(int newHealth);
    public event OnHealthChangeDelegate OnHealthChange;



    private void Update()
    {
        HealthCheck();

    }

    private void HealthCheck()
    {
        // Checks If Player Health Has Changed
        if (health != m_health && OnHealthChange != null)
        {
            m_health = health;
            OnHealthChange(health);
        }

        if(health <= 0)
        {
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        // Play death animation
        // Fade to black
        this.gameObject.transform.position = CheckPoint.GetTheActiveCheckPointPosition();
        health = 5;
        // fade in
    }

}
