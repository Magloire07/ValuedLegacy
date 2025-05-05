using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }

    private List<Skill> skills = new List<Skill>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Pour qu'il persiste entre les sc�nes
    }

    // Ajouter une comp�tence
    public void AddSkill(string name, float value, string iconName)
    {
        if (skills.Exists(s => s.GetSkillName() == name))
        {
            Debug.LogWarning($"Comp�tence '{name}' d�j� ajout�e.");
            return;
        }

        Skill newSkill = new Skill(name, value, iconName);
        skills.Add(newSkill);
    }


    // Modifier la valeur d'une comp�tence
    public bool ModifySkillValue(string name, float newValue)
    {
        Skill skill = skills.Find(s => s.GetSkillName() == name);
        if (skill != null)
        {
            skill.SetValue(newValue);
            return true;
        }
        return false;
    }



    // Obtenir une comp�tence
    public Skill GetSkill(string name)
    {
        return skills.Find(s => s.GetSkillName() == name);
    }

    // Retourner toutes les comp�tences
    public List<Skill> GetAllSkills()
    {
        return skills;
    }
}
