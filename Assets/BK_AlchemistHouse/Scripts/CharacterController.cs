using UnityEngine;

public class PlayerArrowMovement : MonoBehaviour
{
    public float speed = 5f;
    public CharacterController controller;

    void Update()
    {
        // Lecture des touches directionnelles
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            moveX = -1f;
        if (Input.GetKey(KeyCode.RightArrow))
            moveX = 1f;
        if (Input.GetKey(KeyCode.UpArrow))
            moveZ = 1f;
        if (Input.GetKey(KeyCode.DownArrow))
            moveZ = -1f;

        // Cr�ation du vecteur de d�placement
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // D�placement du perso
        controller.Move(move * speed * Time.deltaTime);
    }
}
