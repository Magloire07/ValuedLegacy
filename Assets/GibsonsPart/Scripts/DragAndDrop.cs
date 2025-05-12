using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool isGrabbing = false; // being carried
    private Rigidbody currentlyGrabbedObject;
    private Vector3 offset;
    private int originalLayer;
    public AudioSource soundEffect;

    [Header("Smooth Movement")]
    public float smoothSpeed = 5f;

    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update()
    {
       PlayerDistance distance = GetComponent<PlayerDistance>();
        if (distance != null && distance.IsRaycastHit())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)){
                if(Input.GetMouseButtonDown(0))
                {
                    Rigidbody hitRigidbody = hit.collider.GetComponent<Rigidbody>();
                    if (hitRigidbody != null)
                    {
                        isGrabbing = true;
                        currentlyGrabbedObject = hitRigidbody;
                       // Material material = currentlyGrabbedObject.GetComponent<MeshRenderer>().material;
                        Material material = hitRigidbody.GetComponent<MeshRenderer>().material;
                        material.color = new Color(1f, 0.5f, 0f, 1f); // Change color to orange

                        originalLayer = currentlyGrabbedObject.gameObject.layer;

                        int temporaryLayer = LayerMask.NameToLayer("TemporaryLayer");
                        currentlyGrabbedObject.gameObject.layer = temporaryLayer;

                        offset = currentlyGrabbedObject.transform.position - hit.point;
                        currentlyGrabbedObject.isKinematic = true;
                        soundEffect.Play();
                    }
                    else{
                        Material material = currentlyGrabbedObject.GetComponent<MeshRenderer>().material;
                        material.color = new Color (0f, 0f, 0f, 0f); // Change color to black
                    }
                }
            }
        }
        
        if(isGrabbing && currentlyGrabbedObject != null)
        {
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width /2f, Screen.height /2f, Camera.main.transform.position.y));
            
            MoveWithCollisions(targetPosition);

            if(Input.GetMouseButtonUp(0))
            {
                currentlyGrabbedObject.isKinematic = false;
                currentlyGrabbedObject.gameObject.layer = originalLayer;
                isGrabbing = false;
                currentlyGrabbedObject = null;
            }
        }
    }

    private void MoveWithCollisions(Vector3 targetPosition)
    {
        currentlyGrabbedObject.transform.position = Vector3.Lerp(currentlyGrabbedObject.transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
   
}
        