using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(InteractText))]
public class ObjectPickUp : MonoBehaviour
{
    private PlayerManager _playerManager;
    
    public enum ItemToPickUp
    {
        Flames, Flowers
    }

    public ItemToPickUp itemToPickUp;

    private void OnTriggerStay(Collider other)
    {
        InputHandling(other);
    }

    private void WhatItemToPickUp()
    {
        switch (itemToPickUp)
        {
            case ItemToPickUp.Flames:
                _playerManager.collectedFlames++;
                break;
            
            case ItemToPickUp.Flowers:
                _playerManager.collectedfFlowers++;
                break;
        }
    }

    private void InputHandling(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_playerManager)
            {
                _playerManager = other.GetComponent<PlayerManager>();
            }
            
            if (Input.GetKey(KeyCode.E) && _playerManager)
            {
                WhatItemToPickUp();
                Destroy(this.gameObject);

            }
        }
    }
}
