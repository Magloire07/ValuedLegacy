using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour
{
    public Transform player; // Assign the player in the Inspector
    public float speed = 5f;
    public float backDistance = 2f; // Distance to move back after hitting the player
    public float backSpeed = 2f; // Speed of moving backward
    public AvatarMovement _player;
    private bool shouldMove = false;

    void Update()
    {
        if (shouldMove && player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void StartMoving()
    {
        shouldMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Stop the car when it hits the player
        {
            shouldMove = false;
            Debug.Log("Car has hit the player!");
            _player.StopPlayerOnHit();

            // Move the car back a bit
            StartCoroutine(MoveBackwards());
        }
    }

    private IEnumerator MoveBackwards()
    {
        Vector3 targetPosition = transform.position - transform.forward * backDistance;

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, backSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
