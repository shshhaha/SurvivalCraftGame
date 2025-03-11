using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] UpgradeService upgradeService;

    [SerializeField]public static int initExpValue = 512;
    [SerializeField]public static int expDivideMedal = 8;

    [SerializeField] private TextMeshProUGUI HealthLevel;//체력 레벨
    [SerializeField] private TextMeshProUGUI HealthExp;//체력 경험치
    [SerializeField] private Slider HealthSlider;//체력 경험치 슬라이더
    [SerializeField] private TextMeshProUGUI CurrentHealthBonus;//현재 체력 보너스
    [SerializeField] protected Button HealthUpgradeButton;//체력 업그레이드 버튼
    [SerializeField] protected Button HealthUpCashButton;//체력 업그레이드 버튼
    [SerializeField] protected TextMeshProUGUI CostOfHealthUpgrade;//체력 업그레이드 비용
    [SerializeField] protected TextMeshProUGUI CostOfHealthUpCash;//체력 업그레이드 비용

    [SerializeField] private TextMeshProUGUI AtkLevel;//공격력 레벨
    [SerializeField] private TextMeshProUGUI AtkExp;//공격력 경험치
    [SerializeField] private Slider AtkSlider;//공격력 경험치 슬라이더
    [SerializeField] private TextMeshProUGUI CurrentAtkBonus;//현재 공격력 보너스
    [SerializeField] protected Button AtkUpgradeButton;//공격력 업그레이드 버튼
    [SerializeField] protected Button AtkUpCashButton;//공격력 업그레이드 버튼
    [SerializeField] protected TextMeshProUGUI CostOfAtkUpgrade;//공격력 업그레이드 비용
    [SerializeField] protected TextMeshProUGUI CostOfAtkUpCash;//공격력 업그레이드 비용

    [SerializeField] private TextMeshProUGUI ReloadSpeedLevel;//장전속도 레벨
    [SerializeField] private TextMeshProUGUI ReloadSpeedExp;//장전속도 경험치
    [SerializeField] private Slider ReloadSpeedSlider;//장전속도 경험치 슬라이더
    [SerializeField] private TextMeshProUGUI CurrentReloadSpeedBonus;//현재 장전속도 보너스
    [SerializeField] protected Button ReloadSpeedUpgradeButton;//장전속도 업그레이드 버튼
    [SerializeField] protected Button ReloadSpeedUpCashButton;//장전속도 업그레이드 버튼
    [SerializeField] protected TextMeshProUGUI CostOfReloadSpeedUpgrade;//장전속도 업그레이드 비용
    [SerializeField] protected TextMeshProUGUI CostOfReloadSpeedUpCash;//장전속도 업그레이드 비용

    [SerializeField] private TextMeshProUGUI CriticalLevel;//치명타확률 레벨
    [SerializeField] private TextMeshProUGUI CriticalExp;//치명타확률 경험치
    [SerializeField] private Slider CriticalSlider;//치명타확률 경험치 슬라이더
    [SerializeField] private TextMeshProUGUI CurrentCriticalBonus;//현재 치명타확률 보너스
    [SerializeField] protected Button CriticalUpgradeButton;//치명타확률 업그레이드 버튼
    [SerializeField] protected Button CriticalUpCashButton;//치명타확률 업그레이드 버튼
    [SerializeField] protected TextMeshProUGUI CostOfCriticalUpgrade;//치명타확률 업그레이드 비용
    [SerializeField] protected TextMeshProUGUI CostOfCriticalUpCash;//치명타확률 업그레이드 비용

    [SerializeField] private TextMeshProUGUI CriticalDamageLevel;//치명타데미지 레벨
    [SerializeField] private TextMeshProUGUI CriticalDamageExp;//치명타데미지 경험치
    [SerializeField] private Slider CriticalDamageSlider;//치명타데미지 경험치 슬라이더
    [SerializeField] private TextMeshProUGUI CurrentCriticalDamageBonus;//현재 치명타데미지 보너스
    [SerializeField] protected Button CriticalDamageUpgradeButton;//치명타데미지 업그레이드 버튼
    [SerializeField] protected Button CriticalDamageUpCashButton;//치명타데미지 업그레이드 버튼
    [SerializeField] protected TextMeshProUGUI CostOfCriticalDamageUpgrade;//치명타데미지 업그레이드 비용
    [SerializeField] protected TextMeshProUGUI CostOfCriticalDamageUpCash;//치명타데미지 업그레이드 비용


    void Start()
    {
        HealthUpgradeButton.onClick.AddListener(upgradeService.OnHealthUpgradeButtonClicked);
        AtkUpgradeButton.onClick.AddListener(upgradeService.OnAtkUpgradeButtonClicked);
        ReloadSpeedUpgradeButton.onClick.AddListener(upgradeService.OnReloadSpeedUpgradeButtonClicked);
        CriticalUpgradeButton.onClick.AddListener(upgradeService.OnCriticalUpgradeButtonClicked);
        CriticalDamageUpgradeButton.onClick.AddListener(upgradeService.OnCriticalDamageUpgradeButtonClicked);

        HealthUpCashButton.onClick.AddListener(upgradeService.OnHealthUpCashButtonClicked);
        AtkUpCashButton.onClick.AddListener(upgradeService.OnAtkUpCashButtonClicked);
        ReloadSpeedUpCashButton.onClick.AddListener(upgradeService.OnReloadSpeedUpCashButtonClicked);
        CriticalUpCashButton.onClick.AddListener(upgradeService.OnCriticalUpCashButtonClicked);
        CriticalDamageUpCashButton.onClick.AddListener(upgradeService.OnCriticalDamageUpCashButtonClicked);
    }

    void Update()
    {
        CheckMaxLevel();

        CostOfHealthUpgrade.text = ((PlayerPrefs.GetInt("HealthLevel") * initExpValue) - PlayerPrefs.GetInt("HealthExp")).ToString("N0");
        CostOfAtkUpgrade.text = ((PlayerPrefs.GetInt("AtkLevel") * initExpValue) - PlayerPrefs.GetInt("AtkExp")).ToString("N0");
        CostOfReloadSpeedUpgrade.text = ((PlayerPrefs.GetInt("ReloadSpeedLevel") * initExpValue) - PlayerPrefs.GetInt("ReloadSpeedExp")).ToString("N0");
        CostOfCriticalUpgrade.text = ((PlayerPrefs.GetInt("CriticalLevel") * initExpValue) - PlayerPrefs.GetInt("CriticalExp")).ToString("N0");
        CostOfCriticalDamageUpgrade.text = ((PlayerPrefs.GetInt("CriticalDamageLevel") * initExpValue) - PlayerPrefs.GetInt("CriticalDamageExp")).ToString("N0");

        CostOfHealthUpCash.text = ((PlayerPrefs.GetInt("HealthLevel") * initExpValue - PlayerPrefs.GetInt("HealthExp"))/expDivideMedal).ToString("N0");
        CostOfAtkUpCash.text = ((PlayerPrefs.GetInt("AtkLevel") * initExpValue - PlayerPrefs.GetInt("AtkExp"))/expDivideMedal).ToString("N0");
        CostOfReloadSpeedUpCash.text = ((PlayerPrefs.GetInt("ReloadSpeedLevel") * initExpValue - PlayerPrefs.GetInt("ReloadSpeedExp"))/expDivideMedal).ToString("N0");
        CostOfCriticalUpCash.text = ((PlayerPrefs.GetInt("CriticalLevel") * initExpValue - PlayerPrefs.GetInt("CriticalExp"))/expDivideMedal).ToString("N0");
        CostOfCriticalDamageUpCash.text = ((PlayerPrefs.GetInt("CriticalDamageLevel") * initExpValue - PlayerPrefs.GetInt("CriticalDamageExp"))/expDivideMedal).ToString("N0");
    }

    public void CheckMaxLevel()//성능향상을 위해 리팩토링 필요
    {
        if(PlayerPrefs.GetInt("HealthLevel")>=30){
            HealthUpgradeButton.interactable = false;
            if(PlayerPrefs.GetInt("HealthLevel")>=35){
                HealthUpCashButton.interactable = false;
            }
            HealthExp.text = "MAX";
            HealthSlider.value =  HealthSlider.maxValue;
        }
        else
        {
            if(PlayerPrefs.GetInt("HealthExp") >= PlayerPrefs.GetInt("HealthLevel") * initExpValue)
            {
                PlayerPrefs.SetInt("HealthLevel", PlayerPrefs.GetInt("HealthLevel") + 1);
                PlayerPrefs.SetInt("HealthExp", 0);
                PlayerPrefs.Save();
            }
            else if(PlayerPrefs.GetInt("HealthLevel") <= 30)
            {
                HealthExp.text = PlayerPrefs.GetInt("HealthExp", 0).ToString() + " / " + (PlayerPrefs.GetInt("HealthLevel") * initExpValue).ToString();
                HealthSlider.maxValue = PlayerPrefs.GetInt("HealthLevel") * initExpValue;
                HealthSlider.value = PlayerPrefs.GetInt("HealthExp");
            }
        }
            HealthLevel.text = PlayerPrefs.GetInt("HealthLevel", 1).ToString();
            CurrentHealthBonus.text = " HP + " + (PlayerPrefs.GetInt("HealthLevel", 1) * 15).ToString();
        //========================================================================================================
        if(PlayerPrefs.GetInt("AtkLevel")>=30){
            AtkUpgradeButton.interactable = false;
            if(PlayerPrefs.GetInt("AtkLevel")>=35){
                AtkUpCashButton.interactable = false;
            }
            AtkExp.text = "MAX";
            AtkSlider.value =  AtkSlider.maxValue;
        }
        else
        {
            if(PlayerPrefs.GetInt("AtkExp") >= PlayerPrefs.GetInt("AtkLevel") * initExpValue)
            {
                PlayerPrefs.SetInt("AtkLevel", PlayerPrefs.GetInt("AtkLevel") + 1);
                PlayerPrefs.SetInt("AtkExp", 0);
                PlayerPrefs.Save();
            }
            else if(PlayerPrefs.GetInt("AtkLevel") <= 30)
            {
                AtkExp.text = PlayerPrefs.GetInt("AtkExp", 0).ToString() + " / " + (PlayerPrefs.GetInt("AtkLevel") * initExpValue).ToString();
                AtkSlider.maxValue = PlayerPrefs.GetInt("AtkLevel") * initExpValue;
                AtkSlider.value = PlayerPrefs.GetInt("AtkExp");
            }
        }
            AtkLevel.text = PlayerPrefs.GetInt("AtkLevel", 1).ToString();
            CurrentAtkBonus.text = " ATK + " + (PlayerPrefs.GetInt("AtkLevel", 1) * 0.8f).ToString() + " %";
        //========================================================================================================
        if(PlayerPrefs.GetInt("ReloadSpeedLevel")>=30){
            ReloadSpeedUpgradeButton.interactable = false;
            if(PlayerPrefs.GetInt("ReloadSpeedLevel")>=35){
                ReloadSpeedUpCashButton.interactable = false;
            }
            ReloadSpeedExp.text = "MAX";
            ReloadSpeedSlider.value =  ReloadSpeedSlider.maxValue;
        }
        else
        {
            if(PlayerPrefs.GetInt("ReloadSpeedExp") >= PlayerPrefs.GetInt("ReloadSpeedLevel") * initExpValue)
            {
                PlayerPrefs.SetInt("ReloadSpeedLevel", PlayerPrefs.GetInt("ReloadSpeedLevel") + 1);
                PlayerPrefs.SetInt("ReloadSpeedExp", 0);
                PlayerPrefs.Save();
            }
            else if(PlayerPrefs.GetInt("ReloadSpeedLevel") <= 30)
            {
                ReloadSpeedExp.text = PlayerPrefs.GetInt("ReloadSpeedExp", 0).ToString() + " / " + (PlayerPrefs.GetInt("ReloadSpeedLevel") * initExpValue).ToString();
                ReloadSpeedSlider.maxValue = PlayerPrefs.GetInt("ReloadSpeedLevel") * initExpValue;
                ReloadSpeedSlider.value = PlayerPrefs.GetInt("ReloadSpeedExp");
            }
        }
            ReloadSpeedLevel.text = PlayerPrefs.GetInt("ReloadSpeedLevel", 1).ToString();
            CurrentReloadSpeedBonus.text = " RS + " + (PlayerPrefs.GetInt("ReloadSpeedLevel", 1) * 0.5f).ToString() + " %";
        //========================================================================================================
        if(PlayerPrefs.GetInt("CriticalLevel")>=30){
            CriticalUpgradeButton.interactable = false;
            if(PlayerPrefs.GetInt("CriticalLevel")>=35){
                CriticalUpCashButton.interactable = false;
            }
            CriticalExp.text = "MAX";
            CriticalSlider.value =  CriticalSlider.maxValue;
        }
        else
        {
            if(PlayerPrefs.GetInt("CriticalExp") >= PlayerPrefs.GetInt("CriticalLevel") * initExpValue)
            {
                PlayerPrefs.SetInt("CriticalLevel", PlayerPrefs.GetInt("CriticalLevel") + 1);
                PlayerPrefs.SetInt("CriticalExp", 0);
                PlayerPrefs.Save();
            }
            else if(PlayerPrefs.GetInt("CriticalLevel") <= 30)
            {
                CriticalExp.text = PlayerPrefs.GetInt("CriticalExp", 0).ToString() + " / " + (PlayerPrefs.GetInt("CriticalLevel") * initExpValue).ToString();
                CriticalSlider.maxValue = PlayerPrefs.GetInt("CriticalLevel") * initExpValue;
                CriticalSlider.value = PlayerPrefs.GetInt("CriticalExp");
            }
        }
            CriticalLevel.text = PlayerPrefs.GetInt("CriticalLevel", 1).ToString();
            CurrentCriticalBonus.text = " CR + " + (PlayerPrefs.GetInt("CriticalLevel", 1) * 0.75f).ToString() + " %";
        //========================================================================================================
        if(PlayerPrefs.GetInt("CriticalDamageLevel")>=30){
            CriticalDamageUpgradeButton.interactable = false;
            if(PlayerPrefs.GetInt("CriticalDamageLevel")>=35){
                CriticalDamageUpCashButton.interactable = false;
            }
            CriticalDamageExp.text = "MAX";
            CriticalDamageSlider.value =  CriticalDamageSlider.maxValue;
        }
        else
        {
            if(PlayerPrefs.GetInt("CriticalDamageExp") >= PlayerPrefs.GetInt("CriticalDamageLevel") * initExpValue)
            {
                PlayerPrefs.SetInt("CriticalDamageLevel", PlayerPrefs.GetInt("CriticalDamageLevel") + 1);
                PlayerPrefs.SetInt("CriticalDamageExp", 0);
                PlayerPrefs.Save();
            }
            else if(PlayerPrefs.GetInt("CriticalDamageLevel") <= 30)
            {
                CriticalDamageExp.text = PlayerPrefs.GetInt("CriticalDamageExp", 0).ToString() + " / " + (PlayerPrefs.GetInt("CriticalDamageLevel") * initExpValue).ToString();
                CriticalDamageSlider.maxValue = PlayerPrefs.GetInt("CriticalDamageLevel") * initExpValue;
                CriticalDamageSlider.value = PlayerPrefs.GetInt("CriticalDamageExp");
            }
        }
            CriticalDamageLevel.text = PlayerPrefs.GetInt("CriticalDamageLevel", 1).ToString();
            CurrentCriticalDamageBonus.text = " CD + " + (PlayerPrefs.GetInt("CriticalDamageLevel", 1) * 1.5f).ToString() + " %";
    }
}
