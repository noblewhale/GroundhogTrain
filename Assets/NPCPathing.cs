using UnityEngine;
using System.Collections;

public class NPCPathing : MonoBehaviour 
{
	public GameObject wayPoint1, wayPoint2, wayPoint3;
	public float timeTilMoveToPoint1, timeTilMoveToPoint2, timeTilMoveToPoint3;
	public int onThisStep;
	public float walkingSpeed;
	
	public bool beenTalkedToYet;
	
	public NPCDialogue DialogueScript;
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (!DialogueScript.isTalkingToPlayer)
		{
			if (onThisStep == 0 && Time.timeSinceLevelLoad	> timeTilMoveToPoint1)
			{
                onThisStep++;
			}
            if (onThisStep == 1 && Time.timeSinceLevelLoad > timeTilMoveToPoint2 + timeTilMoveToPoint1)
            {
                onThisStep++;
            }
            if (onThisStep == 2 && Time.timeSinceLevelLoad > timeTilMoveToPoint3 + timeTilMoveToPoint2 + timeTilMoveToPoint1)
            {
                onThisStep++;
            }
		}
		else //talkingtoplayer
		{
			//talking();
		}
	}
	void FixedUpdate()
	{
		if (!DialogueScript.isTalkingToPlayer && wayPoint1 && wayPoint2 && wayPoint3)
		{
			walk ();
		}
	}
	
	void walk()
	{
        //Debug.Log("walk");
		Vector3 directionToWalk = Vector3.zero;
		if (onThisStep == 1)
		{
            //Debug.Log("step 1");
			directionToWalk = wayPoint1.transform.position - transform.position;
			this.gameObject.transform.position = this.gameObject.transform.position + (directionToWalk * walkingSpeed * Time.fixedDeltaTime);
		}
		else if (onThisStep == 2)
		{
            //Debug.Log("step 2");
            directionToWalk = wayPoint2.transform.position - transform.position;
            this.gameObject.transform.position = this.gameObject.transform.position + (directionToWalk * walkingSpeed * Time.fixedDeltaTime);
			
		}
		else if (onThisStep == 3)
		{
            //Debug.Log("step 3");
            directionToWalk = wayPoint3.transform.position - transform.position;
            this.gameObject.transform.position = this.gameObject.transform.position + (directionToWalk * walkingSpeed * Time.fixedDeltaTime);
		}
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
