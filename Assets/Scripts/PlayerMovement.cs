using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference to character controller (motor that drives our player)
    public CharacterController controller;

    //speed at which character will move
    public float speed = 10f;
    public float walkSpeed = 10f;
    public float sprintSpeed = 15f;

    public float acceleration = 10f;
    //default gravity 
    public float gravity = -9.81f;
    //height of player jump
    public float jumpHeight = 3f;

    public bool isSprinting = false;
    public float speedBoost;

    public bool isCrouching = false;
    public float crouchingMultiplier;
    public float crouchingHeight = 1.25f;
    public float standingHeight = 1.53f;
    public float freeLookSensitivity = 3f;
    public float xRotation = 0f;

    public bool isFreelooking = false;
    //transform of the groundCheck game object
    public Transform groundCheck;
    //radius of the sphere using to check 
    public float groundDistance = 0.4f;
    //this will check what objects the ground check spehere will check for
    public LayerMask groundMask;
   

    //Downward speed of fall. Having this variable will properly allow us to simulate gravity, allowing us to store our 
    //fall speed multiplied by gravity each frame and apply it to our player. 
    Vector3 velocity;
    public bool isGrounded ;
    //public bool playerInteract = false;
    public bool playerTeleporting = false;

    Vector3 move;
    Vector3 direction;

    KeyCode sprintKey = KeyCode.LeftShift;
    KeyCode freeLook = KeyCode.Tab;

    private void Start()
    {
        xRotation = transform.GetComponentInChildren<MouseLook>().xRotation;
    }

    // Update is called once per frame
    void Update()
    {
        xRotation = transform.GetComponentInChildren<MouseLook>().xRotation;

        if (!playerTeleporting) 
        {
            //speed with which the player will fall on the Y axis. Multiply by Time.deltaTime to be independent of frame rate
            velocity.y += gravity * Time.deltaTime;

            //applying this to character movement in character controller. Multiply by Time.deltaTime because this is how 
            //physics of a free-fall works. 
            controller.Move(velocity * Time.deltaTime);           

            //check to see if free look button is pressed and flips isFreeLooking = true
            isFreeLookActive();

            if (!isFreelooking)
            {
                GroundCheck();
            }
            else if (isFreelooking)
            {
                isGrounded = false;
            }

            if (!isFreelooking)
            {
                MovePlayer();
            }
            else if (isFreelooking)
            {
                FreeMovePlayer();
            }

            Jump();

            ControlSpeed();
        }

        //If player is teleporting disable movement inputs
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(freeLook)|| Input.GetButtonDown("Jump"))
        {
            playerTeleporting = false;
        }
        





        /*if (Input.GetKeyDown(KeyCode.E))
        {
            playerInteract = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            playerInteract = false;
        }*/
    }
    void MovePlayer() 
    {
        //x axis and z axis input 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //transform.right = takes the move player is facing and goes to the right
        //transform.forward = takes the move player is facing and goes forward
        //creats move we want to move in based on x and z movement and the way the player is facing 
        move = transform.right * x + transform.forward * z;               

        //movement used in built in move function in character controller. Using our move vector we just created, and multiplies
        //by speed and Time.deltaTime (time since last update() was called) to make it frame-rate indepenent. 
        controller.Move(move * speed * Time.deltaTime);

    }

    void FreeMovePlayer() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");        

        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;

        //xRotation -= newRotationY;

        transform.localEulerAngles =new Vector3(newRotationY, newRotationX, 0f);
        
        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

    }

    void GroundCheck() 
    {
        //this will create a sphere at groundcheck gameobjects position, using the raidus specified in groundDistance variable, and will 
        //check any game objects specified in groundMask. If it finds something, isGrounded = true.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            //-2f instead of 0 because it forces the player on the ground in case the isGrounded registers before the player
            //is completely on the ground.
            velocity.y = -2f;

        }
                
    }

    void Jump() 
    {

        //Jump is automatically mapped to the "space" key
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //Physics equation to calculate the amount of velocity needed to jump a certain height
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);


        }
        
        //If freelook is toggled on, space will allow the player to float upward. It must be held otherwise velocity is 0
        if(Input.GetButton("Jump") && isFreelooking)
        {           
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }
        else if (!Input.GetButton("Jump") && isFreelooking) 
        {            
            velocity.y = 0;
        }
    }
    void ControlSpeed() 
    {
        if(Input.GetKey(sprintKey) && isGrounded)
        {
            speed = Mathf.Lerp(speed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else 
        {
            speed = Mathf.Lerp(speed, walkSpeed, acceleration * Time.deltaTime);
        }
    }

    void isFreeLookActive() 
    {
        
        if (Input.GetKeyDown(freeLook) && !isFreelooking) 
        {
            isFreelooking = true;
        }
        else if (Input.GetKeyDown(freeLook) && isFreelooking)
        {
            isFreelooking = false;
            GetComponentInChildren<Transform>().position = new Vector3(0, 0.699000061f, 0);
            GetComponentInChildren<Transform>().localEulerAngles = new Vector3(0, 0, 0);
        }

    }

}
