using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
   // public float horizontalInput;
   // public float forwardInput;


    private Animator playerAnim;
    private AudioSource playerAudio;
    public Camera mainCamera;
    public Camera thirdPersonCamera;
    public KeyCode switchKey;

    private float xRange = 32.0f;

    public bool isGrounded = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Keep the player in bounds
        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(switchKey) && !gameOver)
        {
            // Switch between cameras
            mainCamera.enabled = !mainCamera.enabled;
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
        }
        if(Input.GetKeyDown(KeyCode.X) && !gameOver)
        {
           //Exit the game
            Application.Quit();
        }
    }

}
