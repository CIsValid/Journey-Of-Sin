using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;

    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerManager>().health -= damage;
    }
}
