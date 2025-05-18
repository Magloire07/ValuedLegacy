using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public GameObject meteoritePrefab;
    public float spawnInterval = 2f;
    public float spawnDistance = 30f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnMeteorite), 1f, spawnInterval);
    }

    void SpawnMeteorite()
    {
        // Choisir une direction aléatoire autour du joueur
        Vector3 randomDirection = Random.onUnitSphere; // point sur une sphère
        Vector3 spawnPosition = transform.position + randomDirection * spawnDistance;

        // Regarder vers le centre
        Quaternion rotation = Quaternion.LookRotation((transform.position - spawnPosition).normalized);

        Instantiate(meteoritePrefab, spawnPosition, rotation);
        meteoritePrefab.tag = "Obstacle";
    }
}
