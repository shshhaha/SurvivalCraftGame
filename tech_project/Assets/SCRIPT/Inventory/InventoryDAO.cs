using DataBase;
using Item_Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item_Tooltip;
using MainInventory.ItemSlot;
using Item_QuickSlot;



public class InventoryDAO : MonoBehaviour
{
    public static InventoryDAO instance;
    public static InventorySlot[] I_slots; // 인벤토리 슬롯들
    public static DatabaseManager InventheDatabase;

    public static int selectedTab ; // 선택된 탭

    public static List<Item> inventoryItemList; // 플레이어가 소지한 아이템 리스트
    public static List<Item> inventoryTabList; // 선택한 탭에 따라 다르게 보여질 아이템

    void Start()
    {
        InventheDatabase = FindObjectOfType<DatabaseManager>();
        inventoryItemList = new List<Item>();
        inventoryTabList = new List<Item>();
        instance = this;
    }



    
    public void GetInvenItem(string _itemID, int _itemCount =1 ) //아이템 픽업 연결부분
    { 
        for (int i=0; i<InventheDatabase.itemList.Count; i++) // 데이터베이스 아이템 검색 (아이템 다 추가하고 삭제 가능)
        {
            if(_itemID == InventheDatabase.itemList[i].itemID) // 데이터베이스 아이템 발견 (아이템 다 추가하고 삭제 가능)
            {
                for(int j=0; j<inventoryItemList.Count; j++) // 소지품에 같은 아이템이 있는지 검색
                {
                    if(inventoryItemList[j].itemID == _itemID) // 참일경우 개수만 증가
                    {
                        if(inventoryItemList[j].itemType == Item.ItemType.Equip) // 아이템 타입이 장비이면 리스트에 추가
                        {
                            inventoryItemList.Add(InventheDatabase.itemList[i]);
                            return;
                        }
                        else // 아닐경우 갯수 증가
                        {
                            inventoryItemList[j].itemCount += _itemCount;
                            return;
                        }
                    }
                }
                inventoryItemList.Add(InventheDatabase.itemList[i]); // 거짓일 경우 아이템 추가
                return;
            }
        }
        Debug.Log("데이터베이스에 해당 아이디를 가진 아이템이 존재하지 않음"); // 데이터베이스에 아이디없을 경우 에러
    }

    public static void RemoveInvenSlot() // 인벤토리 슬롯 초기화
    {
        if (I_slots != null)
        {
            for (int i = 0; i < I_slots.Length; i++)
            {
                I_slots[i].RemoveItem();
                I_slots[i].gameObject.SetActive(false);
            }
        }
        else return;
    }

    public static void ShowInvenTab() //아이템 탭에 따라 다르게 보여질 아이템
    {
        RemoveInvenSlot();
        inventoryTabList.Clear(); // inventoryTabList를 초기화합니다.

        switch (selectedTab)
        {
            case 0: // 장비 아이템 탭이 선택된 경우
                //Debug.Log("----장비버튼 눌러짐----");
                foreach (var item in inventoryItemList)
                {
                    if (item.itemType == Item.ItemType.Equip)
                    {
                        inventoryTabList.Add(item);
                    }
                }
                break;
            case 1: // 사용 아이템 탭이 선택된 경우
                //Debug.Log("----사용버튼 눌러짐----");
                foreach (var item in inventoryItemList)
                {
                    if (item.itemType == Item.ItemType.Use)
                    {
                        inventoryTabList.Add(item);
                    }
                }
                break;
            // 필요한 경우 여기에 더 많은 탭을 추가할 수 있습니다.
        }

        // 선택된 탭 이미지를 업데이트합니다.
        
        
        if (inventoryTabList.Count < 21) //아이템 갯수가 20개를 넘길 경우
        {
            if (I_slots != null)
            {
                for (int i = 0; i < inventoryTabList.Count; i++)
                {
                    I_slots[i].AddItem(inventoryTabList[i]);
                    I_slots[i].gameObject.SetActive(true);
                    //ItemTooltip.instance.ShowTooltip(inventoryTabList[i].itemID);
                    //Debug.Log("선택된 탭 이미지 업데이트");
                    //Debug.Log("가지고 있는 아이템 : "+inventoryTabList[i].itemID);
                } 
            }
            
        }
        else //임시로 넣어둔거
        {
            for (int i = 0; i < 21; i++)
            {
                I_slots[i].AddItem(inventoryTabList[i]);
                I_slots[i].gameObject.SetActive(true);
                //ItemTooltip.instance.ShowTooltip(inventoryTabList[i].itemID);
                //Debug.Log("선택된 탭 이미지 업데이트");
                //Debug.Log("가지고 있는 아이템 : "+inventoryTabList[i].itemID);
            }
        }
        
    }
    



}

