using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTO.PlayerDTO;
using DTO.WeaponDTO.GunDTO;


public class Pants : MonoBehaviour
{
    private PlayerDTO pdto; // VO 접근
    private GunDTO gdto;

    public static Pants instance ;
    private int PantsHP = 50; // 체력 증가량 (임시)   
    private float PlusMove = 0.5f; // 이동속도 증가량 (임시)
    public static int PantsClass;
    void Start()
    {
        pdto = PlayerDTO.Instance;
        gdto = GunDTO.Instance;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스 삭제
        }
    }

    public static Pants Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Pants>();
            }
            return instance;
        }
    }

    public void PantsLogic()
    {
        if (pdto != null)
        {
            pdto.setMaxHp((int)pdto.getMaxHp() + PantsHP);
        }
        else
        {
            Debug.LogError("PlayerDTO가 초기화되지 않음.");
        }

        if (gdto != null)
        {
            //gdto.setCreaticalRNG(gdto.getCreaticalRNG() + PlusCritical);
        }
        else
        {
            Debug.LogError("GunDTO가 초기화되지 않음.");
        }

    }

    public void PantsClassCHeck() // 모자 단계별 체력 증가량 (임시)
    {   
        if (PantsClass == 0)
        {
            PantsHP = 0;
        }                        
        else if (PantsClass == 1)
        {
            PantsHP = 50;
        }
        else if (PantsClass == 2)
        {
            PantsHP = 100;
        }
        else if (PantsClass == 3)
        {
            PantsHP = 200;
        }
    }


}
