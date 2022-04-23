using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using System.Collections.Generic;

public class Score : MonoBehaviour
{
   public int score=0;
   public Text text;
   
   public void Add(int ammount)
   {
   	score+= ammount;
   	UpdateDisplay();
   }
   
   void Start()
   {
   	score=0;
   }
   
   void UpdateDisplay()
   {
   	text.text = "Score: "+score;
   }
}
