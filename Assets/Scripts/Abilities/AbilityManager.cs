using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager instance;

    [Header("Current Location of Player")]
    public string worldLocation;

    [Header("Distance To Spawn Ability")] 
    public float distance;

    // Desert Ability Stats
    [Header("Desert Ability Values")] 
    public GameObject tumbleWeedObj;
    public float desertAbilityCooldown; // The actual Cool Down
    public float tumbleWeedCooldown; // Callable in script
    public float tumbleSpeed;
    public float radius;

    private Vector3 playerOffset;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        playerOffset =  transform.position + transform.forward * distance;
        
        switch (worldLocation)
        {
            case "MainIsland":
                TumbleWeedAbility();
                break;
            
            case "Desert":
                TumbleWeedAbility();
                break;
            
            case "UnderWater":
                
                break;
            
            case "Limbo":
                
                break;
            
            case "Mountain":
                
                break;
            
            case "Jungle":
                
                break;
        }
        
        // Cooldowns

        if (tumbleWeedCooldown > 0)
        {
            tumbleWeedCooldown -= Time.deltaTime;
        }
    }

    public void TumbleWeedAbility()
    {
        if (Input.GetKey(KeyCode.Mouse0) && tumbleWeedCooldown <= 0)
        {
            Debug.Log("TumbleWeed :D");

            GameObject tumbleWeedObjectInstancer = Instantiate(tumbleWeedObj, playerOffset, transform.rotation);
            tumbleWeedObjectInstancer.GetComponent<Rigidbody>().velocity = this.GetComponent<CharacterController>().velocity;
            tumbleWeedObjectInstancer.GetComponent<Rigidbody>().AddForce(transform.forward * tumbleSpeed, ForceMode.Impulse);
            tumbleWeedObjectInstancer.GetComponent<SphereCollider>().radius = radius;
            
            tumbleWeedCooldown = desertAbilityCooldown;
        }
    }
}
