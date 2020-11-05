using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AbilityManager))]
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
            }

            if (abilityManager && target)
            {
                abilityManager.worldLocation = worldOriginChange.ToString();
            }
        }
    }
}
