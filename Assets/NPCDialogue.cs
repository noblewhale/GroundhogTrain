using UnityEngine;
using System.Collections;

public class NPCDialogue : MonoBehaviour 
{
	public GameObject currentDialoguePoint;
	public ArrayList array;
    public GameObject[] playerSpeechArray = new GameObject[100];

    public int timesConversationInitatedWith;
	void Start ()
	{
        array = new ArrayList();
        //playerSpeechArray = new GameObject[100];
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
            currentDialoguePoint = array[0] as GameObject;
			//currentDialoguePoint = playerSpeechArray[0] as GameObject;
            PlayerPrefs.SetInt(currentDialoguePoint.GetComponent<DialogueDisplay>().playerSpeech, 1);
			foreach (Transform child in currentDialoguePoint.transform)
			{
				if (child.name == "NPCSpeech")
				{
                    //Debug.Log("Holla1");
					currentDialoguePoint = child.gameObject;// as GameObject;
				}
			}
			displayChoices(false);
			Debug.Log ("1");
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
            currentDialoguePoint = array[1] as GameObject;
            //currentDialoguePoint = playerSpeechArray[1] as GameObject;
			foreach (Transform child in currentDialoguePoint.transform)
			{
				if (child.name == "NPCSpeech")
				{
                    //Debug.Log("holla2");
                    currentDialoguePoint = child.gameObject;
				}
			}
			displayChoices(false);
			Debug.Log ("2");
		}
	}
	
	public void displayChoices(bool isClickingToInitateConversation)
	{
		Debug.Log ("displayChoices()");
        array.Clear();//needed?
        if (isClickingToInitateConversation)
        {
            if (timesConversationInitatedWith == 0)
            {
                Debug.Log("NPC " + currentDialoguePoint.GetComponent<DialogueDisplay>().playerSpeech);
                if (currentDialoguePoint.GetComponent<DialogueDisplay>().speechAudio != null)
                {
                    Debug.Log("play");
                    currentDialoguePoint.GetComponent<DialogueDisplay>().speechAudio.Play();
                }
                timesConversationInitatedWith++;
            }
            else if (timesConversationInitatedWith == 1)
            {
                Debug.Log("NPC " + currentDialoguePoint.GetComponent<DialogueDisplay>().alternateIntroduction1);
                timesConversationInitatedWith++;
            }
            else if (timesConversationInitatedWith == 2)
            {
                Debug.Log("NPC " + currentDialoguePoint.GetComponent<DialogueDisplay>().alternateIntroduction2);
                timesConversationInitatedWith++;
            }
        }
        else
        {
            Debug.Log("NPC " + currentDialoguePoint.GetComponent<DialogueDisplay>().playerSpeech);
            if (currentDialoguePoint.GetComponent<DialogueDisplay>().speechAudio != null)
            {
                Debug.Log("play");
                currentDialoguePoint.GetComponent<DialogueDisplay>().speechAudio.Play();
            }
        }

        int j = 0;

		foreach (Transform child in currentDialoguePoint.transform)
		{
            if (child.GetComponent<DialogueDisplay>().ShouldDisplay())
			{
				Debug.Log ("Playa " + child.GetComponent<DialogueDisplay>().playerSpeech);
                array.Add(child.gameObject);
                //playerSpeechArray[j] = child.gameObject;
                j++;
			}
        }
	}
}
