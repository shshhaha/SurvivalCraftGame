using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item_Base;
using System;

namespace DataBase
{

public class DatabaseManager : MonoBehaviour
{

    //싱글톤
    static public DatabaseManager instance;
    private void Awake() 
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        } 
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        // return 해야지 오류 안남 -성호
    }

    // 1. 씬이동 A (이벤트발생 중복으로 됨)<-> B 이동
    // A에서 B로 이동하면 A에서 발생한 이벤트가 파괴되는데 B에서 다시 A로 이동하면 또 작동 T,F 조건문 사용해도 똑같음
    // 2. save와 load
    // 3. 미리 아이템을 만듬

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();

    void Start()
    {
        //itemList.Add(new Item("400001","test", "testGun401",Item.ItemType.Use, Item.UnderType.Null));
        //itemList.Add(new Item("400002", "test", "test", Item.ItemType.Quest, Item.UnderType.Null));
        //itemList.Add(new Item("100001", "apple", "testGun101", Item.ItemType.Equip, Item.UnderType.Gun));
        //itemList.Add(new Item("pear", "pear", "test", Item.ItemType.Use, Item.UnderType.Null));
        // itemList.Add(new Item_Equip("400001","test", "testGun401",Item.ItemType.Equip, Item.UnderType.Gun, ));
        // itemList.Add(new Item_Equip("400002", "test", "test", Item.ItemType.Quest, Item.UnderType.Null));
        // itemList.Add(new Item_Equip("100001", "apple", "testGun101", Item.ItemType.Equip, Item.UnderType.Gun));
        //itemList.Add(new Item_Equip(1, 1, 1, new List<string> {"orange", "orange", "orange"}, "pear", "pear", "test", Item.ItemType.Use, Item.UnderType.Null));

    }
    public (string name, string description, Sprite icon) GetItemInfo(String id)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemID == id)
            {
                return (itemList[i].itemName, itemList[i].itemDescription, itemList[i].itemIcon);
            }
        }
        return ("", "", null);
    }

}

}

