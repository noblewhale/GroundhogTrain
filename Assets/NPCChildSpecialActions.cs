using UnityEngine;
using System.Collections;

public class NPCChildSpecialActions : MonoBehaviour 
{
	public float specialActionZeroTime;
	public float specialActionTimeLength;	
	public NPCPathing NPCPathingScript;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (NPCPathingScript.isDoingSpecialAction && Time.time - specialActionZeroTime > specialActionTimeLength)
		{
			NPCPathingScript.isDoingSpecialAction = false;
			//Debug.Log ("endspecialaction");
		}
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "NPCTicketPuncher")
		{
			Debug.Log ("TICKET PUNCHER SPECIAL ACTION");
			NPCPathingScript.isDoingSpecialAction = true;
			specialActionZeroTime = Time.time;
		}
	}
}
