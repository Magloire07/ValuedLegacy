using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;         // Le joueur à suivre
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Position relative
    public float smoothSpeed = 0.125f; // Fluidité du mouvement

    void LateUpdate()
    {
        // Position désirée = position du joueur + décalage
        Vector3 desiredPosition = target.position + offset;

        // Interpolation douce entre position actuelle et désirée
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Appliquer le mouvement à la caméra
        transform.position = smoothedPosition;

        // Toujours regarder le joueur
        transform.LookAt(target);
    }
}
