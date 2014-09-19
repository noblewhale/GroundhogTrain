using UnityEngine;
using System.Collections;

public class NPCDialogue : MonoBehaviour 
{
	public GameObject currentDialoguePoint;
	public ArrayList array;
    public GameObject[] playerSpeechArray = new GameObject[100];
	
	public bool isTalkingToPlayer;
	public float talkingToPlayerZeroTime;
	public float talkToPlayerForThisLongBeforeContinuingOnNormalPath;

    public int timesConversationInitatedWith;
	
	public string playerSpeechChoice1, playerSpeechChoice2;
	
	public NPCPathing PathingScript;
	void Start ()
	{
        array = new ArrayList();
	}
	
	void Update ()
	{
		if (isTalkingToPlayer)
		{
			if (Time.time - talkingToPlayerZeroTime > talkToPlayerForThisLongBeforeContinuingOnNormalPath)
			{
				isTalkingToPlayer = false;
			}
			for (int i = 0; i < PathingScript.wayPointArraySize; i++)
			{
				PathingScript.timeTilMoveToPointArray[i] = PathingScript.timeTilMoveToPointArray[i] + Time.deltaTime;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			talkingToPlayerZeroTime = Time.time;
            currentDialoguePoint = array[0] as GameObject;
            PlayerPrefs.SetInt(currentDialoguePoint.GetComponent<DialogueDisplay>().playerSpeech, 1);
			foreach (Transform child in currentDialoguePoint.transform)
			{
				if (child.name == "NPCSpeech")
				{
                    //Debug.Log("Holla1");
					currentDialoguePoint = child.gameObject;
				}
			}
			displayChoices(false);
			Debug.Log ("1");
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			talkingToPlayerZeroTime = Time.time;
            currentDialoguePoint = array[1] as GameObject;
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
                j++;
			}
        }
	}
	
	void OnGUI()
	{
		for (int i = 0; i < array.Count; i++)
		{
			GUI.Box(new Rect(10,10 + 10 * i * 4,500,30), i + 1 + "    " + (array[i] as GameObject).GetComponent<DialogueDisplay>().playerSpeech);
		}
	}
}
