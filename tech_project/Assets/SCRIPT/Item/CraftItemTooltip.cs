using DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MainInventory.ItemSlot;
using System.Reflection; // MethodInfo
using Item_Craft;


namespace Item_Tooltip
{
public class CraftItemTooltip : MonoBehaviour
{
    public static CraftItemTooltip instance;
    public DatabaseManager theDatabase;
    public Button[] Tooltip_Buttons;    
    public GameObject CraftTooltip_Panel;


    public static InventorySlot[] CraftSlot;
    public Transform Gird_Slot; 

    public Image Tooltip_Icon;
    public Text Tooltip_Name;
    public Text Tooltip_Description;
    public Button Craft_Button;
    public Button Back_Button;


    private string Clicked_ItemID;
    private Transform ChickedSlot;

    private Type type = typeof(ItemCraft);

    void Start()
    {
        instance = this;
        CraftSlot = Gird_Slot.GetComponentsInChildren<InventorySlot>();
        theDatabase = FindObjectOfType<DatabaseManager>();

        CraftTooltip_Panel.SetActive(false);


        for (int i = 0; i < Tooltip_Buttons.Length; i++)
        {
            Button button = Tooltip_Buttons[i];
            button.onClick.AddListener(() => ShowTooltip(button));
        }

        Craft_Button.onClick.AddListener(() => CraftButton(Clicked_ItemID));
        Back_Button.onClick.AddListener(BackButton);
    }

    public void ShowTooltip(Button clickedButton)
    {
        var itemIcon = clickedButton.GetComponentInParent<InventorySlot>().itemIcon_Image;
        if (itemIcon != null)
        {
            Clicked_ItemID = itemIcon.sprite.name;
            Debug.Log("Craft.--------클릭한 아이템 아이디 : " + Clicked_ItemID); 

            var item = theDatabase.itemList.Find(x => x.itemID == Clicked_ItemID);
            if (item != null)
            {
                Tooltip_Name.text = item.itemName;
                Tooltip_Description.text = item.itemDescription;
                Tooltip_Icon.sprite = item.itemIcon;
                CraftTooltip_Panel.SetActive(true);
            }
        }

        if(MaterItemTooltip.instance.MaterTooltip_Panel != null) // 재료아이템 튤팁이 켜져있으면 끄는 기능
        {
            MaterItemTooltip.instance.MaterTooltip_Panel.SetActive(false);
        }
    }

    public void CraftButton(String _itemID)
    {
        Debug.Log("clone 제거 전"+ _itemID);
        String itemID = _itemID.Substring(0, _itemID.Length - 7);
        Debug.Log("clone 제거 후"+itemID);

        ItemCraft itemRecipeInstance = new ItemCraft();
        //Debug.Log("craftType"+type);
        MethodInfo methodInfo = itemRecipeInstance.GetType().GetMethod(itemID); // "MethodName"을 해당 클래스의 메서드 이름으로 변경하세요
        if (methodInfo != null)
        {
            Debug.Log("---CraftItemTooltip_제작 시작---");
            Debug.Log(methodInfo.Name);
            object result = methodInfo.Invoke(itemRecipeInstance, null); // 첫 번째 매개변수는 메서드를 호출할 객체, 두 번째 매개변수는 메서드에 전달할 인수입니다. 정적 메서드를 호출하는 경우 첫 번째 매개변수는 null이 됩니다.
            CraftTableDAO.ShowMaterTab();
            if ((int)result == 1)
            {
                //StartCoroutine(CraftResultPanel.ShowCraftTruePanel());
                CraftResultPanel.instance.ShowCraftResultPanel(1);
                Debug.Log("_-_-_제작 성공_-_-_");
            }
            else if((int)result == 0)
            {
                //StartCoroutine(CraftResultPanel.ShowCraftFailPanel());
                CraftResultPanel.instance.ShowCraftResultPanel(0);
                Debug.Log("_-_-_제작 실패_-_-_");
            }
            else if((int)result == -1)
            {
                CraftResultPanel.instance.ShowCraftResultPanel(-1);
                Debug.Log("_-_-_이미 있음_-_-_");
            }
            else if((int)result == -2)
            {
                CraftResultPanel.instance.ShowCraftResultPanel(-2);
                Debug.Log("_-_-_하위 아이템 제작하지 않음_-_-_");
            }
            else if((int)result == -3)
            {
                CraftResultPanel.instance.ShowCraftResultPanel(-3);
                Debug.Log("_-_-_하위 아이템을 장착하지 않음_-_-_");
            }
            else
            {
                Debug.Log("ItemCraft.cs에 리턴값이 1,0,-1,-2,-3이 아님.");
            }
            Debug.Log("---CraftItemTooltip_제작 끝---");
            CraftTooltip_Panel.SetActive(false);
        }
        else
        {
            Debug.Log("ItemCraft.cs에 해당 이미지의 메서드가 없음.");
        }
        

    }


    public void BackButton()
    {
        CraftTooltip_Panel.SetActive(false);
    }
    

    

    
    // public void Type_if_use() //else여도 갯수 차감되고 실행은 됨 왜 그런지 모르겠음...
    // {
    //     ChickedSlot = null; 
    //     foreach (var slot in CraftSlot)
    //     {
    //         if(slot.itemIcon_Image.sprite.name == click_ItemID)
    //         {
    //             Debug.Log("슬롯이름 : " + slot.itemIcon_Image.sprite.name);
    //             Debug.Log("클릭한 아이템 이름 : " + click_ItemID);
    //             ChickedSlot = slot.transform;
    //             break;
    //         }
    //     }

    //     if (ChickedSlot == null)
    //     {
    //         Debug.Log("사용한 아이템이랑 슬롯 이미지가 일치하지 않음");
    //         return;
    //     }

    //     InventorySlot Slot_SC = ChickedSlot.GetComponent<InventorySlot>();
    //     if (int.TryParse(Slot_SC.itemCount_Text.text, out int count))
    //     {
    //         if (count == 1)
    //         {
    //             InventoryDAO.inventoryItemList.RemoveAll(x => x.itemID == Slot_SC.itemIcon_Image.sprite.name);
    //             Slot_SC.RemoveItem();
    //             Slot_SC.gameObject.SetActive(false);
    //         }
    //         else
    //         {
    //             count--;
    //             InventoryDAO.inventoryItemList.Find(x => x.itemID == Slot_SC.itemIcon_Image.sprite.name).itemCount = count;
    //             Slot_SC.itemCount_Text.text = count.ToString();
    //         }
    //     }
    //         // else 
    //         // {
    //         //     // Handle the case where slot.itemCount_Text.text is not a valid integer
    //         //     Debug.Log("Invalid itemCount_Text: " + slot.itemCount_Text.text);
    //         // }
        
    // }




}
}



