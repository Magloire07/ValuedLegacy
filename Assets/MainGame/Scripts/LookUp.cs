using UnityEngine;
using System.Collections;

public class LookUp : MonoBehaviour
{

    public Transform cameraTransform;  // Assign Main Camera in Inspector
    public Transform targetView;       // Position where the camera should move
    public Transform videoScreen;      // The screen where the video is displayed
    public float transitionTime = 2f;  // Time to move to target position
    public float waitTime = 11.8f;       // Time to wait before going back

    private Vector3 previousPosition;
    private Quaternion previousRotation;

    private bool isMoving = false; // Prevent multiple triggers

    private AvatarMovement avatarMovement;

    private void Start()
    {
        previousPosition = cameraTransform.position;
        previousRotation = cameraTransform.rotation;

        // Get reference to the AvatarMovement script
        avatarMovement = FindObjectOfType<AvatarMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            StartCoroutine(MoveCamera());
        }
    }

    private IEnumerator MoveCamera()
    {
        isMoving = true;

        // Store the camera's position and rotation before moving
        previousPosition = cameraTransform.position;
        previousRotation = cameraTransform.rotation;

        // Disable CameraFollow so it doesn’t override movement
        CameraFollow cameraFollow = cameraTransform.GetComponent<CameraFollow>();
        if (cameraFollow != null)
            cameraFollow.enabled = false;

        // Move smoothly to target position **while rotating toward the screen**
        yield return StartCoroutine(SmoothMove(cameraTransform, previousPosition, targetView.position, previousRotation, Quaternion.LookRotation(videoScreen.position - targetView.position), transitionTime));

        // Wait for 30 seconds
        Debug.Log("Waiting for 30 seconds...");
        yield return new WaitForSeconds(waitTime);

        // Move back to previous position smoothly
        yield return StartCoroutine(SmoothMove(cameraTransform, cameraTransform.position, previousPosition, cameraTransform.rotation, previousRotation, transitionTime));

        // Re-enable CameraFollow
        if (cameraFollow != null)
            cameraFollow.enabled = true;
        // Re-enable player movement after camera returns

        if (avatarMovement != null)
        { 
            avatarMovement.ResumeWalking();  // Resume walking
        }


        isMoving = false;
    }

    private IEnumerator SmoothMove(Transform cam, Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            cam.position = Vector3.Lerp(startPos, endPos, t);
            cam.rotation = Quaternion.Slerp(startRot, endRot, t);
            yield return null;
        }
        cam.position = endPos;
        cam.rotation = endRot;
    }
}
