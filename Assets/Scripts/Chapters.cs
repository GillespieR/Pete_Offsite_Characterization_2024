using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Chapter", menuName = "Chapters", order = 51)]
public class Chapters : ScriptableObject
{

    public List<string> chapterMethodNames = new List<string>();   
    public UnityEvent chapterEvent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
