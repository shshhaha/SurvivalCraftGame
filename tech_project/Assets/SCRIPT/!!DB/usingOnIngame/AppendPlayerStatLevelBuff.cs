using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppendPlayerStatLevelBuff : UserDataController
{
    private void Awake()
    {
        // 동일한 오브젝트가 이미 존재하는지 확인
        if (FindObjectOfType<AppendPlayerStatLevelBuff>() != null)
        {
            // 동일한 오브젝트가 이미 존재하면 추가하지 않음
            return;
        }
        DontDestroyOnLoad(this.gameObject);

        LoadData();
    }

    
    void Start()
    {
        health = PlayerPrefs.GetInt("HealthLevel", 1) * 15;
        atk = PlayerPrefs.GetInt("AtkLevel", 1) * 0.8f;
        reloadSpeed = PlayerPrefs.GetInt("ReloadSpeedLevel", 1) * 0.5f;
        criticalRNG = PlayerPrefs.GetInt("CriticalLevel", 1) * 0.75f;
        criticalDamage = PlayerPrefs.GetInt("CriticalDamageLevel", 1) * 1.5f;

        Debug.Log("Health : " + health + "추가체력");
        Debug.Log("Atk : " + atk + "%");
        Debug.Log("ReloadSpeed : " + reloadSpeed + "%");
        Debug.Log("CriticalRNG : " + criticalRNG + "%");
        Debug.Log("CriticalDamage : " + criticalDamage + "%");
    }


    public void LoadData()
    {
        // 기본값 설명 : PlayerPrefs.GetInt("키값", 기본값) 기본값은 저장된 값이 없을 경우 사용됨
        // 저장된 게임머니 불러오기 (기본값: 0)
        PlayerPrefs.GetInt("Dollar", 0);
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

        PlayerPrefs.Save();
    }
}
