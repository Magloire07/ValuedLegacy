using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrophyAssembly : MonoBehaviour
{
    private GameObject objectToInitiate;
    public GameObject TrophyOriginal;
    public GameObject TrophyBase;
    public GameObject TrophyBottom;
    public GameObject TrophyCup;
    public Sprite trophee;
    
    // Effets visuels
    public GameObject onBuiltEffect;
    public GameObject confettiEffect;
    
    //Effet sonore
    public AudioSource soundEffect;
    
    public bool TrophyBottomIsInZone = false;
    public bool TrophyBaseIsInZone = false;
    public bool TrophyCupIsInZone = false;
    public bool TrophyOriginalIsInZone = false;
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Base") && !TrophyBaseIsInZone)
        {   
            Destroy(other.gameObject);
            // Instantiate the particle effect
            objectToInitiate = Instantiate(onBuiltEffect, transform.position, transform.rotation);
            // Instantiate the part of the trophy //-2.34f, 0.14f, -15.11f
            objectToInitiate = Instantiate(TrophyBase, new Vector3(1.848f, 0.933f, -16.629f), Quaternion.identity);
            objectToInitiate.transform.localScale = new Vector3(0.29f, 0.29f, 0.29f);
            TrophyBaseIsInZone = true;
            soundEffect.Play();

        }

        if (other.CompareTag("Bottom") && !TrophyBottomIsInZone)
        {
            Destroy(other.gameObject);
            // Instantiate the particle effect
            objectToInitiate = Instantiate(onBuiltEffect, transform.position, transform.rotation);
            // Instantiate the part of the trophy
            objectToInitiate = Instantiate(TrophyBottom, new Vector3(1.848f, 0.964f, -16.613f), Quaternion.identity);//1.014f
            objectToInitiate.transform.localScale = new Vector3(0.29f, 0.29f, 0.29f);
            TrophyBottomIsInZone = true;
            soundEffect.Play();
        }

        if(other.CompareTag("Cup") && !TrophyCupIsInZone){
            Destroy(other.gameObject);
            // Instantiate the particle effect
            objectToInitiate = Instantiate(onBuiltEffect, transform.position, transform.rotation);
            // Instantiate the part of the trophy
            objectToInitiate = Instantiate(TrophyCup, new Vector3(2.057f, 1.26f, -15.837f), Quaternion.identity);//2.034f
            objectToInitiate.transform.localScale = new Vector3(0.29f, 0.29f, 0.29f);
            TrophyCupIsInZone = true;
            soundEffect.Play();
            //objectToInitiate = Instantiate(Trophee, new Vector3(2.057f, 1.26f, -15.837f), Quaternion.identity);
            SkillManager.Instance.AddSkill("Coordination", 1, "Trophee");
        }
    }

    void Update(){
        
        if(TrophyCupIsInZone && TrophyBaseIsInZone && TrophyBottomIsInZone && !TrophyOriginalIsInZone){
            // Instantiate the particle effect
            objectToInitiate = Instantiate(confettiEffect, new Vector3(1.848f, 0.933f, -16.629f), Quaternion.identity);
            objectToInitiate.transform.rotation = Quaternion.Euler(-73.608f, 0f, 0f);
            TrophyOriginalIsInZone = true;
        }
    }

}
