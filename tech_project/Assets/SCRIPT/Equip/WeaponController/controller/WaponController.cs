using TMPro;
using UnityEngine;
using UnityEngine.UI;
using weapon;
using DTO.TimerDTO;

public class WaponController : Gun
{
    public static WaponController instance;

    private TimerDTO timerDTO;
    public TextMeshProUGUI BulletText;
    public Button Reload_btn_UI;

    [SerializeField]
    private GameObject TacticalLight;

    [SerializeField]
    private float fixValue = 0f;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        
        timerDTO = TimerDTO.Instance;
        currentWeapon = M1911.Instance;
        SetWeaponProperties(currentWeapon);
        Reload_btn_UI.onClick.AddListener(Reload);
        TacticalLight.SetActive(false);
        equipWeapon("M1911");
        
    }

    void FixedUpdate()
    {
        //gunDTO.setFixRotation(fixValue);
        swapWeapon();
        BulletText.text = gunDTO.getAmmo() + " / " + gunDTO.getMaxAmmo();
        fireWeapon();
        if(gunDTO.getWeaponId() == "M1911" && gunDTO.getAmmo() <= 0){Reload();}
        activeTacticalLight();
    }


    private void activeTacticalLight(){
        if(timerDTO.getHour() >= 18 || timerDTO.getHour() <= 6){TacticalLight.SetActive(true);}
        else{TacticalLight.SetActive(false);}
    }
    public void atkButtonPressed(){
        atk_btn_down = true;
        Debug.Log("atkButtonPressed");
    }

    public void atkButtonUp(){
        atk_btn_down = false;
    }


    
}