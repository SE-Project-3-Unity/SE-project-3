using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class BowlingPins : MonoBehaviour
{
   public Transform pin;
   public float threshold =.6f;
   public int point =1;
   public Score score;
   
   void Start()
   {
   	score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
   }
   
   void CheckItFell()
   {
   	try
   	{
   		if(pin.up.y <threshold)
   		{
   			score.Add(point);
   			gameObject.GetComponent<Collider>().enabled = false;
   		}
   	}
   	catch
   	{
   		Debug.Log("Looks like the pin went into the Dead Zone!");
   	}
   }
   
   void OnTriggerEnter(Collider other)
   {
   	CheckItFell();
   }
}
