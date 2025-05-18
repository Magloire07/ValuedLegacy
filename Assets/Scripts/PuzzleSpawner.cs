using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
    public GameObject puzzlePiecePrefab;
    public int numberOfPieces = 6;
    public float spawnRadius = 30f;

    void Start()
    {
        SpawnPuzzlePieces();
    }

    void SpawnPuzzlePieces()
    {
        for (int i = 0; i < numberOfPieces; i++)
        {
            Vector3 randomDirection = Random.onUnitSphere;
            Vector3 spawnPosition = transform.position + randomDirection * spawnRadius;

            Instantiate(puzzlePiecePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
