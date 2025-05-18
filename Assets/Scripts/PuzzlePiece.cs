using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int piecesCollected = 0;
    public static int totalPieces = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            /* piecesCollected++;
             Debug.Log($"Pièce récupérée ({piecesCollected}/{totalPieces})");
             scoreText.text = "Pièces : " + piecesCollected + " / " + totalPieces;


             if (piecesCollected == totalPieces)
             {
                 PuzzleComplete();
             }

             Destroy(gameObject);
         }*/
            PuzzleManager.instance.CollectPiece(this.gameObject);
        }
    }

    void PuzzleComplete()
    {
        Debug.Log(" Tous les morceaux récupérés !");
        GameObject.FindFirstObjectByType<PuzzleManager>()?.ShowMessage();
    }
}
