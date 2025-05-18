using TMPro;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class AstronautController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public OxygenManager oxygenManager;
    public GameObject stationInteriorPrefab;
    public DialogueManageer dialogueManager;

    //controle quand il y a le dialogue
    public bool canMove = true;

    //pour ller vers la terrre
    public bool isAutoMoving = false;
    public Vector3 targetPosition;
    public float autoMoveSpeed = 3f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (isAutoMoving)
        {
            Vector3 dir = (targetPosition - transform.position).normalized;
            transform.position += dir * autoMoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isAutoMoving = false;
               
                canMove = true;
            }
        }
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = 0;

        if (Input.GetKey(KeyCode.E)) y = 1;
        else if (Input.GetKey(KeyCode.Q)) y = -1;

        Vector3 move = transform.right * x + transform.forward * z + transform.up * y;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public float oxygenDecayRate = 5f;

    void OnCollisionEnter(Collision collision)
    {
       
    }
    public GameObject dialoguePanel;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DrJemison"))
        {
            Debug.Log("DrJemison touchée , j’active le dialogue");
            var dc = FindFirstObjectByType<DialogueManageer>(); // même si inactive
            if (dc != null)
                dc.gameObject.SetActive(true);
        }
        if (other.CompareTag("Spaceship"))
        {
            stationInteriorPrefab.SetActive(true);
            Debug.Log("Station activée !");
            // gameObject.SetActive(false);
        }
        if (other.CompareTag("Obstacle"))
        {
            oxygenManager.ReduceOxygen(5f);
            MusicManager musicManager = FindFirstObjectByType<MusicManager>();
            if (musicManager != null)
            {
                musicManager.PlayAlertMusic();
            }
            Debug.Log("obsctacle touché");

        }
    }
}