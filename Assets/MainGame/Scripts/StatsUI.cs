using UnityEngine;
using TMPro;
using UnityEngine.UI; // Needed for UI Images

public class StatsUI : MonoBehaviour
{
    public TextMeshProUGUI skillText, statusText, wealthText, dreamText;
    public Image skillIcon, socialIcon, wealthIcon, dreamIcon;

    private int skillLevel = 0;
    private int socialStatus = 0;
    private int wealth = 0;
    private int dreamCompletion = 0;

    void Start()
    {
        UpdateStatsUI();
    }

    void UpdateStatsUI()
    {
        skillText.text = $"skills: {skillLevel}";
        statusText.text = $"Status: {socialStatus}";
        wealthText.text = $"wealth: {wealth}";
        dreamText.text = $"dream: {dreamCompletion}%";
    }

    // Example functions to increase stats
    public void IncreaseSkill()
    {
        skillLevel++;
        UpdateStatsUI();
    }

    public void IncreaseWealth()
    {
        wealth += 10;
        UpdateStatsUI();
    }
}
