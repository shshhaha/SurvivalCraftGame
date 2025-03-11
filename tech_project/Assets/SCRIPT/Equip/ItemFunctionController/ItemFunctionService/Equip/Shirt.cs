using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTO.PlayerDTO;
using DTO.WeaponDTO.GunDTO;


public class Shirt : MonoBehaviour
{
    private PlayerDTO pdto; // VO 접근
    private GunDTO gdto;

    public static Shirt instance ;
    private int ShirtHP = 50; // 체력 증가량 (임시)   
    private float DivReload = 0.5f; // 장전속도 빨라짐 (임시)
    public static int ShirtClass;
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

    public static Shirt Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Shirt>();
            }
            return instance;
        }
    }

    public void ShirtLogic()
    {
        if (pdto != null)
        {
            pdto.setMaxHp((int)pdto.getMaxHp() + ShirtHP);
        }
        else
        {
            Debug.LogError("PlayerDTO가 초기화되지 않음.");
        }

        if (gdto != null)
        {
            //Debug.Log("변경전 gdto.getCreaticalRNG() : " + gdto.getCreaticalRNG());
            //gdto.setCreaticalRNG(gdto.getCreaticalRNG() + PlusCritical);
            //Debug.Log("변경후 gdto.getCreaticalRNG() : " + gdto.getCreaticalRNG());
        }
        else
        {
            Debug.LogError("GunDTO가 초기화되지 않음.");
        }

    }

    public void ShirtClassCHeck() // 상의 단계별 체력 증가량 + 장전속도 빨라짐 (임시)
    {   
        if (ShirtClass == 0)
        {
            ShirtHP = 0;
        }                        
        else if (ShirtClass == 1)
        {
            ShirtHP = 50;
        }
        else if (ShirtClass == 2)
        {
            ShirtHP = 100;
        }
        else if (ShirtClass == 3)
        {
            ShirtHP = 200;

        }
    }


}
