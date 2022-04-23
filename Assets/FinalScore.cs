using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using TMPro;
public class FinalScore : MonoBehaviour
{

       public TextMeshProUGUI Table;
       public ScoreDatabase DB;

	   private string path;
       
 
    // Start is called before the first frame update
  
    public void Start()
    {
		path = Application.persistentDataPath + "/history.txt";
     	updatescore();
     }
    // Update is called once per frame
    void Update()
    {
        updatescore();
    }
    
    private void updatescore(){
    
		//////////////
		List<string> all_scores = new List<string>();

		using(StreamReader sr = File.OpenText(path)){
			string one_score = "";
			while((one_score = sr.ReadLine()) != null){
				all_scores.Add(one_score);
			}
		}

		all_scores.Reverse();



		//////////////
		

    	List<int> topScoreList = new List<int>();
      	foreach(string sc in all_scores){
			  
			  topScoreList.Add(Int32.Parse(sc));
		
			  if(topScoreList.Count >= 10){
				  break;
			  }
		  }
		
		topScoreList.Sort();
		topScoreList.Reverse();

       	string final = "";
 /*      	foreach(int sc in scoreList)
       	{
       		final += sc.ToString() + "\n";
       	}*/
       	
       	foreach(int sc in topScoreList)
       	{
			
       			final += sc.ToString() + "\n";

	   	}
       	
       	 Table.text = final;
       	 
      }
    
}
