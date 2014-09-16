using UnityEngine;
using System.Collections;

public class NPCPathing : MonoBehaviour 
{
	public GameObject wayPoint1, wayPoint2, wayPoint3;
	public float timeTilMoveToPoint1, timeTilMoveToPoint2, timeTilMoveToPoint3;
	public int onThisStep = 0;
	public bool isTalkingToPlayer;
	public float walkingSpeed;
	
	public bool beenTalkedToYet;
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (!isTalkingToPlayer)
		{
			if (Time.time - Time.timeSinceLevelLoad	> timeTilMoveToPoint1)
			{
				onThisStep = 1;
			}
		}
		else //talkingtoplayer
		{
			//talking();	
		}
	}
	void FixedUpdate()
	{
		if (!isTalkingToPlayer)
		{
			walk ();
		}
	}
	
	void walk()
	{
		Vector3 directionToWalk = Vector3.zero;
		if (onThisStep == 1)
		{
			directionToWalk = wayPoint1.transform.position - transform.position;
			this.gameObject.transform.position = this.gameObject.transform.position + (directionToWalk * walkingSpeed * Time.fixedDeltaTime);
		}
		else if (onThisStep == 2)
		{
			
		}
		else if (onThisStep == 3)
		{
			
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
