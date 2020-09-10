using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchingStats : MonoBehaviour
{
    public static BranchingStats instance;

    public int goodPoints;
    public int badPoints;

    private void Start()
    {
        instance = this;
    }
}
