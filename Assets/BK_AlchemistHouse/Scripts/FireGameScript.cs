using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class FireGameScript : MonoBehaviour
{
    [System.Serializable]
    public class Element
    {
        public string name;
        public bool isCombustible;

        public Element(string name, bool isCombustible)
        {
            this.name = name;
            this.isCombustible = isCombustible;
        }
    }

    public TextMeshProUGUI elementText;
    public TextMeshProUGUI loseMessage;
    public RectTransform fireObject;
    public Button yesButton;
    public Button noButton;

    public float scaleStep = 0.2f;
    public float minScale = 0.3f;
    public float maxScale = 2.0f;

    private List<Element> elementsList = new List<Element>();
    private int currentIndex = 0;

    private float skillcpt = 0f;


    private void Start()
    {
        // Liste de 15 éléments prédéfinis
        elementsList = new List<Element>
        {
            new Element("Wood", true),
            new Element("Paper", true),
            new Element("Glass", false),
            new Element("Plastic", true),
            new Element("Metal", false),
            new Element("Oil", true),
            new Element("Sand", false),
            new Element("Gasoline", true),
            new Element("Stone", false),
            new Element("Leaves", true),
            new Element("Water", false),
            new Element("Coal", true),
            new Element("Iron", false),
            new Element("Alcohol", true),
            new Element("Brick", false)
        };

        yesButton.onClick.AddListener(() => HandleAnswer(true));
        noButton.onClick.AddListener(() => HandleAnswer(false));
        ShowNextElement();
    }

    private void HandleAnswer(bool playerSaysCombustible)
    {
        Element current = elementsList[currentIndex];

        if (playerSaysCombustible)
        {
            if (current.isCombustible)
            { 
             ChangeFireSize(scaleStep);
             this.skillcpt++;
            }
        else
            ChangeFireSize(-scaleStep);
        }
        else
        {
            if (current.isCombustible)
                PrintLoose();

        }

        currentIndex++;

        if (currentIndex < elementsList.Count)
            ShowNextElement();
        else
            EndGame();
    }

    private void ShowNextElement()
    {
        elementText.text = elementsList[currentIndex].name;
    }

    private void ChangeFireSize(float delta)
    {
        Vector3 newScale = fireObject.localScale + new Vector3(delta, delta, 0f);
        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        fireObject.localScale = newScale;
    }

    private void EndGame()
    {
        elementText.text = "Fini !";
        yesButton.interactable = false;
        noButton.interactable = false;
        SkillManager.Instance.AddSkill("Physique", skillcpt, "physique_icon");

    }
    private void PrintLoose()
    {
        yesButton.interactable = false;
        noButton.interactable = false;
        loseMessage.gameObject.SetActive(true);
        StartCoroutine(AnimateLoseMessage());
        yesButton.interactable = true;
        noButton.interactable = true;
    }
    private IEnumerator AnimateLoseMessage()
    {
        loseMessage.text = "Mauvaise réponse !";
        float duration = 1.5f;
        float timer = 0f;
        Vector3 originalScale = loseMessage.transform.localScale;

        while (timer < duration)
        {
            float scale = 1f + Mathf.Sin(timer * 10f) * 0.2f;
            loseMessage.transform.localScale = originalScale * scale;
            timer += Time.deltaTime;
            yield return null;
        }

        loseMessage.transform.localScale = originalScale;
        loseMessage.text = ""; // Efface le message, ou vous pouvez le laisser affiché
    }


}
