using UnityEngine;
using DataBase;
using UnityEngine.UI;
using MainInventory.ItemSlot;
using Item_Tooltip;

public class MaterItemTooltip : MonoBehaviour
{
    public static MaterItemTooltip instance;
    public DatabaseManager theDatabase;
    public Button[] Tooltip_Buttons;    
    public GameObject MaterTooltip_Panel;

    public static InventorySlot[] MaterSlot;
    public Transform Gird_Slot; 

    public Image Tooltip_Icon;
    public Text Tooltip_Name;
    public Text Tooltip_Description;
    public Button Back_Button;

    private string click_ItemID;


    void Start()
    {
        instance = this;
        theDatabase = FindObjectOfType<DatabaseManager>();
        MaterSlot = Gird_Slot.GetComponentsInChildren<InventorySlot>();
        MaterTooltip_Panel.SetActive(false);

        for (int i = 0; i < Tooltip_Buttons.Length; i++)
        {
            Button button = Tooltip_Buttons[i];
            button.onClick.AddListener(() => ShowTooltip(button));
            //int index = i;
            //Tooltip_Buttons[index].onClick.AddListener(() => GetCraftItem(index));
        }

        Back_Button.onClick.AddListener(BackButton);
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
                MaterTooltip_Panel.SetActive(true);
                //Debug.Log("Tooltip Panel On");
            }
        }

        if(CraftItemTooltip.instance.CraftTooltip_Panel != null) // 제작 아이템 튤팁이 켜져있으면 끄는 기능
        {
            CraftItemTooltip.instance.CraftTooltip_Panel.SetActive(false);
        }
    }

    public void BackButton()
    {
        MaterTooltip_Panel.SetActive(false);
        //Debug.Log("Back Button Clicked");
    }


}
