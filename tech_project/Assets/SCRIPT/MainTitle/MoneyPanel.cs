using System;
using TMPro;
using UnityEngine;

public class MoneyPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heartText;
    [SerializeField] private TextMeshProUGUI heartTimeText;
    [SerializeField] private TextMeshProUGUI dollarText;
    [SerializeField] private TextMeshProUGUI medalText;

    void FixedUpdate()
    {
        heartText.text = PlayerPrefs.GetInt("Heart").ToString();
        dollarText.text = PlayerPrefs.GetInt("Dollar").ToString("N0");
        medalText.text = PlayerPrefs.GetInt("Medal").ToString("N0");

        if (PlayerPrefs.GetInt("Heart") < 5)
        {
            int remainingTime = PlayerPrefs.GetInt("RemainingTime");
            TimeSpan timeSpan = TimeSpan.FromSeconds(remainingTime);
            heartTimeText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }
        else
        {
            heartTimeText.text = "MAX";
        }
    }
}
