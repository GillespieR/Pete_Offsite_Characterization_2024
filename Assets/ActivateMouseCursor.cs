using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMouseCursor : MonoBehaviour
{
    bool isCursorActive = false;
    KeyCode ActivateCursor = KeyCode.Q;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ActivateCursor) && !isCursorActive) 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isCursorActive = true;

        }
        else if (Input.GetKeyDown(ActivateCursor) && isCursorActive) 
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            isCursorActive = false;
            

        }
    }
}
