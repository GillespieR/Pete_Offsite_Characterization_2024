using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapChangeLocation : MonoBehaviour
{

    public StoryManager storyManager;
    public PlayerMovement playerMovement;
    public Transform player;

    public Transform locationOne;
    public Transform locationTwo;
    public Transform locationThree;
    public Transform locationFour;

    public Transform tpLocation;

    bool button1pressed = false;
    bool button2pressed = false;
    bool button3pressed = false;
    bool button4pressed = false;
    // Start is called before the first frame update
    void Start()
    {
     
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        player = storyManager.gameObjectDictionary["Player"].transform;
        locationOne = storyManager.gameObjectDictionary["LocationOne"].GetComponent<Transform>();
        locationTwo = storyManager.gameObjectDictionary["LocationTwo"].GetComponent<Transform>();
        locationThree = storyManager.gameObjectDictionary["LocationThree"].GetComponent<Transform>();
        locationFour = storyManager.gameObjectDictionary["LocationFour"].GetComponent<Transform>();

        playerMovement = gameObject.GetComponent<PlayerMovement>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player gameobject transform is " + transform.position);
        
    }

    public void LocationOneTeleport() 
    {
        playerMovement.playerTeleporting = true;
        player.transform.position = locationOne.position;
        Debug.Log("Location One Clicked");

        

    }

    public void LocationTwoTeleport()
    {
        playerMovement.playerTeleporting = true;
        player.transform.position = locationTwo.position;
        Debug.Log("Location Two Clicked");
        
    }

    public void LocationThreeTeleport()
    {
        playerMovement.playerTeleporting = true;
        player.transform.position = locationThree.position;
        Debug.Log("Location Three Clicked");
                
    }

    public void LocationFourTeleport()
    {
        playerMovement.playerTeleporting = true;
        player.transform.position = locationFour.position;
        Debug.Log("Location Four Clicked");                
    }    
    
    /*
    public void TeleportPlayer() 
    {
        Debug.Log("Value of button1pressed is " + button1pressed);
        Debug.Log("Value of button2pressed is " + button2pressed);
        Debug.Log("Value of button3pressed is " + button3pressed);
        Debug.Log("Value of button4pressed is " + button4pressed);

        if (button1pressed && transform.position != locationOne.position)
        {
            transform.position = locationOne.position;                        
        }

        if (button2pressed && transform.position != locationTwo.position)
        {
            transform.position = locationTwo.position;           
        }

        if (button3pressed && transform.position != locationThree.position)
        {
            transform.position = locationThree.position;            
        }

        if (button4pressed && transform.position != locationFour.position)
        {
            transform.position = locationFour.position;            
        }

    }

    IEnumerator TeleportPlayerCo() 
    {
        while (true) 
        {
            if (button1pressed && transform.position != locationOne.position)
            {
                transform.position = locationOne.position;                
                yield return new WaitForSeconds(2f);
                break;                             
            }

            if (button2pressed && transform.position != locationTwo.position)
            {
                transform.position = locationTwo.position;
                yield return new WaitForSeconds(2f);
                break;
            }

            if (button3pressed && transform.position != locationThree.position)
            {
                transform.position = locationThree.position;
                yield return new WaitForSeconds(2f);
                break;
            }

            if (button4pressed && transform.position != locationFour.position)
            {
                transform.position = locationFour.position;
                yield return new WaitForSeconds(2f);
                break;
            }
            yield return null;
        }

        yield return null;
    }
    */
}
