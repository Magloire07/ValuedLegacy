using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;         // Le joueur
    public Vector3 offset = new Vector3(0f, 1f, -1f);
    public float rotationSpeed = 5f;
    public float minPitch = -40f;
    public float maxPitch = 60f;

    private float yaw = 0f;
    private float pitch = 10f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (!target) return;

        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Calculer la nouvelle rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Calculer la position de la caméra
        Vector3 desiredPosition = target.position + rotation * offset;

        // Positionner la caméra
        transform.position = desiredPosition;

        // Toujours regarder le joueur
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
