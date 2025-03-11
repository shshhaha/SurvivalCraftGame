using UnityEngine;
using UnityEngine.UI;
using MainInventory.ItemSlot;


namespace MainInventory
{

public class Inventory : InventoryDAO
{
    public Button Equip_Button;
    public Button Use_Button;

    public Transform I_Gird_Slot; // slot의 부모객체
    public GameObject[] selectedTabImages; // 선택된 탭 이미지

    private WaitForSeconds waitTime = new WaitForSeconds(0.03f);


    // Start is called before the first frame update
    void Start()
    {
        I_slots = I_Gird_Slot.GetComponentsInChildren<InventorySlot>(); // Grid Slot에 있는 것들이 다 slost에 들어감
        Equip_Button.onClick.AddListener(() => { selectedTab = 0; ShowInvenTab(); });
        Use_Button.onClick.AddListener(() => { selectedTab = 1; ShowInvenTab(); });
        RemoveInvenSlot();
        InventoryDAO.instance.GetInvenItem("Pump(Clone)",1);
        InventoryDAO.instance.GetInvenItem("Hat1(Clone)",1);
        InventoryDAO.instance.GetInvenItem("Shirt1(Clone)",1);
        InventoryDAO.instance.GetInvenItem("Pants1(Clone)",1);
    }

    

}

}

