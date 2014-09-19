using UnityEngine;
using System.Collections;

public class DialogueDisplay : MonoBehaviour 
{
	public string requiresThisToBeDone;
	public string playerSpeech;

    public string alternateIntroduction1;
    public string alternateIntroduction2;

    public AudioSource speechAudio;

	void Start ()
	{
	
	}
	
	void Update ()
	{
	
	}
	
	public bool ShouldDisplay()
	{
		if (requiresThisToBeDone == "NA" || PlayerPrefs.GetInt(requiresThisToBeDone) == 1)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
