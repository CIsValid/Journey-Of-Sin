using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractText : MonoBehaviour
{
    [Header("If No Key Selected = Auto Set to E")]
    public KeyCode whatKeyToPress;
    [Header("If Empty = Press E To Interact!")]
    public string textToDisplay;
    
    private Text interactionText;

    private void Start()
    {
        HandleTextDisplay();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.enabled = true;
            
            InputDetected();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.enabled = false;

        }
    }

    private void InputDetected()
    {
        if (Input.GetKey(whatKeyToPress))
        {
            interactionText.enabled = false;
        }
    }
    
    private void HandleTextDisplay()
    {
        interactionText = GameObject.FindWithTag("InteractionText").GetComponent<Text>();

        if (textToDisplay == "") textToDisplay = "Press E To Interact!";
        
        switch (whatKeyToPress)
        {
            case KeyCode.None:
                whatKeyToPress = KeyCode.E;
                break;
        }

        interactionText.text = textToDisplay;
        
        interactionText.enabled = false;
    }
}
