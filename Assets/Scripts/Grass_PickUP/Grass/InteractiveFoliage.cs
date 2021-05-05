using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveFoliage : MonoBehaviour
{
    public Material[] materials;
    public Transform player;
    private Vector3 thePos;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(writeToMaterial());
    }

    IEnumerator writeToMaterial()
    {
        while (true)
        {
            thePos = player.transform.position;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].SetVector("_pos", thePos);
            }

            yield return null;
        }
    }
}
