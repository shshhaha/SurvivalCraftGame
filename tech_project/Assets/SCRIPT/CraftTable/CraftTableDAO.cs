using System.Collections.Generic;
using UnityEngine;
using Item_Base;
using DataBase;
using MainInventory.ItemSlot;
using System;

public class CraftTableDAO : MonoBehaviour
{

    public static CraftTableDAO instance;

    public static InventorySlot[] M_slots; // 재료아이템 슬롯들
    public static InventorySlot[] C_slots; // 제작할아이템 슬롯들

    public static List<Item> MaterItemList; // 플레이어가 소지한 '재료아이템' 리스트
    public static List<Item> CraftItemList; // 선택한 탭에 따라 다르게 보여질 '제젝할' 아이템
    public static int craftTab = 0; // 선택된 탭

    public static DatabaseManager MatertheDatabase;


    void Awake()
    {
        instance = this;
        MatertheDatabase = FindObjectOfType<DatabaseManager>();
        MaterItemList = new List<Item>();
        CraftItemList = new List<Item>();
    }


    public void GetMaterItem(string _itemID, int _itemCount=1) //아이템 픽업 연결부분
    { 
        for (int i=0; i<MatertheDatabase.itemList.Count; i++) // 데이터베이스 아이템 검색 (아이템 다 추가하고 삭제 가능)
        {
            if(_itemID == MatertheDatabase.itemList[i].itemID) // 데이터베이스 아이템 발견 (아이템 다 추가하고 삭제 가능)
            {
                for(int j=0; j<MaterItemList.Count; j++) // 소지품에 같은 아이템이 있는지 검색
                {
                    if(MaterItemList[j].itemID == _itemID) // 참일경우 개수만 증가
                    {
                        MaterItemList[j].itemCount += _itemCount;
                        return;
                    }
                }
                MaterItemList.Add(MatertheDatabase.itemList[i]); // 거짓일 경우 아이템 추가
                return;
            }
        }
        Debug.Log("데이터베이스에 해당 아이디를 가진 아이템이 존재하지 않음"); // 데이터베이스에 아이디없을 경우 에러
    }


    public static void RemoveMaterSlot() // 인벤토리 슬롯 초기화
    {
        for (int i = 0; i < M_slots.Length; i++)
        {
            M_slots[i].RemoveItem();
            M_slots[i].gameObject.SetActive(false);
        }
    }
    public static void RemoveCraftSlot() // 인벤토리 슬롯 초기화
    {
        for (int i = 0; i < 8; i++)
        {
            C_slots[i].RemoveItem();
            C_slots[i].gameObject.SetActive(false);
        }
    }

    public static void ShowMaterTab() 
    {
        RemoveMaterSlot();
        if (MaterItemList.Count < 24) //아이템 갯수가 20개를 넘길 경우
        {
            for (int i = 0; i < MaterItemList.Count; i++)
            {
                M_slots[i].gameObject.SetActive(true);
                M_slots[i].AddItem(MaterItemList[i]);
            } 
        }
        else //임시로 넣어둔거
        {
            for (int i = 0; i < 24; i++)
            {
                M_slots[i].gameObject.SetActive(true);
                M_slots[i].AddItem(MaterItemList[i]);
            }
        }
        
    }

    public static void ShowCraftTab() //아이템 탭에 따라 다르게 보여질 아이템
    {
        RemoveCraftSlot();

        switch (craftTab)
        {
            case 0: //무기
                for (int i = 0; i < Math.Min(CraftItemList.Count, 8); i++)
                {
                    C_slots[i].gameObject.SetActive(true);
                    if(CraftItemList[i].itemID != " ")
                    {
                        C_slots[i].AddItem(CraftItemList[i]);
                        C_slots[i].transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1);
                    }
                    else
                    {
                        C_slots[i].transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0); // 아이템이 없는 경우 이미지를 숨깁니다.
                    }
                    
                }
                break;

            case 1: //무기
                for (int i = 8; i < Math.Min(CraftItemList.Count, 16); i++)
                {
                    C_slots[i-8].gameObject.SetActive(true);
                    if(CraftItemList[i].itemID != " ")
                    {
                        C_slots[i-8].AddItem(CraftItemList[i]);
                        C_slots[i-8].transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1);                            
                    }
                    else
                    {
                        C_slots[i-8].transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0); // 아이템이 없는 경우 이미지를 숨깁니다.
                    }
                }
                break;

            case 2: //모자
                for (int i = 16; i < Math.Min(CraftItemList.Count, 24); i++)
                {
                    C_slots[i-16].gameObject.SetActive(true);
                    if(CraftItemList[i].itemID != " ")
                    {
                        C_slots[i-16].AddItem(CraftItemList[i]);
                        C_slots[i-16].transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1);
                    }
                    else
                    {
                        C_slots[i-16].transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0); // 아이템이 없는 경우 이미지를 숨깁니다.
                    }
                }
                break;

            case 3: //상의
                for (int i = 24; i < Math.Min(CraftItemList.Count, 32); i++)
                {
                    C_slots[i-24].gameObject.SetActive(true);
                    if(CraftItemList[i].itemID != " ")
                    {
                        C_slots[i-24].AddItem(CraftItemList[i]);
                        C_slots[i-24].transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1);
                    }
                    else
                    {
                        C_slots[i-24].transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0); // 아이템이 없는 경우 이미지를 숨깁니다.
                    }
                }
                break;
            case 4: //하의
                for (int i = 32; i < Math.Min(CraftItemList.Count, 40); i++)
                {
                    C_slots[i-32].gameObject.SetActive(true);
                    if(CraftItemList[i].itemID != " ")
                    {
                        C_slots[i-32].AddItem(CraftItemList[i]);
                        C_slots[i-32].transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1);
                    }
                    else
                    {
                        C_slots[i-32].transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0); // 아이템이 없는 경우 이미지를 숨깁니다.
                    }
                }
                break;
        }
    }


}
