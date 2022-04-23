using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider obj)
    {
         if(obj.gameObject.name=="Sphere")
         {
             AudioSource audio = GetComponent<AudioSource>();
             audio.Play();
         }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
