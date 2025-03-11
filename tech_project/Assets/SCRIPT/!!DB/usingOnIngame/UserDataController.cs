using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataController : MonoBehaviour
{
    public static int health;
    public static float atk;
    public static float reloadSpeed;
    public static float criticalRNG;
    public static float criticalDamage;

    public static int healthExp;
    public static int atkExp;//적용한곳 : 총쏠때 발당 +1,
    public static int reloadSpeedExp;//적용한곳 : 총알이 0일때 장전 +5,
    public static int criticalRNGExp;//적용한곳 : 치명타시 +3,
    public static int criticalDamageExp;//적용한곳 : 치명타시 +3,

    public static void AddUserExp()
    {
        PlayerPrefs.SetInt("HealthExp", PlayerPrefs.GetInt("HealthExp") + healthExp);
        PlayerPrefs.SetInt("AtkExp", PlayerPrefs.GetInt("AtkExp") + atkExp);
        PlayerPrefs.SetInt("ReloadSpeedExp", PlayerPrefs.GetInt("ReloadSpeedExp") + reloadSpeedExp);
        PlayerPrefs.SetInt("CriticalExp", PlayerPrefs.GetInt("CriticalExp") + criticalRNGExp);
        PlayerPrefs.SetInt("CriticalDamageExp", PlayerPrefs.GetInt("CriticalDamageExp") + criticalDamageExp);
        PlayerPrefs.Save();
    }

    public static void AddUserDollar(int rewardDollar)
    {
        PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") + rewardDollar);
    }

    public static int GameEndReward(int ingGmeMoney, int divideExpValue)
    {
        int exp = healthExp + atkExp + reloadSpeedExp + criticalRNGExp + criticalDamageExp;
        int rewardDollar = ingGmeMoney + exp/divideExpValue;

        return rewardDollar;
    }

    public static void initData()//
    {
        healthExp = 0;
        atkExp = 0;
        reloadSpeedExp = 0;
        criticalRNGExp = 0;
        criticalDamageExp = 0;
    }
}
