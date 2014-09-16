using UnityEngine;
using System.Collections;

public class DialogueDisplay : MonoBehaviour 
{
	public string requiresThisToBeDone;
	public string playerSpeech;

	void Start ()
	{
	
	}
	
	void Update ()
	{
	
	}
	
	public bool ShouldDisplay()
	{
		if (requiresThisToBeDone == null || PlayerPrefs.GetInt(requiresThisToBeDone) == 1 || PlayerPrefs.GetInt(requiresThisToBeDone) == 0)
		{
			Debug.Log ("true");
			return true;
		}
		else
		{
			Debug.Log ("false");
			return false;
		}
	}
}
