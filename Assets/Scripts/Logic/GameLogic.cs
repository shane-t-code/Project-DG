using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject finalEgg;
    [SerializeField] GameObject playerEgg;
    [SerializeField] TextMeshProUGUI coinAbilityText;
    [SerializeField] Countdown countdown;
    float addTime = 0;
    bool eggCollected;
    public bool gameWon;
    public bool gameLost;
    public SceneManager sceneManager;
    public static int coinValue;
    public static int abilityValue;
    public GameLogic Instance;

    void Start()
    {   
        playerEgg.SetActive(false);
        coinValue = 0;
        abilityValue = 0;
        eggCollected = false;
        gameWon = false;
        gameLost = false;
    }


    void Update()
    {
        if(gameLost == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GoldenEgg"))
        {
            playerEgg.SetActive(true);
            finalEgg.SetActive(false);
            eggCollected=true;
        }
        if (collision.gameObject.CompareTag("WinPlatform"))
        {
            if (eggCollected == true)
            {
                gameWon = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameLost = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScene");
        }
        if (collision.gameObject.CompareTag("EggCollectible"))
        {
            addTime = countdown.remainingTime;
            PlayerPrefs.SetFloat("RemainingTime", addTime);
            Destroy(collision.gameObject);
            coinValue += Random.Range(1, 10);
            PlayerPrefs.SetInt("CoinValue", coinValue);
            abilityValue += Random.Range(1, 10);
            PlayerPrefs.SetInt("AbilityValue", abilityValue);
            coinAbilityText.SetText("C " + coinValue.ToString() + " | A " + abilityValue.ToString()); 
        }
    }


}
