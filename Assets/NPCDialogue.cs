using UnityEngine;
using System.Collections;

public class NPCDialogue : MonoBehaviour 
{
	public GameObject currentDialoguePoint;
	//public ArrayList array;
    public GameObject[] playerSpeechArray = new GameObject[100];
	void Start () 
	{
        playerSpeechArray = new GameObject[100];
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			currentDialoguePoint = playerSpeechArray[0] as GameObject;
            PlayerPrefs.SetInt(currentDialoguePoint.GetComponent<DialogueDisplay>().playerSpeech, 1);
			foreach (Transform child in currentDialoguePoint.transform)
			{
				if (child.name == "NPCSpeech")
				{
                    Debug.Log("Holla1");
					currentDialoguePoint = child.gameObject;// as GameObject;
				}
			}
			displayChoices();
			Debug.Log ("1");
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
            currentDialoguePoint = playerSpeechArray[1] as GameObject;
			foreach (Transform child in currentDialoguePoint.transform)
			{
				if (child.name == "NPCSpeech")
				{
                    Debug.Log("holla2");
					currentDialoguePoint = playerSpeechArray[1] as GameObject;
				}
			}
			displayChoices();
			Debug.Log ("2");
		}
	}
	
	public void displayChoices()
	{
		Debug.Log ("displayChoices()");
		Debug.Log ("NPC " + currentDialoguePoint.GetComponent<DialogueDisplay>().playerSpeech);//NPC SPEECH
        int j = 0;
		foreach (Transform child in currentDialoguePoint.transform)
		{
            if (child.GetComponent<DialogueDisplay>().ShouldDisplay())
			{
				Debug.Log ("Playa " + child.GetComponent<DialogueDisplay>().playerSpeech);
                
                playerSpeechArray[j] = child.gameObject;
                j++;
			}
        }
	}
}
