using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class AvatarMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Animator animator;
    private bool isWalking = false;
    private bool isStopped = false;

    public VideoPlayer videoPlayer;
    public Light directionalLight1;
    public Light directionalLight2;
    public GameObject skyDome;

    private Quaternion originalRotation; // Store initial rotation
    private bool isTurningBack = false; // Prevent moving while turning back

    public Camera mainCamera; // Assign Main Camera in Inspector
    public Transform playerHead; // Assign player's head position (empty GameObject at head)
    public Transform menuTarget; // Assign Menu Target position (where camera will move after head)
    public CameraFollow camera;
    public Transform cameraPosition; // Assign the camera position for the menu target


    public GameObject world3DObjects;
    public GameObject game2DCanvas;


    void Start()
    {
        animator = GetComponent<Animator>();
        isWalking = true; // Start walking by default
        // Store the original rotation of the player
        originalRotation = transform.rotation;

        // Ensure video and skydome are disabled at the start
        if (videoPlayer != null) videoPlayer.Stop();
        if (skyDome != null) skyDome.SetActive(false);
    }

    void Update()
    {
        if (isStopped || isTurningBack) // Prevent movement while stopped or turning
        {
            animator.SetBool("IsWalking", false);
            return;
        }
        /*
        if (Input.GetKeyDown(KeyCode.G))
        {
            isWalking = !isWalking;
            UpdateWalkingAnimation();
        }*/

        if (isWalking)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        UpdateWalkingAnimation();
    }

    private void UpdateWalkingAnimation()
    {
        animator.SetBool("IsWalking", isWalking);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StopZone"))
        {
            isStopped = true;
            isWalking = false;
            UpdateWalkingAnimation();
            animator.Play("Idle", 0, 0);

            // Start video
            if (videoPlayer != null) videoPlayer.Play();

            // Turn off directional lights
            if (directionalLight1 != null) directionalLight1.enabled = false;
            if (directionalLight2 != null) directionalLight2.enabled = false;

            // Activate skydome
            if (skyDome != null) skyDome.SetActive(true);

            // Rotate player 90� right
            StartCoroutine(RotatePlayer(Quaternion.Euler(transform.eulerAngles + new Vector3(0, 90, 0)), 0.5f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StopZone"))
        {
            // Before leaving, turn back to original direction
           Leaving();
        }
    }

    private void Leaving()
    {

        // Stop video
        if (videoPlayer != null) videoPlayer.Stop();

        // Turn on directional lights
        if (directionalLight1 != null) directionalLight1.enabled = true;
        if (directionalLight2 != null) directionalLight2.enabled = true;

        // Deactivate skydome
        if (skyDome != null) skyDome.SetActive(false);
    }

    public void ResumeWalking()
    {
        StartCoroutine(TurnBackThenWalk());
    }

    private IEnumerator TurnBackThenWalk()
    {
        isTurningBack = true;  // Prevent movement during rotation

        // Turn back to original direction before walking
        yield return StartCoroutine(RotatePlayer(originalRotation, 0.5f));

        isTurningBack = false; // Allow movement after rotation

        // Resume walking
        isWalking = true;
        isStopped = false;
        UpdateWalkingAnimation();
    }

    // Coroutine for smooth rotation
    private IEnumerator RotatePlayer(Quaternion targetRotation, float duration)
    {
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;

        while (timeElapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }

    public  void StopPlayerOnHit()
    {
        isWalking = false;
        isStopped = true;
        UpdateWalkingAnimation();
        GetComponent<Rigidbody>().isKinematic = false; // Enable physics

        StartCoroutine(FallAfterHit()); // Rotate & Fall

    }

    // Rotate player backward and apply downward force
    private IEnumerator FallAfterHit()
    {
        Quaternion fallRotation = Quaternion.Euler(90, transform.eulerAngles.y, 0); // Rotate 90� backward
        float duration = 1.0f; // Rotation speed
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;

        // Smoothly rotate the player backward
        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, fallRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = fallRotation; // Ensure exact rotation

        // Apply force to make the player fall faster
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.down * 10f; // Increase fall speed
        }

        // Move camera toward player’s head with ease-in motion
        yield return StartCoroutine(MoveCameraToHead(2f));

        // Once the camera reaches the head, move it instantly to the menu target
        TransitionTo2D();

    }

    private IEnumerator MoveCameraToHead(float duration)
    {
        Vector3 startPos = mainCamera.transform.position;
        Quaternion startRot = mainCamera.transform.rotation;

        Vector3 targetPos = playerHead.position + new Vector3(0, 0.3f, -0.5f); // Adjust position slightly
        Quaternion targetRot = Quaternion.LookRotation(playerHead.position - mainCamera.transform.position);

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            t = t * t * (3f - 2f * t); // Smoothstep for ease-in effect

            mainCamera.transform.position = Vector3.Lerp(startPos, targetPos, t);
            mainCamera.transform.rotation = Quaternion.Slerp(startRot, targetRot, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = targetPos;
        mainCamera.transform.rotation = targetRot;
    }

    // This method moves the camera instantly to the MenuTarget

    private void TransitionTo2D()
    {

        if (game2DCanvas != null)
            game2DCanvas.SetActive(true);

        // Désactiver les objets 3D et activer le Canvas 2D
        if (world3DObjects != null)
        {
            world3DObjects.SetActive(false);
            Destroy(world3DObjects, 2f);
        }

        // Débloquer et rendre visible la souris
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        // Désactivation du trigger après activation du mini-jeu
        gameObject.SetActive(false);
    }
    }
