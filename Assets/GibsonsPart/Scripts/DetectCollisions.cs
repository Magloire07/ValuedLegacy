using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private Vector3 objectPosition;

    private MeshRenderer Renderer;
    public Color Selectmode;
    public GameObject onTouchEffect;
    public float magenta = 0f;
    public float blue = 0f;
    public float key = 0f;

    private bool touch = false;
    
    
    // Start is called before the first frame update
    void Start(){
        Renderer = GetComponent<MeshRenderer>();
        //objectPosition = transform.position;
        //Renderer.material.color = new Color(magenta, Random.Range(0f, 1f), blue, key);
       if (touch == true){
        ColorChange();
       }
        
    }
    public void ColorChange()
    {
        Material material = Renderer.material;
        material.color = new Color(magenta, Random.Range(0f, 1f), blue, key);
        //red green blue alpha
        //material.color = new Color(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object has a PlayerController component and a PlayerDistance component
        PlayerDistance playerDistance = other.GetComponent<PlayerDistance>();
        if (other.GetComponent<PlayerController>() && playerDistance.isHit == true) {// != null && playerDistance != null
            touch = true;
            Debug.Log("Banane " + other.name);
            Selectmode = other.GetComponent<MeshRenderer>().material.color;
            // Instantiate the particle effect
            Instantiate(onTouchEffect, transform.position, transform.rotation);
        }
    }



    // Update is called once per frame
    //void Update(){ }
}
