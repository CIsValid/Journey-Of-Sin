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

    private bool affectStats;
    private bool goodOrBadDialogue;
}
