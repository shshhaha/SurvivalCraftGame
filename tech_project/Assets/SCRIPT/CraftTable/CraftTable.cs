using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item_Base;
using DataBase;
using MainInventory.ItemSlot;
using UnityEngine.UI;

public class CraftTable : CraftTableDAO
{
    public Transform M_Gird_Slot; // '재료'아이템 slot의 부모객체
    public Transform C_Gird_Slot; // '제작'아이템 slot의 부모객체

    public Button PageUP_Button;
    public Button PageDown_Button;
    public Text Page_Text;


    void Awake()
    {
        M_slots = M_Gird_Slot.GetComponentsInChildren<InventorySlot>();
        C_slots = C_Gird_Slot.GetComponentsInChildren<InventorySlot>();
    }

    void Start()
    {
        craftTab = 0;
        PageUP_Button.onClick.AddListener(PageUP);
        PageDown_Button.onClick.AddListener(PageDown);

        #region 재료아이템 슬롯 초기화
        //첫번째 무기-------------------------------------------------------------------------------------
        CraftItemList.Add(new Item("Uzi(Clone)","Uzi", "재료아이템으로는 A,C,F가 필요합니다",
        Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item("AK(Clone)","AK", "재료아이템으로는 A,C,F가 필요합니다",
        Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add(new Item("M4(Clone)","M4", "재료아이템으로는 A,C,F가 필요합니다",
        Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item("Double(Clone)","Double", "재료아이템으로는 A,C,F가 필요합니다",
        Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item("Pump(Clone)","Pump", "재료아이템으로는 A,C,F가 필요합니다",
        Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item("M249(Clone)","M249", "재료아이템으로는 A,C,F가 필요합니다",
        Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item("RPG(Clone)","RPG", "재료아이템으로는 A,C,F가 필요합니다",
        Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Gun));
        

        //두번째 무기-------------------------------------------------------------------------------------
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add(new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add(new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Gun));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Gun));

        //세번째 모자-------------------------------------------------------------------------------------
        CraftItemList.Add( new Item("Hat1(Clone)","스쿠터 헬멧", " ", Item.ItemType.Equip,Item.UnderType.Hat));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Hat));
        CraftItemList.Add( new Item("Hat2(Clone)","오토바이 헬멧", " ", Item.ItemType.Equip,Item.UnderType.Hat));
        CraftItemList.Add(new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Hat));
        CraftItemList.Add( new Item("Hat3(Clone)","군용 경량화 헬멧", " ", Item.ItemType.Equip,Item.UnderType.Hat));
        CraftItemList.Add(new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Hat));
        CraftItemList.Add( new Item("Hat4(Clone)","군용 헬멧", " ", Item.ItemType.Equip,Item.UnderType.Hat));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Hat));

        //네번째 상의-------------------------------------------------------------------------------------
        CraftItemList.Add( new Item("Shirt1(Clone)"," ", " ", Item.ItemType.Equip,Item.UnderType.Shirt));
        CraftItemList.Add(new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Shirt));
        CraftItemList.Add( new Item("Shirt2(Clone)"," ", " ", Item.ItemType.Equip,Item.UnderType.Shirt));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Shirt));
        CraftItemList.Add( new Item("Shirt3(Clone)"," ", " ", Item.ItemType.Equip,Item.UnderType.Shirt));
        CraftItemList.Add(new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Shirt));
        CraftItemList.Add( new Item("Shirt4(Clone)"," ", " ", Item.ItemType.Equip,Item.UnderType.Shirt));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Shirt));

        //다섯번째 하의-------------------------------------------------------------------------------------
        CraftItemList.Add( new Item("Pants1(Clone)"," ", " ", Item.ItemType.Equip,Item.UnderType.Pants));
        CraftItemList.Add(new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Pants));
        CraftItemList.Add( new Item("Pants2(Clone)"," ", " ", Item.ItemType.Equip,Item.UnderType.Pants));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Pants));
        CraftItemList.Add( new Item("Pants3(Clone)"," ", " ", Item.ItemType.Equip,Item.UnderType.Pants));
        CraftItemList.Add(new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Pants));
        CraftItemList.Add( new Item("Pants4(Clone)"," ", " ", Item.ItemType.Equip,Item.UnderType.Pants));
        CraftItemList.Add( new Item(" "," ", " ", Item.ItemType.Equip,Item.UnderType.Pants));

        Debug.Log("제작아이템 리스트 추가 완료");
        #endregion  
    }

    public void PageUP()
    {
        if(craftTab == 4)
        {
            Debug.Log("마지막 탭입니다.");
            ShowCraftTab();
            TextUpdate();
        }
        else
        {
            Debug.Log("다음 탭으로 이동합니다.");
            craftTab++;
            ShowCraftTab();
            TextUpdate();
        }
    }
    public void PageDown()
    {
        if(craftTab == 0)
        {
            Debug.Log("첫번째 탭입니다.");
            ShowCraftTab();
            TextUpdate();
        }
        else
        {
            Debug.Log("이전 탭으로 이동합니다.");
            craftTab--;
            ShowCraftTab();
            TextUpdate();
        }
    }

    public void TextUpdate()
    {
        if(craftTab <= 1)
        {
            Page_Text.text = "무기";
        }
        else if(craftTab == 2)
        {
            Page_Text.text = "모자";
        }
        else if(craftTab == 3)
        {
            Page_Text.text = "상의";
        }
        else if(craftTab >= 4)
        {
            Page_Text.text = "하의";
        }
    }

    

}
