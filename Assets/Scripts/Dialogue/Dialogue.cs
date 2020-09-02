using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public List<string> dialogueHolder = new List<string>();

    public List<string> goodDialogueHolder = new List<string>();
    public List<string> badDialogueHolder = new List<string>();

    public int pointsToGive;

    public int pointsForGoodDialogue;

    private int numberOfSentances;

    public bool affectStats;
    public bool goodOrBadDialogue;

    private DialogueController dialogueController;

    private BranchingStats branchingStats;

    private void Start()
    {
        dialogueController = DialogueController.instance;
        branchingStats = BranchingStats.instance;

        switch (goodOrBadDialogue)
        {
            case true:
                numberOfSentances = goodDialogueHolder.Count + badDialogueHolder.Count;
                break;

            case false:
                numberOfSentances = dialogueHolder.Count;
                break;
        }
    }

    public void Update()
    {
        dialogueController.DisableAllControls();

        if(goodOrBadDialogue)
        {
            if(branchingStats.goodPoints >= pointsForGoodDialogue)
            {
                for (int i = 0; i < goodDialogueHolder.Count; i++)
                {
                    switch (i)
                    {
                        case 1:

                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < badDialogueHolder.Count; i++)
                {
                    switch (i)
                    {
                        case 1:

                            break;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < dialogueHolder.Count; i++)
            {
                switch (i)
                {
                    case 1:

                        break;
                }
            }
        }
    }

}
