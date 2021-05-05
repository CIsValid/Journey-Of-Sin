using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [Header("Current Location of Player")]
    public string worldLocation;
    
    // Health
    public float health = 5;
    private float m_health = 5;
    public delegate void OnHealthChangeDelegate(float newHealth);
    public event OnHealthChangeDelegate OnHealthChange;
    
    public int collectedFlames;
    public int collectedfFlowers; 

    public bool isJumping;
    public bool isFlying;
    public bool isCamoflaged;
    public bool isInMineCart;

    private Renderer rend;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        HealthCheck();
        
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

    private void worldHealthManager()
    {
        switch (worldLocation)
        {
            case "MainIsland":
                break;
            
            case "Desert":
                break;
            
            case "UnderWater":
                
                break;
            
            case "Limbo":
                rend.material.SetFloat("GlitchChangePerc", 1 / health);
                break;
            
            case "Mountain":
                
                break;
            
            case "Jungle":
                break;
        }
    }

}
