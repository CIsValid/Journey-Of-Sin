using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLocationCollider : MonoBehaviour
{
    public enum WorldOrigin
    {
        MainIsland,
        Desert,
        UnderWater,
        Limbo,
        Mountain,
        Jungle,

    }

    public WorldOrigin worldOriginChange;
    private AbilityManager abilityManager;
    private PlayerManager playerManager;
    private GameObject target;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!target)
            {
                target = other.gameObject;
            }

            if (!abilityManager && target)
            {
                abilityManager = target.GetComponent<AbilityManager>();
                playerManager = target.GetComponent<PlayerManager>();
            }

            if (abilityManager && target)
            {
                abilityManager.worldLocation = worldOriginChange.ToString();
                playerManager.worldLocation = worldOriginChange.ToString();
            }
        }
    }
}
