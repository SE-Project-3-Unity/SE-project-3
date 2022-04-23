using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audios : MonoBehaviour
{
	public AudioSource ausrc;
	
	void start ()
	{
		ausrc = GetComponent<AudioSource> ();
		
	}
	
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Pins")
		{
			ausrc.Play();
		}
	}
	
}
