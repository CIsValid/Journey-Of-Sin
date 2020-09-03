using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueCamera;

    public List<string> dialogueHolder = new List<string>();

    public List<string> goodDialogueHolder = new List<string>();
    public List<string> badDialogueHolder = new List<string>();

    public int pointsToGive;

    public int pointsForGoodDialogue;

    private int numberOfSentances;

    public bool affectStats;
    public bool goodOrBadDialogue;
    public bool CustomDialogueCamera;

    private bool dialogueHasStarted;

    private DialogueController dialogueController;

    private BranchingStats branchingStats;

    private void Start()
    {
        dialogueController = DialogueController.instance;
        branchingStats = BranchingStats.instance;

        switch (goodOrBadDialogue)
        {
            case true:
                if(branchingStats.goodPoints >= pointsForGoodDialogue)
                {
                    numberOfSentances = goodDialogueHolder.Count;
                }
                else
                {
                    numberOfSentances = badDialogueHolder.Count;
                }
                break;

            case false:
                numberOfSentances = dialogueHolder.Count;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            if(CustomDialogueCamera)
            {
                dialogueController.dialogueCameraHolder = dialogueCamera;

                dialogueController.ActivateDialogueCamera();
            }

            dialogueController.DisableAllControls();

            if (goodOrBadDialogue)
            {
                if (branchingStats.goodPoints >= pointsForGoodDialogue)
                {
                    for (int i = 0; i < numberOfSentances; i++)
                    {
                        Debug.Log(goodDialogueHolder[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < numberOfSentances; i++)
                    {
                        Debug.Log(badDialogueHolder[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < numberOfSentances; i++)
                {
                    Debug.Log(dialogueHolder[i]);
                }
            }
        }
    }

}
