﻿using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour 
{
	public GUIText timer;
	public TextMesh timerMesh;
	public float bombExplodesAfterThisManySeconds;
	public GameObject speakingToWhoObject;

    public bool shouldResetPlayerPrefs;
	
	void Start ()
	{
        if (shouldResetPlayerPrefs)
        {
            PlayerPrefs.DeleteAll();
        }
	}
	
	void Update () 
	{
		if (bombExplodesAfterThisManySeconds - Time.timeSinceLevelLoad > 0)
		{
			timer.text = (bombExplodesAfterThisManySeconds - Time.timeSinceLevelLoad).ToString();
		}
		else
		{
			timer.text = "EXPLOSION, everyone dead.";
			if (bombExplodesAfterThisManySeconds - Time.timeSinceLevelLoad < -5)
			{
				Application.LoadLevel("scene");
			}
		}
		
		if (bombExplodesAfterThisManySeconds - Time.timeSinceLevelLoad > 0)
		{
			timerMesh.text = (bombExplodesAfterThisManySeconds - Time.timeSinceLevelLoad).ToString();
		}
		else
		{
			timerMesh.text = "EXPLOSION, everyone dead.";
			if (bombExplodesAfterThisManySeconds - Time.timeSinceLevelLoad < -5)
			{
				Application.LoadLevel("scene");
			}
		}


		
		if (Input.GetMouseButtonDown(0))
		{
			Collider[] hitColliders = Physics.OverlapSphere(speakingToWhoObject.transform.position, 2f);
        	int i = 0;
			Collider closestCollider = null;//gameObject to talk to
			float latestNPCColliderDistance = 50f;
        	while (i < hitColliders.Length)
			{
				if (hitColliders[i].tag == "NPC")
				{
					float distance = Vector3.Distance(hitColliders[i].transform.position, speakingToWhoObject.transform.position);
					if (distance < latestNPCColliderDistance)
					{
						latestNPCColliderDistance = distance;
						closestCollider = hitColliders[i];
					}
				}
	            i++;
        	}
			if (closestCollider != null)//talk to this NPC
			{
				NPCDialogue tempNPCDialogue = closestCollider.GetComponent<NPCDialogue>();
                Debug.Log("Initiate Conversation");
				tempNPCDialogue.displayChoices(true);
				tempNPCDialogue.isTalkingToPlayer = true;
				tempNPCDialogue.talkingToPlayerZeroTime = Time.time;
				closestCollider.renderer.material.color = Color.green;
			}
		}
	}
	
}
