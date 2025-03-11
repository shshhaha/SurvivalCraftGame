using Item_Base;
using MainInventory.ItemSlot;
using UnityEngine;
using UnityEngine.UI;
using DataBase;
using System.Collections.Generic;
using System.Linq;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    [SerializeField]
    private int UseItemPrice = 30; // 소비 아이템 판매 가격
    [SerializeField]
    private int CraftItemPrice = 100; // 재료 아이템 판매 가격

    public Transform Shop_Slot; // '판매'아이템 slot의 부모객체
    public InventorySlot[] S_slots; // 각각의 판매 아이템 슬롯들

    public List<Item> ShopAllItemList; // 판매할 수 있는 아이템 리스트 (여기서 랜덤으로 아이템을 뽑아서 판매)
    public DatabaseManager theDatabase;

    public Text[] PriceText;

    void Awake()
    {
        instance = this;
        S_slots = Shop_Slot.GetComponentsInChildren<InventorySlot>();
        ShopAllItemList = new List<Item>();
        addItem();
    }
    
    void Start()
    {
        AddRandomItemsToSlots();
    }


    public void addItem()
    {
        foreach (var item in theDatabase.itemList)
        {
            if (item.itemType == Item.ItemType.Use || item.itemType == Item.ItemType.Craft)
            {
                ShopAllItemList.Add(item);
            }
            
        }
    }

    public void AddRandomItemsToSlots()
    {
        System.Random rand = new System.Random();

        // Use 타입 아이템 6개 랜덤 선택
        var useItems = ShopAllItemList
            .Where(item => item.itemType == Item.ItemType.Use && item.underType == Item.UnderType.Null)
            .OrderBy(item => rand.Next())
            .Take(6)
            .ToList();

        // Craft 타입 아이템 3개 랜덤 선택
        var craftItems = ShopAllItemList
            .Where(item => item.itemType == Item.ItemType.Craft)
            .OrderBy(item => rand.Next())
            .Take(3)
            .ToList();

        // 선택된 아이템을 S_slots에 할당
        for (int i = 0; i < useItems.Count; i++)
        {
            PriceText[i].text = UseItemPrice.ToString();
            S_slots[i].AddItem(useItems[i]);
            S_slots[i].itemCount_Text.text = "8";
        }

        for (int i = 0; i < craftItems.Count; i++)
        {
            PriceText[i + useItems.Count].text = CraftItemPrice.ToString();
            S_slots[i + useItems.Count].AddItem(craftItems[i]);
            S_slots[i + useItems.Count].itemCount_Text.text = "3";
        }
    }

    public void OffBuyButton(int _index)
    {
        Image selectedItemImage = S_slots[_index].selected_Item.GetComponent<Image>();
        Color color = selectedItemImage.color;
        color.a = 190 / 255f;
        selectedItemImage.color = color;
    }

}
