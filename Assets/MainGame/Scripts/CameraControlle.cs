using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The avatar to follow
    public Vector3 offset = new Vector3(0, 2.5f, -4 ); // Adjust to position the camera behind
    public float smoothSpeed = 3f; // Speed of the smooth movement

    void LateUpdate()
    {
        if (target == null) return;

        // Target position behind the player
        Vector3 desiredPosition = target.position + target.forward * offset.z + Vector3.up * offset.y;

        // Smoothly move the camera to the new position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Keep the camera looking forward in the same direction as the player
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.forward), smoothSpeed * Time.deltaTime);
    }
}
