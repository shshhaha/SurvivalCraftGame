using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeService : MonoBehaviour
{
    [SerializeField] private GameObject NotEnugh;
    [SerializeField] private GameObject Blocker;

    public void OnHealthUpgradeButtonClicked()
    {
        bool check = CheckGameMoney(PlayerPrefs.GetInt("HealthExp"), PlayerPrefs.GetInt("HealthLevel"));
        if(check)
        {
            PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") - ((PlayerPrefs.GetInt("HealthLevel") * UpgradeController.initExpValue) - PlayerPrefs.GetInt("HealthExp")));
            PlayerPrefs.SetInt("HealthLevel", PlayerPrefs.GetInt("HealthLevel") + 1);
            PlayerPrefs.SetInt("HealthExp", 0);
            PreventNegativeMoney();
            PlayerPrefs.Save();
        }
        else
        {
            NotEnughGameMoney();
        }
    }
    public void OnHealthUpCashButtonClicked()
    {
        bool check = CheckCash(PlayerPrefs.GetInt("HealthExp"), PlayerPrefs.GetInt("HealthLevel"));
        if(check)
        {
            PlayerPrefs.SetInt("Medal", PlayerPrefs.GetInt("Medal") - ((PlayerPrefs.GetInt("HealthLevel") * UpgradeController.initExpValue - PlayerPrefs.GetInt("HealthExp"))/UpgradeController.expDivideMedal));
            PlayerPrefs.SetInt("HealthLevel", PlayerPrefs.GetInt("HealthLevel") + 1);
            PlayerPrefs.SetInt("HealthExp", 0);
            PreventNegativeMoney();
            PlayerPrefs.Save();
        }
        else
        {
            NotEnughGameMoney();
        }
    }

    public void OnAtkUpgradeButtonClicked()
    {
        bool check = CheckGameMoney(PlayerPrefs.GetInt("AtkExp"), PlayerPrefs.GetInt("AtkLevel"));
        if(check)
        {
            PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") - ((PlayerPrefs.GetInt("AtkLevel") * UpgradeController.initExpValue) - PlayerPrefs.GetInt("AtkExp")));
            PlayerPrefs.SetInt("AtkLevel", PlayerPrefs.GetInt("AtkLevel") + 1);
            PlayerPrefs.SetInt("AtkExp", 0);
            PreventNegativeMoney();
            PlayerPrefs.Save();
        }
        else
        {
            NotEnughGameMoney();
        }
    }
    public void OnAtkUpCashButtonClicked()
    {
        bool check = CheckCash(PlayerPrefs.GetInt("AtkExp"), PlayerPrefs.GetInt("AtkLevel"));
        if(check)
        {
            PlayerPrefs.SetInt("Medal", PlayerPrefs.GetInt("Medal") - (PlayerPrefs.GetInt("AtkLevel") * UpgradeController.initExpValue - PlayerPrefs.GetInt("AtkExp"))/UpgradeController.expDivideMedal);
            PlayerPrefs.SetInt("AtkLevel", PlayerPrefs.GetInt("AtkLevel") + 1);
            PlayerPrefs.SetInt("AtkExp", 0);
            PreventNegativeMoney();
            PlayerPrefs.Save();
        }
        else
        {
            NotEnughGameMoney();
        }
    }

    public void OnReloadSpeedUpgradeButtonClicked()
    {
        bool check = CheckGameMoney(PlayerPrefs.GetInt("ReloadSpeedExp"), PlayerPrefs.GetInt("ReloadSpeedLevel"));
        if(check)
        {
            PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") - ((PlayerPrefs.GetInt("ReloadSpeedLevel") * UpgradeController.initExpValue) - PlayerPrefs.GetInt("ReloadSpeedExp")));
            PlayerPrefs.SetInt("ReloadSpeedLevel", PlayerPrefs.GetInt("ReloadSpeedLevel") + 1);
            PlayerPrefs.SetInt("ReloadSpeedExp", 0);
            PreventNegativeMoney();
            PlayerPrefs.Save();
        }
        else
        {
            NotEnughGameMoney();
        }
    }
    public void OnReloadSpeedUpCashButtonClicked()
    {
        bool check = CheckCash(PlayerPrefs.GetInt("ReloadSpeedExp"), PlayerPrefs.GetInt("ReloadSpeedLevel"));
        if(check)
        {
            PlayerPrefs.SetInt("Medal", PlayerPrefs.GetInt("Medal") - (PlayerPrefs.GetInt("ReloadSpeedLevel") * UpgradeController.initExpValue - PlayerPrefs.GetInt("ReloadSpeedExp"))/UpgradeController.expDivideMedal);
            PlayerPrefs.SetInt("ReloadSpeedLevel", PlayerPrefs.GetInt("ReloadSpeedLevel") + 1);
            PlayerPrefs.SetInt("ReloadSpeedExp", 0);
            PreventNegativeMoney();
            PlayerPrefs.Save();
        }
        else
        {
            NotEnughGameMoney();
        }
    }
    

    public void OnCriticalUpgradeButtonClicked()
    {
        bool check = CheckGameMoney(PlayerPrefs.GetInt("CriticalExp"), PlayerPrefs.GetInt("CriticalLevel"));
        if(check)
        {
            PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") - ((PlayerPrefs.GetInt("CriticalLevel") * UpgradeController.initExpValue) - PlayerPrefs.GetInt("CriticalExp")));
            PlayerPrefs.SetInt("CriticalLevel", PlayerPrefs.GetInt("CriticalLevel") + 1);
            PlayerPrefs.SetInt("CriticalExp", 0);
            PreventNegativeMoney();
            PlayerPrefs.Save();
        }
        else
        {
            NotEnughGameMoney();
        }
    }
    public void OnCriticalUpCashButtonClicked()
    {
        bool check = CheckCash(PlayerPrefs.GetInt("CriticalExp"), PlayerPrefs.GetInt("CriticalLevel"));
        if(check)
        {
            PlayerPrefs.SetInt("Medal", PlayerPrefs.GetInt("Medal") - (PlayerPrefs.GetInt("CriticalLevel") * UpgradeController.initExpValue - PlayerPrefs.GetInt("CriticalExp"))/UpgradeController.expDivideMedal);
            PlayerPrefs.SetInt("CriticalLevel", PlayerPrefs.GetInt("CriticalLevel") + 1);
            PlayerPrefs.SetInt("CriticalExp", 0);
            PreventNegativeMoney();
            PlayerPrefs.Save();
        }
        else
        {
            NotEnughGameMoney();
        }
    }

    public void OnCriticalDamageUpgradeButtonClicked()
    {
        bool check = CheckGameMoney(PlayerPrefs.GetInt("CriticalDamageExp"), PlayerPrefs.GetInt("CriticalDamageLevel"));
        if(check)
        {
            PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") - ((PlayerPrefs.GetInt("CriticalDamageLevel") * UpgradeController.initExpValue) - PlayerPrefs.GetInt("CriticalDamageExp")));
            PlayerPrefs.SetInt("CriticalDamageLevel", PlayerPrefs.GetInt("CriticalDamageLevel") + 1);
            PlayerPrefs.SetInt("CriticalDamageExp", 0);
            PreventNegativeMoney();
            PlayerPrefs.Save();
        }
        else
        {
            NotEnughGameMoney();
        }
    }
    public void OnCriticalDamageUpCashButtonClicked()
    {
        bool check = CheckCash(PlayerPrefs.GetInt("CriticalDamageExp"), PlayerPrefs.GetInt("CriticalDamageLevel"));
        if(check)
        {
            PlayerPrefs.SetInt("Medal", PlayerPrefs.GetInt("Medal") - (PlayerPrefs.GetInt("CriticalDamageLevel") * UpgradeController.initExpValue - PlayerPrefs.GetInt("CriticalDamageExp"))/UpgradeController.expDivideMedal);
            PlayerPrefs.SetInt("CriticalDamageLevel", PlayerPrefs.GetInt("CriticalDamageLevel") + 1);
            PlayerPrefs.SetInt("CriticalDamageExp", 0);
            PreventNegativeMoney();
            PlayerPrefs.Save();
        }
        else
        {
            NotEnughGameMoney();
        }
    }

    private void NotEnughGameMoney()
    {
        NotEnugh.SetActive(true);
        Blocker.SetActive(true);
        Image[] images = NotEnugh.GetComponentsInChildren<Image>();
        Text[] texts = NotEnugh.GetComponentsInChildren<Text>();

            // 각 Image와 Text 컴포넌트의 Color의 alpha 값을 2초 동안 0으로 변경하여 페이드 아웃 효과를 줍니다.
            foreach (Image image in images)
            {
                image.DOFade(0f, 1.5f).SetDelay(0.5f);
            }
            foreach (Text text in texts)
            {
                text.DOFade(0f, 1.5f).SetDelay(0.5f);
            }

            // 2초 후에 NotEnugh 게임 오브젝트를 비활성화합니다.
            StartCoroutine(DisableAfterSeconds(NotEnugh,Blocker, 2f));
    }
    private IEnumerator DisableAfterSeconds(GameObject gameObject, GameObject gameObject2, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
        gameObject2.SetActive(false);
        Image[] images = NotEnugh.GetComponentsInChildren<Image>();
        Text[] texts = NotEnugh.GetComponentsInChildren<Text>();
        foreach (Image image in images)
        {
            image.DOFade(1f, 0f);
        }
        foreach (Text text in texts)
        {
            text.DOFade(1f, 0f);
        }
    }

    private bool CheckGameMoney(int exp, int level)
    {
        if(PlayerPrefs.GetInt("Dollar") >= (level * UpgradeController.initExpValue) - exp){ return true; }
        else{ return false; }
    }
    private bool CheckCash(int exp, int level)
    {
        if(PlayerPrefs.GetInt("Medal") >= ((level * UpgradeController.initExpValue) - exp)/UpgradeController.expDivideMedal) { return true; }
        else{ return false; }
    }
    private void PreventNegativeMoney()
    {
        if(PlayerPrefs.GetInt("Dollar") < 0)
        {
            PlayerPrefs.SetInt("Dollar", 0);
        }
        if(PlayerPrefs.GetInt("Medal") < 0)
        {
            PlayerPrefs.SetInt("Medal", 0);
        }
    }
    
}
