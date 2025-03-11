using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Item_Base;
using System;


namespace MainInventory.ItemSlot
{
public class InventorySlot : MonoBehaviour  // 인벤토리 아이템의 갯수와 아이콘를 변경하는 스크립트
{
    //public static InventorySlot instance;
    private Text itemName_Text;
    public Image itemIcon_Image;
    public Text itemCount_Text;
    public GameObject selected_Item;
    public Image selected_Item_Image;

    

    public void AddItem(Item _item)  //아이템 습득시 사용아이템이면 갯수증가 아니면 따로 한칸 잡아먹음 그래서 재료아이템도 사용아이템 타입에 넣어야됨
    {
        itemIcon_Image.sprite = _item.itemIcon; //아이콘 이미지넣는거
        if(Item.ItemType.Use == _item.itemType || Item.ItemType.Craft == _item.itemType){
            if(_item.itemCount > 0){
                itemCount_Text.text = _item.itemCount.ToString();
            }
            else{
                itemCount_Text.text = "";
            }
        }
    }

    public void RemoveItem()
    {
        itemCount_Text.text = "";
        //itemName_Text.text = "";
        itemIcon_Image.sprite = null;
    }

    public void setItemSprit(Item _item)
    {
        itemIcon_Image.sprite = _item.itemIcon;
    }

    
}
}

