using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

// attach to UI Text component (with the full text already there)

public class TextTypeWriter: MonoBehaviour
{

	Text txt;
	string story;
	public float speed;

	void Awake()
	{
		txt = GetComponent<Text>();
		story = txt.text;
		txt.text = "";

		StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(speed);
		}
	}

}