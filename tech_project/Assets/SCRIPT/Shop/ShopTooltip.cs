using UnityEngine;
using DataBase;
using UnityEngine.UI;
using MainInventory.ItemSlot;
using DTO.MoneyDTO;
using Item_Base;
using System;
using System.Collections;
using Item_QuickSlot;

public class ShopTooltip : MonoBehaviour
{
    public static ShopTooltip instance;
    public DatabaseManager theDatabase;
    public Button[] Tooltip_Buttons;    
    public GameObject ShopTooltip_Panel;

    public static InventorySlot[] ShopSlot;
    public Transform Gird_Slot; 

    public Image Tooltip_Icon;
    public Text Tooltip_Name;
    public Text Tooltip_Description;
    public Button Buy_Button;
    public Button Back_Button;

    public Text Result_Text;

    private MoneyDTO moneyDTO;
    private Button clickedButton;
    private string click_ItemID;
    private float click_ItemPrice;
    private int add_ItemCount;
    private int buttonIndex;
    private int textCon;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        moneyDTO = MoneyDTO.Instance;
        ShopTooltip_Panel.SetActive(false);
        ShopSlot = Gird_Slot.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < Tooltip_Buttons.Length; i++)
        {
            Button button = Tooltip_Buttons[i];
            button.onClick.RemoveAllListeners(); // 기존 클릭 이벤트 리스너를 제거합니다.
            button.onClick.AddListener(() => ShowTooltip(button));
        }

        Buy_Button.onClick.RemoveAllListeners(); // 기존 클릭 이벤트 리스너를 제거합니다.
        Buy_Button.onClick.AddListener(BuyButton);
        Back_Button.onClick.RemoveAllListeners(); // 기존 클릭 이벤트 리스너를 제거합니다.
        Back_Button.onClick.AddListener(BackButton);
    }

    public void ShowTooltip(Button clickedButton)
    {
        this.clickedButton = clickedButton;
        click_ItemID = clickedButton.GetComponentInParent<InventorySlot>().itemIcon_Image.sprite.name;

        buttonIndex = Array.IndexOf(Tooltip_Buttons, clickedButton);

        if (click_ItemID != null)
        {
            var item = theDatabase.itemList.Find(x => x.itemID == click_ItemID);
            if (item != null)
            {
                Tooltip_Name.text = item.itemName;
                Tooltip_Description.text = item.itemDescription;
                Tooltip_Icon.sprite = item.itemIcon;
                ShopTooltip_Panel.SetActive(true);
            }
        }
    }

    public void BackButton()
    {
        ShopTooltip_Panel.SetActive(false);
    }

    public void BuyButton()
    {
        var item = theDatabase.itemList.Find(x => x.itemID == click_ItemID); // 클릭한 아이템의 정보를 가져옴

        if (item.itemType == Item.ItemType.Use) // 클릭한 아이템이 Use 타입일 경우
        {
            click_ItemPrice = 30;
            add_ItemCount = 8;

            ProcessPurchase(item, add_ItemCount);
        }

        else if (item.itemType == Item.ItemType.Craft) // 클릭한 아이템이 Craft 타입일 경우
        {
            click_ItemPrice = 100;
            add_ItemCount = 3;

            ProcessPurchase(item, add_ItemCount);
        }
    }

    private void ProcessPurchase(Item item, int add_ItemCount)
    {
        string text = "";
        textCon = 0;

        if (item.itemType == Item.ItemType.Use)
        {
            text = "구매 성공!" + "\n" + "인벤토리를 확인해 주세요.";
        }
        else if (item.itemType == Item.ItemType.Craft)
        {
            text = "구매 성공!" + "\n" + "제작대를 확인해 주세요.";
        }

        if(moneyDTO.getMoney() >= click_ItemPrice)
        {
            moneyDTO.setMoney(moneyDTO.getMoney() - click_ItemPrice); // 돈 차감
            Result_Text.text = text;
            StartCoroutine(WaitTwoSeconds());
            //InventoryDAO.instance.GetInvenItem(item.itemID, add_ItemCount); // 아이템 추가
            OkayPurchase(item, add_ItemCount); // 원래는 위에 코드 사용해야되는데 저 코드사용하면 아이템구매하면 1개 추가됨 add_ItemCount로 추가해야함이 인식을 못하는것같음 근데 아래에 퀵슬롯 업뎃은 먹힘
            clickedButton.interactable = false; // 구매한 아이템 버튼 비활성화
            Shop.instance.OffBuyButton(buttonIndex); // 구매한 아이템 버튼 비활성화
            ItemQuickSlot.instance.textUpdate(item.itemID, add_ItemCount); // 퀵슬롯 텍스트 업데이트
            //Debug.Log("상점에서 아이템 구매후 퀵슬롯 업뎃" + add_ItemCount + "개 추가함");
            ShopTooltip_Panel.SetActive(false); // 툴팁창 닫기
            textCon = 1;
        }
        else if (moneyDTO.getMoney() < click_ItemPrice && textCon == 0)
        {
            ShopTooltip_Panel.SetActive(false);
            Result_Text.text = "구매 실패!" + "\n" + "소지금을 확인해 주세요.";
            StartCoroutine(WaitTwoSeconds());
        }
    }

    public void OkayPurchase(Item item, int add_ItemCount)
    {
        for (int i=0; i<add_ItemCount; i++)
        {
            InventoryDAO.instance.GetInvenItem(item.itemID, 1);
        }
    }


    IEnumerator WaitTwoSeconds()
    {
        yield return new WaitForSeconds(2f);
        Result_Text.text = " ";
    }


}
