using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] public float remainingTime;
    [SerializeField] GameLogic gameLogic;
    public int seconds;
    public int minutes;

    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            remainingTime = 0;
            gameLogic.gameLost = true;
        }
        minutes = Mathf.FloorToInt(remainingTime / 60);
        seconds = Mathf.FloorToInt(remainingTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
