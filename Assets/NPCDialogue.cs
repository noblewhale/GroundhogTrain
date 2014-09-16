using UnityEngine;
using System.Collections;

public class NPCDialogue : MonoBehaviour 
{
	public GameObject currentDialoguePoint;
	public ArrayList array;
	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			//currentDialoguePoint = array[0] as GameObject;
			foreach (Transform child in currentDialoguePoint.transform)
			{
				if (child.name == "NPCSpeech")
				{
					currentDialoguePoint = array[1] as GameObject;
				}
			}			
			displayChoices();
			Debug.Log ("0");
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			//currentDialoguePoint = array[1] as GameObject;
			foreach (Transform child in currentDialoguePoint.transform)
			{
				if (child.name == "NPCSpeech")
				{
					currentDialoguePoint = array[1] as GameObject;
				}
			}
			displayChoices();
			Debug.Log ("1");
		}
	}
	
	public void displayChoices()
	{
		//Debug.Log ("Hi!");
		array = new ArrayList();
		Debug.Log ("NPC " + currentDialoguePoint.GetComponent<DialogueDisplay>().playerSpeech);//actually NPC SPEECH
		foreach (Transform child in currentDialoguePoint.transform)
		{
            if (child.GetComponent<DialogueDisplay>().ShouldDisplay())
			{
				Debug.Log ("Playa " + child.GetComponent<DialogueDisplay>().playerSpeech);
				array.Add(child);
				//child.renderer.enabled = true;
			}
        }
	}
}
