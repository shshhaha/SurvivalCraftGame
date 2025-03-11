using System;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    private void Start()
    {
        
    }
    //TODO : 300초마다 하트가 1개씩 증가하도록 구현, 하트가 5개 이상일 경우 5개로 고정하고 시간또한 300초로 고정
    

    public void AddHeart()
    {
        int heart = PlayerPrefs.GetInt("Heart") + 1;
        if (heart > 5) heart = 5;
        PlayerPrefs.SetInt("Heart", heart);
        PlayerPrefs.Save();
    }

    public void DecreaseHeart()
    {
        int heart = PlayerPrefs.GetInt("Heart") - 1;
        if (heart < 0) heart = 0;
        PlayerPrefs.SetInt("Heart", heart);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
