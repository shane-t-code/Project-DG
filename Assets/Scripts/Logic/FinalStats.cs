using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalStats : MonoBehaviour
{
    GameLogic gameLogic;
    [SerializeField] TextMeshProUGUI statsText;
    int finalCoinValue;
    int finalAbilityValue;
    int addTimeValue;

    void Start()
    {
        addTimeValue = (int)PlayerPrefs.GetFloat("RemainingTime");
        finalCoinValue = PlayerPrefs.GetInt("CoinValue") + addTimeValue;
        finalAbilityValue = PlayerPrefs.GetInt("AbilityValue") + addTimeValue;
        statsText.SetText("Time Bonus: " + addTimeValue.ToString() + " | C " + finalCoinValue.ToString() + " | A " + finalAbilityValue.ToString());
    }

    void Update()
    {

    }
}
