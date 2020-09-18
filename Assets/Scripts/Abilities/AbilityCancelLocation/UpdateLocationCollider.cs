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
    AbilityManager abilityManager;

    private void Start()
    {
        abilityManager = AbilityManager.instance;
    }
    private void OnTriggerStay(Collider other)
    {
        abilityManager.worldLocation = worldOriginChange.ToString();
    }
}
