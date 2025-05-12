using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouv : MonoBehaviour
{
    // Walk to the front
    public float speed = 5.0f; // Set player's movement speed.
    public float rotationSpeed = 0.2f; // Set player's rotation speed.
    private Rigidbody rb; // Reference to player's Rigidbody.
    public Animator playerAnim; // Reference to player's Animator.
    private PlayerController playerControllerScript;
    public bool isMoving = false; // Flag to check if player is moving.
    public GameObject stepSound; // Reference to the step sound effect.
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = 
        GameObject.Find("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
        playerAnim = GetComponent<Animator>(); // Access player's Animator.
        playerAnim.SetBool("isMoving", false); // Set initial animation state.
    }

    // Update is called once per frame

    // Handle physics-based movement and rotation.
    private void Update()
    {// Check if the up arrow key is pressed.
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) //every frame the key is pressed
        {        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        playerAnim.Play("Walk");
        playerAnim.SetBool("isMoving", true); // Set animation state to moving.
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.Play("Idle");
            playerAnim.SetBool("isMoving", false); // Set animation state to not moving.
        }
        
        // Rotate player based on horizontal input.
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
            //playerAnim.Play("Walk_Static");
            playerAnim.SetBool("isMoving", true); 
        }
    }
}

