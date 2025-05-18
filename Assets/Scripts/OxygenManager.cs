using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OxygenManager : MonoBehaviour
{
    public static OxygenManager instance;

    public Slider oxygenSlider;
    private float maxOxygen = 100f; // entre 0 et 100
    private float oxygen;
    public GameObject gameOverCanvas;
    private float oxygenTimer = 0f;




    void Awake()
    {
        instance = this;
        oxygen = maxOxygen;
        gameOverCanvas.SetActive(false);
        oxygenSlider.value = 1f;
    }

    public float oxygenDecayRate = 5f; 

    void Update()
    {
        if (oxygen > 0f)
        {
            oxygenTimer += Time.deltaTime;

            if (oxygenTimer >= 30f)
            {
                ReduceOxygenByPercentage(5f); // -5%
                oxygenTimer = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ReduceOxygenByPercentage(5f);
        }
    }
public void ReduceOxygenByPercentage(float percentage)
    {
        float reduction = maxOxygen * (percentage / 100f);
        ReduceOxygen(reduction);
    }

    public void ReduceOxygen(float amount)
    {
        oxygen -= amount;
        oxygen = Mathf.Clamp(oxygen, 0f, maxOxygen);
        oxygenSlider.value = oxygen / maxOxygen;

        if (oxygen <= 0f && !gameOverCanvas.activeSelf)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f; 
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public float GetOxygenLevel()
    {
        return oxygen;
    }


    
}
