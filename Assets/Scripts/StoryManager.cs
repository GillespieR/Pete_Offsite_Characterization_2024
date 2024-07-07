using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Events;
using Cinemachine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class StoryManager : MonoBehaviour
{
    
    
    public GameObject globalDictionaryObject;

    //using this variable to hold the current position in the list
    public Chapters currentChapter;
    //Scriptable object list index variable. 
    public int currentChapterIndex = 0;

    //Initializing the list that holds the scriptable objects. 
    public List<Chapters> simChapters = new List<Chapters>();

     
    GlobalActionDictionary functionDictionary;   
    CameraController camController;


    public Dictionary<string, GameObject> gameObjectDictionary;


    public bool isPaused = false;
    public bool hasBegun = false;

    //public float chapterTransitionTime;
    //public float userReadingInputValue;
    //public float sludgeValue;
    //public List<float> animationDelays = new List<float>();
    //public float elapsedTime;

    //public bool startTimer = false;
    private void Awake()
    {        

        globalDictionaryObject = GameObject.FindWithTag("GlobalDictionaryObject");
        functionDictionary = globalDictionaryObject.GetComponent<GlobalActionDictionary>();
        gameObjectDictionary = globalDictionaryObject.GetComponent<GlobalGameObjectDictionary>().gameObjectDict;        

        PopulateDictionary();       
    }
    private void Start()
    {

        //camController = gameObjectDictionary["CameraManager"].gameObject.GetComponent<CameraController>();
        //audioManager = gameObjectDictionary["AudioManager"].gameObject.GetComponent<AudioManager>();     



        // currentChapterIndex = 0;        
        currentChapter = simChapters[currentChapterIndex];


        functionDictionary.GetComponent<GlobalActionDictionary>().SubscribeChapterMethods();
        currentChapter.chapterEvent.Invoke();
        currentChapter.chapterEvent.RemoveAllListeners();

        

        hasBegun = true;
        //audioManager.SetAudio();

        //PauseStoryCheck();
        //elapsedTime = 0f;        
    }
    private void Update()
    {

        
    }

    public void NextChapter() 
    {
        //StopAllCoroutines();
        Debug.Log("Inside StoryManager.NextChapter()");

        

        if (currentChapterIndex < simChapters.Count)
        {
                //currentChapter.chapterEvent.RemoveAllListeners();

                //go to next chapter
                currentChapterIndex++;
                //currentChapterIndex = currentChapterIndex +1;
                currentChapter = simChapters[currentChapterIndex];                
                //subscribe chapter methods
                functionDictionary.GetComponent<GlobalActionDictionary>().SubscribeChapterMethods();
                currentChapter.chapterEvent.Invoke();
                currentChapter.chapterEvent.RemoveAllListeners();
                
                //await Task.Yield();
        }


        Debug.Log("Chapter Index is " + currentChapterIndex);
        //audioManager.SetAudio();
        //Debug.Log("At end of NextChapter()");

    }

    public void PauseStoryCheck(int state) 
    {
        StartCoroutine(PauseStoryCheckCo(state));
    }

    public void IntroChapter() 
    {
        
  
    }

    IEnumerator PauseStoryCheckCo(int state) 
    {

        yield return null;
    }
    public void PopulateDictionary() 
    {
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("IntroChapter", IntroChapter);

    }
}

