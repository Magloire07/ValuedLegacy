using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistance : MonoBehaviour
{
    public float distance = 5f; // Distance from the camera to the object
    public bool isHit = false; // Variable to check if the raycast hit an object

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, distance))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
            Debug.Log("Object hit : " + hit.collider.gameObject.name);
            // Vérifier si l'objet touché a le script PlayerDistance
            PlayerDistance playerDistance = hit.collider.gameObject.GetComponent<PlayerDistance>();
            isHit = true;
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.blue);
        }
    }

    public bool IsRaycastHit()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit, distance);
    }
   
}
