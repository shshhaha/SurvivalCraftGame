using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item_Base
{
[System.Serializable]
public class Item
{

    [Tooltip("아이템 고유 아이디")]
    public string itemID; //아이템 고유 아이디 (중복X)
    [Tooltip("아이템 이름")]
    public string itemName; //아이템 이름
    [Tooltip("아이템 설명")]
    public string itemDescription; //아이템 설명 (이건 튤팁으로 빼야됨)
    [Tooltip("아이템 수량")]
    public int itemCount; //아이템 수
    [Tooltip("아이템 아이콘")]
    public Sprite itemIcon; // 아이템 아이콘
    public ItemType itemType; //

    public UnderType underType; //아이템 종류

    public enum ItemType{ //아이템 종류 이거 수정

        Use, // 소비, 수류탄 등,
        Equip, //장비, 무기
        Craft, // 제작 재료
        Quest, // 게임끝나고 나오는 아이템
        ETC
    }

    public enum UnderType{ //아이템 종류 이거 수정

        Null, //기본
        Gun, //총
        Hat, //모자
        Shirt, //상의
        Pants, //하의
        Quest, // 좀비 시료 아이템

        ETC
    }

    public Item(string _itemID, string _itemName, string _itemDes, ItemType _itemType, UnderType _underType,int _itemCount =1){

        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        underType = _underType;
        itemCount = _itemCount;
        itemIcon = LoadItemIcon(_itemID);

    }

    private Sprite LoadItemIcon(string _itemID)
    {
        string path = "ItemIcon/" + _itemID.ToString();
        return Resources.Load<Sprite>(path);
    }

    



}
}

