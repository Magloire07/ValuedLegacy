using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    public CarMovement car; // Assign the car in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the tag "Player"
        {
            car.StartMoving();
        }
    }
}
