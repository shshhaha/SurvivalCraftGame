using Item_Base;
using MainInventory.ItemSlot;
using UnityEngine;
using UnityEngine.UI;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using Item_Tooltip;
using DTO.PlayerDTO;

namespace GameEnd
{
    public class Escape : MonoBehaviour
    {
        public static Escape instance;
        private ItemTooltip tooltip;
        private PlayerDTO pdto;

        [SerializeField]
        private GameEnd_Clear gameEnd_Clear;    // 게임 클리어 관리 스크립트

        [SerializeField]
        private int ItemNeed = 1;        // 실제 확인용 필요한 아이템 갯수
        public Text[] NeedText;         // 필요한 아이템 갯수 텍스트
        private int[] NeedItem = {100, 10, 3};      // 필요한 아이템 개수 텍스트 설정용 배열
        private int[] CurrentItem = new int[3];      // 현재 아이템 갯수 

        private int add_ItemCount;      // 탈출 아이템 추가 갯수

        public Transform Escape_Slot;
        public InventorySlot[] E_slots;
        public DatabaseManager theDatabase;
    
        public Button[] Equip_Button;  // 장착 버튼

        public List<Item> EscapeAllItemList;

        void Awake()
        {
            instance = this;
            E_slots = Escape_Slot.GetComponentsInChildren<InventorySlot>();
            addItem();
            pdto = PlayerDTO.Instance;
            Equip_Button[0].onClick.AddListener(Equip_ButtonClick0);
            Equip_Button[1].onClick.AddListener(Equip_ButtonClick1);
        }

        void Start()
        {
            SetEscapeItemsToSlots();
        }


        public void addItem()
        {
            foreach (var item in theDatabase.itemList)
            {
                if (item.itemType == Item.ItemType.Use)
                {
                    EscapeAllItemList.Add(item);
                }
                
            }
        }

        public void SetEscapeItemsToSlots()
        {
            var useItems = EscapeAllItemList
                .TakeLast(E_slots.Length)
                .ToList();
            for (int i = 0; i < E_slots.Length; i++)
            {
                CurrentItem[i] = 0;
                NeedText[i].text = CurrentItem[i] + " / " + NeedItem[i].ToString();
                E_slots[i].setItemSprit(useItems[i]);
                Debug.Log(i+" 탈출재료 "+useItems[i].itemName);
            }
        }

        public void EscapeItemUpdate(string itemId, int add_ItemCount) // 탈출 아이템 인벤토리에 추가
        {
            var item = theDatabase.itemList.Find(x => x.itemID == itemId);
            InventoryDAO.instance.GetInvenItem(item.itemID, add_ItemCount);
        }

        public void Equip_ButtonClick0()
        {
            Equip_Check();
        }

        public void Equip_ButtonClick1()
        {
            if (tooltip == null)
            {
                tooltip = ItemTooltip.instance;
            }
            SetCurrentItem();
        }

        public void Equip_Check()
        {
            bool allItemsSatisfyCondition = true; // 개수 조건을 모두 만족하는지 여부

            for (int i = 0; i < E_slots.Length; i++)
                {
                    if (CurrentItem[i] < ItemNeed)
                    {
                        allItemsSatisfyCondition = false;
                        break;
                    }
                }

            if (allItemsSatisfyCondition)
            {
                gameEnd_Clear.GameEndClear();
            }
        }

        public void SetCurrentItem()                // 각 조건이 맞아야 탈출 아이템을 장착 할수 있음 현재는 일반몹 1마리로 통일함 몹 추가 시 수정
        {
            if(pdto.getMobCount() >= 1)
            {
                tooltip.Type_if_quest("quest(Clone)");      
                CurrentItem[0] = 100;
                NeedText[0].text = CurrentItem[0] + " / " + (100).ToString();
            }
            if(pdto.getMiddleCount() >= 1)
            {
                tooltip.Type_if_quest("quest2(Clone)");
                CurrentItem[1] = 10;
                NeedText[1].text = CurrentItem[1] + " / " + (10).ToString();
            }
            if(pdto.getBossCount() >= 1)
            {
                tooltip.Type_if_quest("quest3(Clone)");
                CurrentItem[2] = 3;
                NeedText[2].text = CurrentItem[2] + " / " + (3).ToString();
            }
        }
    }
}
