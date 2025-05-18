using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public float speed = 5f;

    [Range(0f, 100f)]
    public float oxygenDamagePercent = 5f; // % d'oxygène perdu

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OxygenManager.instance != null)
            {
                OxygenManager.instance.ReduceOxygen(oxygenDamagePercent); // 5f = 5%
            }

            Destroy(gameObject);
        }
        
    }
    void OnDestroy()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.StopAlertMusic();
        }
    }
}
