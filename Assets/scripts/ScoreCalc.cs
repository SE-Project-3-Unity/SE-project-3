using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Diagnostics;
using System.Linq;  
using System.Text;  
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

using Debug = UnityEngine.Debug;
public class ScoreCalc : MonoBehaviour
{
  
   public GameObject ball;
   public Rigidbody rb;
   public Text final_score;
   public ScoreDatabase sdb;
   public TextMeshProUGUI frames;
   private string path;
                
   GameObject[] pins;
   private int score=0,cumScore=0,curFrame=1,curChance=0,curRoll=0;
   Vector3 ballPos;
   Vector3[] pinsPos;
   Quaternion[] pinsRot;

    private int[] rolls = new int[21];
    private int[] frame = new int[10];

    private bool isSpare(int frameIndex) {
        return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
    }

    private bool isStrike(int frameIndex)
    {
        return rolls[frameIndex] == 10;
    }

    // public void Roll(int pins)
    // {
    //     rolls[currentRoll++] = pins;
    // }
    
    // public void Roll(int[] pins)
    // {
    //     for(int i = 0; i < pins.Length; i++)
    //     {
    //         rolls[currentRoll++] = pins[i];
    //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/history.txt";

        rb = GetComponent<Rigidbody>();
        pins = GameObject.FindGameObjectsWithTag("PIN");
        ballPos = ball.transform.position;
        pinsPos = new Vector3[pins.Length];
        pinsRot = new Quaternion[pins.Length];
        for(int i=0;i<pins.Length;i++){
            pinsPos[i] = pins[i].transform.position;
            pinsRot[i] = pins[i].transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  rb.AddForce(Vector3.forward*10);
    }
    public void loadEndGame()
    {
        SceneManager.LoadScene("EndGame");
    }
    public void OnTriggerEnter(Collider obj){
        if(obj.gameObject.name=="endpro"){
            score=0;
            updateScore();
            debugScore();
            curRoll++;
            curChance+=1;
            
            if(curChance==2 && curFrame!=10){
                curChance=0;
                curFrame++;
                // Debug.Log("Frame: "+curFrame);
                resetPins();    
            }
            if(curChance>=2 && curFrame==10)
            {
                curChance +=1;
                resetPins();
            }
            if(curChance==10)
            {
                curChance=0;
                curFrame++;
                // Debug.Log("Frame: "+curFrame);
                resetPins(); 
            }
            resetBall();

            if(curFrame==10){
                // Debug.Log("Game Finished");
                // Debug.Log(sdb.cur);
                // sdb.scores[sdb.cur] = cumScore;
                // sdb.cur = (sdb.cur+1)%10;
                // sdb.prev = cumScore;

                
                
                using (StreamWriter sw = File.AppendText(path)){
                    sw.WriteLine(cumScore.ToString());
                }
                loadEndGame();
            }

        } 
    }
    
    public void debugScore(){
        string log = "";
        for(int i=0;i<10;i++){
            log += rolls[2*i]+" | "+rolls[2*i+1]+" || ";
            
        }
        log = log + rolls[20];
        frames.text = log;
    }
    public void update_score(int s)
    {
        final_score.text = s.ToString();
    }
    public void updateScore(){
        Stopwatch stopwatch = Stopwatch.StartNew();
        while (true)
        {
            //some other processing to do possible
            if (stopwatch.ElapsedMilliseconds >= 10000)
            {
                break;
            }
        }
        for(int i=0;i<pins.Length; i++){
            if(pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf){
                score++;
                pins[i].SetActive(false);
            }
        }
        if(curRoll<21)
            rolls[curRoll] = score;
        cumScore = calcScore();
        update_score(cumScore);
        debugScore();
        Debug.Log(cumScore);
        
    }
    

    public int calcScore()
    {
        int score = 0;
        int frameIndex = 0;
        for (int frame = 0; frame < 10; frame++)
        {
            if (isSpare(frameIndex))
            {
                score += 10 + rolls[frameIndex + 2];
                frameIndex += 2;
            }
            else if (isStrike(frameIndex))
            {
                score += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
                frameIndex++;
            }
            else
            {
                score += rolls[frameIndex] + rolls[frameIndex + 1];
                frameIndex += 2;
            }
            
        }
        
        return score;
    }

    public void resetPins(){
        for(int i=0;i<pins.Length;i++){
            pins[i].SetActive(true);
            pins[i].transform.position = pinsPos[i];
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.rotation = pinsRot[i];
        }
    }

    public void resetBall(){
        ball.transform.position = ballPos;  
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            
    }

}
