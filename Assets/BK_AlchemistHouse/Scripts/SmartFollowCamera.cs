using UnityEngine;

public class SmartFollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 1f, -1f);
    public float followSmooth = 0.1f;
    public float rotationSpeed = 5f;

    [Header("Limites de rotation verticale")]
    public float minPitch = -40f;  // Vers le haut
    public float maxPitch = 80f;   // Vers le bas

    public LayerMask collisionLayers;

    private float currentYaw = 0f;
    private float currentPitch = 10f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (!target) return;

        // Rotation avec la souris
        currentYaw += Input.GetAxis("Mouse X") * rotationSpeed;
        currentPitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

        // Calcul position désirée
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Gestion collision
        if (Physics.Linecast(target.position, desiredPosition, out RaycastHit hit, collisionLayers))
        {
            desiredPosition = hit.point;
        }

        // Déplacement fluide
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSmooth);

        // Regarder vers le joueur
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
