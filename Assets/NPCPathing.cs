using UnityEngine;
using System.Collections;

public class NPCPathing : MonoBehaviour 
{
	public GameObject[] wayPointArray = new GameObject[20];//its a waypoint, waypoint 0 must always be where the NPC starts at since I'm too drunk to figure out how to make it not auto walk towards first point without making everything else all sad
	public int wayPointArraySize;
	public float[] timeTilMoveToPointArray = new float[20];//how long the object will walk toward and stay at the corresponding waypoint before moving to the next one
	public int timeTilMoveToPointArraySize;
	public int onThisStep;
	public float walkingSpeed;
	
	public float lastStepChangeTime;
	
	public bool beenTalkedToYet;
	
	public NPCDialogue DialogueScript;
	
	public bool isDoingSpecialAction;
	
	void Start ()
	{
		for (int i = 0; i < wayPointArray.Length; i++)
		{
			if (wayPointArray[i] == null)
			{
				Debug.Log ("break " + i);
				wayPointArraySize = i;
				timeTilMoveToPointArraySize = i;
				break;
			}
		}
	}
	
	void Update ()
	{
		if (!DialogueScript.isTalkingToPlayer)
		{
			if (!isDoingSpecialAction)
			{
				if (onThisStep < wayPointArraySize && Time.time - lastStepChangeTime > timeTilMoveToPointArray[onThisStep])
				{
					Debug.Log ("onthis step " + onThisStep);
					lastStepChangeTime = Time.time;
                    onThisStep++;
				}
			}
		}
	}
	void FixedUpdate()
	{
		if (!DialogueScript.isTalkingToPlayer && wayPointArraySize > 0)
		{
			walk();
		}
	}
	
	void walk()
	{
		Vector3 directionToWalk = Vector3.zero;
		if (onThisStep < wayPointArraySize)
		{
			//Debug.Log ("walk2");
			directionToWalk = wayPointArray[onThisStep].transform.position - transform.position;
			this.gameObject.transform.position = this.gameObject.transform.position + (directionToWalk * walkingSpeed * Time.fixedDeltaTime);
		}
	}
}
