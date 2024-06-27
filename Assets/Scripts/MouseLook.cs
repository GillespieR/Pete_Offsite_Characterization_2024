using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //float to control speed of the mouse
    public float mouseSensitivity = 100f;
    //reference to the player transform
    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //hide and lock cursor to the center of the screen.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Gathering Input based on mouse movement along the x and y axis's, then multiplying by mouse sensitivity.
        //Time.deltaTime = time has gone by since the last update function was called
        //multiplying using this allows us to rotate camera independent of current framerate.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //decrease x rotation by mouseY every frame. 
        xRotation -= mouseY;
        //"clamps" the rotation of the camera so you can't rotate the camera behind the player
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //apply rotation by setting game objects local rotation to a Euler angle of the xRotation variable on x, 0f on the y, and 0f on the z. 
        //Quaternion are responsible for rotation in Unity. Euler is a type of angle.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //rotating around Y axis by mouseX
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
