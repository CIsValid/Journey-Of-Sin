using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public bool activated = false;

    public static List<GameObject> checkPointList;



    private void Start()
    {
        checkPointList = GameObject.FindGameObjectsWithTag("CheckPoint").ToList();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(("Player")))
        {
            ActivateCheckPoint();
        }
    }

    private void ActivateCheckPoint()
    {
        foreach (GameObject cp in checkPointList)
        {
            cp.GetComponent<CheckPoint>().activated = false;
            //cp.GetComponent<animator>().SetBool("Active", false); Animation for checkpoint (if we wish to do so)

            
        }

        activated = true;
    }

    public static Vector3 GetTheActiveCheckPointPosition()
    {
        Vector3 result = new Vector3(0,0,0);

        if(checkPointList != null)
        {
            foreach (GameObject cp in checkPointList)
            {
                if (cp.GetComponent<CheckPoint>().activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }
        return result;
    }
}
