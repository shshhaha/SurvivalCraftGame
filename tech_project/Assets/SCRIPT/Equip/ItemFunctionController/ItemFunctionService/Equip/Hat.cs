using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTO.PlayerDTO;
using DTO.WeaponDTO.GunDTO;


public class Hat : MonoBehaviour
{
    private PlayerDTO pdto; // VO 접근
    private GunDTO gdto;

    public static Hat instance ;
    private int HatHP = 50; // 체력 증가량 (임시)   
    private float PlusCritical = 0.05f; // 치명타 확률 증가량 (임시)
    public static int HatClass;
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

    public static Hat Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Hat>();
            }
            return instance;
        }
    }

    public void HatLogic()
    {
        if (pdto != null)
        {
            pdto.setMaxHp((int)pdto.getMaxHp() + HatHP);
        }
        else
        {
            Debug.LogError("PlayerDTO가 초기화되지 않음.");
        }

        if (gdto != null)
        {
            Debug.Log("변경전 gdto.getCreaticalRNG() : " + gdto.getCreaticalRNG());
            gdto.setCreaticalRNG(gdto.getCreaticalRNG() + PlusCritical);
            Debug.Log("변경후 gdto.getCreaticalRNG() : " + gdto.getCreaticalRNG());
        }
        else
        {
            Debug.LogError("GunDTO가 초기화되지 않음.");
        }

    }

    // public void HatClassCHeck() // 모자 단계별 체력 증가량 (임시)
    // {   
    //     if (HatClass == 0)
    //     {
    //         HatHP = 0;
    //         PlusCritical = 0;
    //     }                        
    //     else if (HatClass == 1)
    //     {
    //         HatHP = 50;
    //         PlusCritical = 0.05f;
    //     }
    //     else if (HatClass == 2)
    //     {
    //         HatHP = 100;
    //         PlusCritical = 0.1f;
    //     }
    //     else if (HatClass == 3)
    //     {
    //         HatHP = 200;
    //         PlusCritical = 0.2f;
    //     }
    // }


}
