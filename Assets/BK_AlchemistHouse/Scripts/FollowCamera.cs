using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;         // Le joueur � suivre
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Position relative
    public float smoothSpeed = 0.125f; // Fluidit� du mouvement

    void LateUpdate()
    {
        // Position d�sir�e = position du joueur + d�calage
        Vector3 desiredPosition = target.position + offset;

        // Interpolation douce entre position actuelle et d�sir�e
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Appliquer le mouvement � la cam�ra
        transform.position = smoothedPosition;

        // Toujours regarder le joueur
        transform.LookAt(target);
    }
}
