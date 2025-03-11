using DataBase;
using UnityEngine;
using UnityEngine.UI;
using MainInventory.ItemSlot;
using Item_Base;
using Item_QuickSlot;

namespace Item_Tooltip
{
public class ItemTooltip : MonoBehaviour
{
    public static ItemTooltip instance;
    public DatabaseManager theDatabase;
    public Button[] Tooltip_Buttons;    
    public GameObject Tooltip_Panel;

    public static InventorySlot[] inventorySlot;
    public Transform Gird_Slot; 

    public Image Tooltip_Icon;
    public Text Tooltip_Name;
    public Text Tooltip_Description;
    public Button Use_Button;
    public Button Back_Button;

    public Image OnGun_Iamge; //장착된 총 아이템 이미지
    public Image OnHat_Iamge; //장착된 모자 아이템 이미지
    public Image OnShirt_Iamge; //장착된 상의 아이템 이미지
    public Image OnPants_Iamge; //장착된 바지 아이템 이미지
    public bool isHat = false;
    public bool isShirt = false;
    public bool isPants = false;

    private Item.ItemType click_ItemType;
    private Item.UnderType click_UnderType;

    private string click_ItemID;
    private Transform ChickedSlot;

    public GameObject panel;        // 아이템 사용시 패널 활성화
    public Button Regist_Item1_btn; // 아이템 등록 버튼1
    public Button Regist_Item2_btn; // 아이템 등록 버튼2
    public ItemQuickSlot itemQuickSlot;



    void Start()
    {
        //Tooltip_Panel = GameObject.Find("Tooltip_UI");
        instance = this;
        inventorySlot = Gird_Slot.GetComponentsInChildren<InventorySlot>();
        theDatabase = FindObjectOfType<DatabaseManager>();
        Tooltip_Panel.SetActive(false);
        //Debug.Log("툴팁 비활성화");
        for (int i = 0; i < Tooltip_Buttons.Length; i++)
        {
            Button button = Tooltip_Buttons[i];
            button.onClick.AddListener(() => ShowTooltip(button));
        }
        Use_Button.onClick.AddListener(UseButton);
        Back_Button.onClick.AddListener(BackButton);

        Regist_Item1_btn.onClick.AddListener(() => RegistItemButton("1",Tooltip_Icon, inventorySlot));
        Regist_Item2_btn.onClick.AddListener(() => RegistItemButton("2",Tooltip_Icon, inventorySlot));
    }

    public void ShowTooltip(Button clickedButton)
    {
        var itemIcon = clickedButton.GetComponentInParent<InventorySlot>().itemIcon_Image;
        if (itemIcon != null)
        {
            click_ItemID = itemIcon.sprite.name;
            Debug.Log("0.--------클릭한 아이템 아이디 : " + click_ItemID); 

            var item = theDatabase.itemList.Find(x => x.itemID == click_ItemID);
            if (item != null)
            {
                Tooltip_Name.text = item.itemName;
                Tooltip_Description.text = item.itemDescription;
                Tooltip_Icon.sprite = item.itemIcon;
                Tooltip_Panel.SetActive(true);
                //Debug.Log("Tooltip Panel On");

                click_UnderType = item.underType;
                if(click_UnderType == Item.UnderType.ETC || click_UnderType == Item.UnderType.Quest)
                {
                    Use_Button.gameObject.SetActive(false);
                }
                else
                {
                    Use_Button.gameObject.SetActive(true);
                }
            }
        }
    }
    
    public void UseButton()  // 반복문을 제거하고 itemId를 사용
    {
        var item = theDatabase.itemList.Find(x => x.itemID == click_ItemID);
        if (item != null)
        {
            click_ItemType = item.itemType;
            if (click_ItemType == Item.ItemType.Use)
            {
                panel.gameObject.SetActive(true);
            }
            else if (click_ItemType == Item.ItemType.Equip)
            {
                // 장비 아이템 사용
                Type_if_equip();
                InventoryDAO.ShowInvenTab();
                Debug.Log("inventory refresh Equip");
                Tooltip_Panel.SetActive(false);
                //효과 적용
                //Debug.Log("ItemTooltip_장비 아이템 사용");
            }
        }    
    }

    public void BackButton() // 뒤로가기 버튼 (cancel)
    {
        Tooltip_Panel.SetActive(false);
        panel.gameObject.SetActive(false);
        //Debug.Log("Back Button Clicked");
    }


    #region ------------------퀵슬롯 등록 관련------------------------
    public void RegistItemButton(string buttonNumber, Image Tooltip_Icon, InventorySlot[] inventorySlot) // 아이템 슬롯(1,2) 등록 버튼
    {        
        itemQuickSlot.Regist_Item(buttonNumber, Tooltip_Icon, inventorySlot);
        panel.gameObject.SetActive(false);
        Tooltip_Panel.SetActive(false); 
    }
    #endregion 


    #region ------------------아이템 타입 확인 관련 코드------------------------
    public void Type_if_use(string ItemBtnID, int SlotNum) //else여도 갯수 차감되고 실행은 됨 왜 그런지 모르겠음...
    {
        ChickedSlot = null;
        InventoryDAO.ShowInvenTab();                       
        foreach (var slot in inventorySlot)
        {
            if(slot.itemIcon_Image.sprite.name == ItemBtnID)
            {
                Debug.Log("슬롯이름 : " + slot.itemIcon_Image.sprite.name);
                Debug.Log("클릭한 아이템 이름 : " + ItemBtnID);
                ChickedSlot = slot.transform;
                break;
            }
        }

        if (ChickedSlot == null)
        {
            Debug.Log("사용한 아이템이랑 슬롯 이미지가 일치하지 않음");
            return;
        }

        InventorySlot Slot_SC = ChickedSlot.GetComponent<InventorySlot>();
        if (int.TryParse(Slot_SC.itemCount_Text.text, out int count))
        {
            if (count == 1)
            {
                InventoryDAO.inventoryItemList.RemoveAll(x => x.itemID == Slot_SC.itemIcon_Image.sprite.name);
                Slot_SC.RemoveItem();
                Slot_SC.gameObject.SetActive(false);
                itemQuickSlot.SetIconFalse(SlotNum.ToString(), "use");  // 퀵슬롯 비활성화
            }
            else
            {
                count--;
                InventoryDAO.inventoryItemList.Find(x => x.itemID == Slot_SC.itemIcon_Image.sprite.name).itemCount = count;
                Slot_SC.itemCount_Text.text = count.ToString();
                itemQuickSlot.Set_Text(SlotNum.ToString(), count);   // 퀵슬롯 텍스트 업데이트
            }
            
        }
    }
    
    public void Type_if_equip()
    {
        ChickedSlot = null;
        foreach (var slot in inventorySlot)
        {
            if (slot.itemIcon_Image.sprite.name == click_ItemID)
            {
                ChickedSlot = slot.transform;
                Debug.Log("1.--------클릭한 아이템 찾기-------- : " + ChickedSlot.GetComponent<InventorySlot>().itemIcon_Image.sprite.name);
                break;
            }    
        }

        if (ChickedSlot == null) //없어도 되는 코드인데 혹시 몰라서 넣어둠
        {
            Debug.LogError("사용한 아이템이랑 슬롯 이미지가 일치하지 않음");
            return;
        }

        InventorySlot Slot_SC = ChickedSlot.GetComponent<InventorySlot>();
        var item = theDatabase.itemList.Find(x=> x.itemID == Slot_SC.itemIcon_Image.sprite.name);

        if(item.underType == Item.UnderType.Gun) //총 사용
        {
            UnderType_Is_Gun(Slot_SC, item);
            EquipItemEffect.instance.EquipItemEffectLogic(item.itemID);
        }

        if(item.underType == Item.UnderType.Hat) //모자 사용
        {
            UnderType_Is_Hat(Slot_SC, item);
            EquipItemEffect.instance.EquipItemEffectLogic(item.itemID);
        }

        if(item.underType == Item.UnderType.Shirt) //상의 사용
        {
            UnderType_Is_Shirt(Slot_SC, item);
            EquipItemEffect.instance.EquipItemEffectLogic(item.itemID);
        }

        if(item.underType == Item.UnderType.Pants) //바지 사용
        {
            UnderType_Is_Pants(Slot_SC, item);
            EquipItemEffect.instance.EquipItemEffectLogic(item.itemID);
        }
    }
    public void Type_if_quest(string ItemBtnID)
    {
        ChickedSlot = null;
        InventoryDAO.ShowInvenTab();                       
        foreach (var slot in inventorySlot)
        {
            if(slot.itemIcon_Image.sprite.name == ItemBtnID)
            {
                ChickedSlot = slot.transform;
                break;
            }
        }     
    }
    #endregion

    #region ------------------장비 아이템 언더타입 확인 관련 코드------------------------
    public void UnderType_Is_Gun(InventorySlot Slot_SC, Item item) //총 사용
    {
        var OnGunInfor = theDatabase.itemList.Find(x => x.itemID == OnGun_Iamge.sprite.name); //장착되어 있는 아이템
        InventoryDAO.inventoryItemList.Add(new Item(
            OnGunInfor.itemID,
            OnGunInfor.itemName,
            OnGunInfor.itemDescription,
            OnGunInfor.itemType,
            OnGunInfor.underType,
            1
        ));
        OnGun_Iamge.sprite = Slot_SC.itemIcon_Image.sprite;
        InventoryDAO.inventoryItemList.RemoveAll(x => x.itemID == item.itemID);
    }

    public void UnderType_Is_Hat(InventorySlot Slot_SC, Item item) //모자 사용
    {
        if (isHat == false)
        {
            isHat = true;
            OnHat_Iamge.sprite = Slot_SC.itemIcon_Image.sprite;
            InventoryDAO.inventoryItemList.RemoveAll(x => x.itemID == item.itemID);
            Slot_SC.RemoveItem();
            Slot_SC.gameObject.SetActive(false);
        }
        else
        {
            var OnHatInfor = theDatabase.itemList.Find(x => x.itemID == OnHat_Iamge.sprite.name);
            InventoryDAO.inventoryItemList.Add(new Item(
                OnHatInfor.itemID,
                OnHatInfor.itemName,
                OnHatInfor.itemDescription,
                OnHatInfor.itemType,
                OnHatInfor.underType,
                1
            ));
            OnHat_Iamge.sprite = Slot_SC.itemIcon_Image.sprite;
            InventoryDAO.inventoryItemList.RemoveAll(x => x.itemID == item.itemID);
        }
    }

    public void UnderType_Is_Shirt(InventorySlot Slot_SC, Item item) //상의 사용
    {
        if (isShirt == false)
        {
            isShirt = true;
            OnShirt_Iamge.sprite = Slot_SC.itemIcon_Image.sprite;
            InventoryDAO.inventoryItemList.RemoveAll(x => x.itemID == item.itemID);
            Slot_SC.RemoveItem();
            Slot_SC.gameObject.SetActive(false);
        }
        else
        {
            var OnShirtInfor = theDatabase.itemList.Find(x => x.itemID == OnShirt_Iamge.sprite.name); 
            InventoryDAO.inventoryItemList.Add(new Item(
                OnShirtInfor.itemID,
                OnShirtInfor.itemName,
                OnShirtInfor.itemDescription,
                OnShirtInfor.itemType,
                OnShirtInfor.underType,
                1
            ));
            OnShirt_Iamge.sprite = Slot_SC.itemIcon_Image.sprite;
            InventoryDAO.inventoryItemList.RemoveAll(x => x.itemID == item.itemID);
        }
    }

    public void UnderType_Is_Pants(InventorySlot Slot_SC, Item item) //바지 사용
    {
        if (isPants == false)
        {
            isPants = true;
            OnPants_Iamge.sprite = Slot_SC.itemIcon_Image.sprite;
            InventoryDAO.inventoryItemList.RemoveAll(x => x.itemID == item.itemID);
            Slot_SC.RemoveItem();
            Slot_SC.gameObject.SetActive(false);
        }
        else
        {
            var OnPantsInfor = theDatabase.itemList.Find(x => x.itemID == OnPants_Iamge.sprite.name); 
            InventoryDAO.inventoryItemList.Add(new Item(
                OnPantsInfor.itemID,
                OnPantsInfor.itemName,
                OnPantsInfor.itemDescription,
                OnPantsInfor.itemType,
                OnPantsInfor.underType,
                1
            ));
            OnPants_Iamge.sprite = Slot_SC.itemIcon_Image.sprite;
            InventoryDAO.inventoryItemList.RemoveAll(x => x.itemID == item.itemID);
        }
    }
    #endregion


    /*public void Type_if_use() //else여도 갯수 차감되고 실행은 됨 왜 그런지 모르겠음...
    {
        ChickedSlot = null; 
        foreach (var slot in inventorySlot)
        {
            if(slot.itemIcon_Image.sprite.name == click_ItemID)
            {
                Debug.Log("슬롯이름 : " + slot.itemIcon_Image.sprite.name);
                Debug.Log("클릭한 아이템 이름 : " + click_ItemID);
                ChickedSlot = slot.transform;
                break;
            }
        }

        if (ChickedSlot == null)
        {
            Debug.Log("사용한 아이템이랑 슬롯 이미지가 일치하지 않음");
            return;
        }

        InventorySlot Slot_SC = ChickedSlot.GetComponent<InventorySlot>();
        if (int.TryParse(Slot_SC.itemCount_Text.text, out int count))
        {
            if (count == 1)
            {
                InventoryDAO.inventoryItemList.RemoveAll(x => x.itemID == Slot_SC.itemIcon_Image.sprite.name);
                Slot_SC.RemoveItem();
                Slot_SC.gameObject.SetActive(false);
            }
            else
            {
                count--;
                InventoryDAO.inventoryItemList.Find(x => x.itemID == Slot_SC.itemIcon_Image.sprite.name).itemCount = count;
                Slot_SC.itemCount_Text.text = count.ToString();
            }
        }
            // else 
            // {
            //     // Handle the case where slot.itemCount_Text.text is not a valid integer
            //     Debug.Log("Invalid itemCount_Text: " + slot.itemCount_Text.text);
            // }
        
    }*/


}
}



