using UnityEngine;
using System.Collections;

public class NPCPathing : MonoBehaviour 
{
	public GameObject wayPoint1, wayPoint2, wayPoint3;
	public GameObject[] wayPointArray = new GameObject[20];
	public int wayPointArraySize;
	public float[] timeTilMoveToPointArray = new float[20];
	public int timeTilMoveToPointArraySize;
	public float timeTilMoveToPoint1, timeTilMoveToPoint2, timeTilMoveToPoint3;
	public int onThisStep;
	public float walkingSpeed;
	
	public float lastStepChangeTime;
	
	public bool beenTalkedToYet;
	
	public NPCDialogue DialogueScript;
	
	public bool isDoingSpecialAction;
	public bool startedWalking; //startedwalking boolean is because it was going to the first waypoint already, it needs to chill the fuck out until certain time has passed then go to the first waypoint instead, its bad, change this please
	
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
				if (onThisStep < wayPointArraySize && /*Time.timeSinceLevelLoad*/ Time.time - lastStepChangeTime > timeTilMoveToPointArray[onThisStep])
				{
					Debug.Log ("onthis step " + onThisStep);
					lastStepChangeTime = Time.time;
					if (startedWalking)
					{
						onThisStep++;
					}
					else
					{
						startedWalking = true;
					}
				}
//				if (onThisStep == 0 && Time.timeSinceLevelLoad	> timeTilMoveToPoint1)
//				{
//	                onThisStep++;
//				}
//	            if (onThisStep == 1 && Time.timeSinceLevelLoad > timeTilMoveToPoint2 + timeTilMoveToPoint1)
//	            {
//	                onThisStep++;
//	            }
//	            if (onThisStep == 2 && Time.timeSinceLevelLoad > timeTilMoveToPoint3 + timeTilMoveToPoint2 + timeTilMoveToPoint1)
//	            {
//	                onThisStep++;
//	            }
			}
//			else//isDoingSpecialAction
//			{
//				if (gameObject.name == "NPCChild")
//				{
//					
//				}
//			}
		}
		else //talkingtoplayer
		{
			//talking();
		}
	}
	void FixedUpdate()
	{
		if (!DialogueScript.isTalkingToPlayer && wayPointArraySize > 0 && startedWalking)// && wayPoint1 && wayPoint2 && wayPoint3)
		{
			walk ();
		}
	}
	
	void walk()
	{
        Debug.Log("walk");
		Vector3 directionToWalk = Vector3.zero;
		if (onThisStep < wayPointArraySize)
		{
			Debug.Log ("walk2");
			directionToWalk = wayPointArray[onThisStep].transform.position - transform.position;
			this.gameObject.transform.position = this.gameObject.transform.position + (directionToWalk * walkingSpeed * Time.fixedDeltaTime);
		}
//		if (onThisStep == 1)
//		{
//            //Debug.Log("step 1");
//			directionToWalk = wayPoint1.transform.position - transform.position;
//			this.gameObject.transform.position = this.gameObject.transform.position + (directionToWalk * walkingSpeed * Time.fixedDeltaTime);
//		}
//		else if (onThisStep == 2)
//		{
//            //Debug.Log("step 2");
//            directionToWalk = wayPoint2.transform.position - transform.position;
//            this.gameObject.transform.position = this.gameObject.transform.position + (directionToWalk * walkingSpeed * Time.fixedDeltaTime);
//			
//		}
//		else if (onThisStep == 3)
//		{
//            //Debug.Log("step 3");
//            directionToWalk = wayPoint3.transform.position - transform.position;
//            this.gameObject.transform.position = this.gameObject.transform.position + (directionToWalk * walkingSpeed * Time.fixedDeltaTime);
//		}
	}
	
//	void talking()
//	{
//		if (gameObject.name == "NPCChild")
//		{
//			if (!beenTalkedToYet)
//			{
//				//play "hi"
//			}
//			else //is currently talking to player
//			{
//				if (PlayerPrefs.GetInt("Fork1Tier1") == 1)
//				{
//					//display dialogue
//				}
//				if (
//				//display dialogue points
//			}
//		}
//		//bring up dialogue tree from text files or some shit?	
//	}
}
