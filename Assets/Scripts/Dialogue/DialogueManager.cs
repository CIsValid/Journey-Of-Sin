using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCamera;
    public GameObject dialogueCamera;
    public GameObject canvas;
    public Text text;

    public List<string> dialogueList = new List<string>();

    public bool hasDialogueBeenHad;

    private void Update()
    {

        if(hasDialogueBeenHad)
        {
            EnableAllControls();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!hasDialogueBeenHad)
        {
            if (other.CompareTag("Player"))
            {
                canvas.SetActive(true);

                if (dialogueCamera != null)
                {
                    DisableAllControls();

                    //activate Camera
                    playerCamera.SetActive(false);
                    dialogueCamera.SetActive(true);
                }

                DisableAllControls();

            }
        }

    }

    public void DisableAllControls()
    {
        player.GetComponent<GamepadChecker>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerControllerPs4>().enabled = false;
        player.GetComponent<PlayerControllerXbox>().enabled = false;

        playerCamera.GetComponent<CameraController>().enabled = false;
        playerCamera.GetComponent<CameraControllerConsole>().enabled = false;
        playerCamera.GetComponent<CameraControllerPs>().enabled = false;
    }

    public void EnableAllControls()
    {
        playerCamera.SetActive(true);
        dialogueCamera.SetActive(false);

        canvas.SetActive(false);

        player.GetComponent<GamepadChecker>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerControllerPs4>().enabled = true;
        player.GetComponent<PlayerControllerXbox>().enabled = true;

        playerCamera.GetComponent<CameraController>().enabled = true;
        playerCamera.GetComponent<CameraControllerConsole>().enabled = true;
        playerCamera.GetComponent<CameraControllerPs>().enabled = true;

        Destroy(this.gameObject);

    }
}
