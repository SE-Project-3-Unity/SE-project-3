using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class Report : MonoBehaviour
{
    // Start is called before the first frame update
      public Text fscore;
      public ScoreDatabase sdb; 
      private string path;
    // Start is called before the first frame update
  
    public void Start()
    {
      path = Application.persistentDataPath + "/history.txt";
      string s ="";
      using(StreamReader sr = File.OpenText(path)){
			string one_score = "";
			while((one_score = sr.ReadLine()) != null){
				s = one_score;
			}
		}
	    // int s = sdb.prev;
      fscore.text = s;
      // .ToString();
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
