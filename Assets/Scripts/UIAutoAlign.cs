using UnityEngine;
using TMPro;

public class UIAutoAlign : MonoBehaviour
{
    public RectTransform scoreText;
    public RectTransform oxygenText;        // TMP Text
    public RectTransform oxygenSliderGroup; // Whole OxygenManager (includes the slider)

    public Vector2 topLeftPadding = new Vector2(20f, -20f);  // x = right offset, y = down offset
    public float verticalSpacing = 10f;
    public float horizontalSpacing = 15f;

    void Start()
    {
        AlignUI();
    }

    void AlignUI()
    {
        if (scoreText == null || oxygenText == null || oxygenSliderGroup == null)
        {
            Debug.LogWarning("UIAutoAlign: Please assign all RectTransforms.");
            return;
        }

        // ---- ScoreText en haut à gauche ----
        scoreText.anchorMin = new Vector2(0, 1);
        scoreText.anchorMax = new Vector2(0, 1);
        scoreText.pivot = new Vector2(0, 1);
        scoreText.anchoredPosition = topLeftPadding;

        // ---- OxygenText juste en dessous ----
        oxygenText.anchorMin = new Vector2(0, 1);
        oxygenText.anchorMax = new Vector2(0, 1);
        oxygenText.pivot = new Vector2(0, 1);
        float oxygenTextY = topLeftPadding.y - scoreText.rect.height - verticalSpacing;
        oxygenText.anchoredPosition = new Vector2(topLeftPadding.x, oxygenTextY);

        // ---- OxygenManager (slider) à droite de OxygenText ----
        oxygenSliderGroup.anchorMin = new Vector2(0, 1);
        oxygenSliderGroup.anchorMax = new Vector2(0, 1);
        oxygenSliderGroup.pivot = new Vector2(0, 1);

        float sliderX = oxygenText.anchoredPosition.x + oxygenText.rect.width + horizontalSpacing;
        oxygenSliderGroup.anchoredPosition = new Vector2(sliderX, oxygenTextY);
    }
}
