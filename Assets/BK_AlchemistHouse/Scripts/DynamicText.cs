using UnityEngine;
using TMPro; // Ajoutez cette ligne pour utiliser TextMeshPro
public class DynamicText : MonoBehaviour
{
    public TextMeshPro textMeshPro; // Référence au TextMeshPro
    public float amplitude = 0.1f;   // Amplitude du mouvement (hauteur)
    public float frequency = 5f;   // Fréquence du mouvement (vitesse)

    private Vector3 initialPosition;

    void Start()
    {
        // Stocke la position initiale du texte
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshPro>();
        }

        if (textMeshPro != null)
        {
            initialPosition = textMeshPro.transform.position;
        }
        else
        {
            Debug.LogError("TextMeshPro n'est pas assigné ou trouvé !");
        }
    }

    void Update()
    {
        if (textMeshPro != null)
        {
            // Calcule la nouvelle position en utilisant une fonction sinusoïdale
            float newY = initialPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
            textMeshPro.transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
        }
    }
}
