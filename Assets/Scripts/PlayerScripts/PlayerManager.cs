using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    // Health
    public int health = 5;
    private int m_health = 5;
    public delegate void OnHealthChangeDelegate(int newHealth);
    public event OnHealthChangeDelegate OnHealthChange;

    public bool isJumping;
    public bool isFlying;
    public bool isInMineCart;

    private void Start()
    {
        instance = this;
    }

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

        if(isJumping)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isFlying = true;
            }
        }

        if(isFlying)
        {
            this.gameObject.GetComponent<TestFlightController>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<TestFlightController>().enabled = false;
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
