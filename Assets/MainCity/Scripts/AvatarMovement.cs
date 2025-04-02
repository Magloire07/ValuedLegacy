using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of movement
    private Animator animator;
    private bool isWalking = false;

    void Start()
    {
        // Get the Animator component attached to the avatar
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the "G" key is pressed
        if (Input.GetKeyDown(KeyCode.G))
        {
            isWalking = !isWalking; // Toggle walking state
        }

        // If the character is walking, move it forward and play walking animation
        if (isWalking)
        {
            // Play walking animation
            animator.SetBool("IsWalking", true); // Ensure you have a boolean parameter "IsWalking" in your Animator
             
            // Move the avatar forward only when walking
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Stop walking animation
            animator.SetBool("IsWalking", false);
        }
    }
}
