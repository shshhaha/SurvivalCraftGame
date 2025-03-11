using System;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        LoadData();
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
        //ResetData();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
        //ResetData();
    }

    public void LoadData()
    {
        // 기본값 설명 : PlayerPrefs.GetInt("키값", 기본값) 기본값은 저장된 값이 없을 경우 사용됨
        // 저장된 게임머니 불러오기 (기본값: 0)
        PlayerPrefs.GetInt("Dollar", 3000);
        PlayerPrefs.GetInt("Medal", 0);
        PlayerPrefs.GetInt("Heart", 0);

        // 저장된 플레이어 스텟 불러오기 (기본값: 0)
        PlayerPrefs.GetInt("HealthLevel", 0);
        PlayerPrefs.GetInt("HealthExp", 0);
        PlayerPrefs.GetInt("AtkLevel", 0);
        PlayerPrefs.GetInt("AtkExp", 0);
        PlayerPrefs.GetInt("ReloadSpeedLevel", 0);
        PlayerPrefs.GetInt("ReloadSpeedExp", 0);
        PlayerPrefs.GetInt("CriticalLevel", 0);
        PlayerPrefs.GetInt("CriticalExp", 0);
        PlayerPrefs.GetInt("CriticalDamageLevel", 0);
        PlayerPrefs.GetInt("CriticalDamageExp", 0);

        // 마지막 하트 증가 시간 불러오기(기본값: 현재시간)
        PlayerPrefs.GetString("LastHeartIncreaseTime", DateTime.Now.ToString());
        
        // 저장된 플레이어 이름 불러오기 (기본값: "USER")
        PlayerPrefs.GetString("PlayerName", "USER");

        PlayerPrefs.Save();
    }

    //디버그 용 초기화 코드
    public void ResetData()
    {
        PlayerPrefs.SetInt("Dollar", 0);
        PlayerPrefs.SetInt("Medal", 0);
        PlayerPrefs.SetInt("Heart", 0);

        PlayerPrefs.SetInt("HealthLevel", 0);
        PlayerPrefs.SetInt("HealthExp", 0);
        PlayerPrefs.SetInt("AtkLevel", 0);
        PlayerPrefs.SetInt("AtkExp", 0);
        PlayerPrefs.SetInt("ReloadSpeedLevel", 0);
        PlayerPrefs.SetInt("ReloadSpeedExp", 0);
        PlayerPrefs.SetInt("CriticalLevel", 0);
        PlayerPrefs.SetInt("CriticalExp", 0);
        PlayerPrefs.SetInt("CriticalDamageLevel", 0);
        PlayerPrefs.SetInt("CriticalDamageExp", 0);
        
        PlayerPrefs.SetString("PlayerName", "USER");
        PlayerPrefs.SetString("LastHeartIncreaseTime", DateTime.Now.ToString());


        PlayerPrefs.Save();
    }

    // 플레이어 이름 설정
    public void SetPlayerName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
        PlayerPrefs.Save();
    }
}