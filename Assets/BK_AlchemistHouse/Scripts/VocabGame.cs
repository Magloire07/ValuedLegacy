using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabGame : MonoBehaviour
{
    public TextMeshProUGUI questionText; // Remplacer TextMeshPro par TextMeshProUGUI
    public Button[] answerButtons;
    private int correctAnswerIndex;

    void Start()
    {
        SetupQuestion();
    }

    void SetupQuestion()
    {
        questionText.text = "Comment dit-on 'chat' en anglais ?";
        string[] answers = { "Dog", "Cat", "Mouse", "Bird" };
        correctAnswerIndex = 1;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i; // important pour éviter problème de closure

            // Ici aussi, chercher TextMeshProUGUI et non Text
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = answers[i];

            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int index)
    {
        if (index == correctAnswerIndex)
        {
            Debug.Log("Bonne réponse !");
            SkillManager.Instance.AddSkill("Littérature", 20f, "litterature_icon");
            // TODO : afficher score, continuer, etc.
        }
        else
        {
            Debug.Log("Mauvaise réponse...");
        }
    }
}
