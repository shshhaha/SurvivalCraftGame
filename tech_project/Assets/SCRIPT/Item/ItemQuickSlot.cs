using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MainInventory.ItemSlot;

using TMPro; // TextMeshPro

namespace Item_QuickSlot{
public class ItemQuickSlot : MonoBehaviour
    {
        private Transform ChickedSlot;

        // 퀵슬롯 등록 관련
        public Image Item_btn_Icon1; // 버튼 이미지 교체1
        public Image Item_btn_Icon2; // 버튼 이미지 교체2
        
        public Button Regist_Item_btn1; // 아이템 등록 버튼1
        public Button Regist_Item_btn2; // 아이템 등록 버튼2

        public Image Regist_Item_Icon1; // 아이템 등록 이미지1
        public Image Regist_Item_Icon2; // 아이템 등록 이미지2


        public Button QuickSlotBtn1; // 퀵슬롯 버튼1
        public Button QuickSlotBtn2; // 퀵슬롯 버튼2

        public TextMeshProUGUI QuickSlotText1; // 퀵슬롯 텍스트1
        public TextMeshProUGUI QuickSlotText2; // 퀵슬롯 텍스트2


        public static ItemQuickSlot instance { get; private set; }    // 텍스트 업데이트 인스턴스

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #region------------------퀵슬롯 등록 관련-------------------------
        public void Regist_Item(string buttonNumber, Image Tooltip_Icon, InventorySlot[] inventorySlot) // 아이템 등록 및 해제
        {
            Button QuickButton = buttonNumber == "1" ? QuickSlotBtn1 : QuickSlotBtn2;
            Image itemButtonIcon = buttonNumber == "1" ? Item_btn_Icon1 : Item_btn_Icon2;
            Image InvenButtonIcon = buttonNumber == "1" ? Regist_Item_Icon1 : Regist_Item_Icon2;

            if(itemButtonIcon.sprite == Tooltip_Icon.sprite) 
            {
                bool isActive = itemButtonIcon.gameObject.activeSelf;
                itemButtonIcon.gameObject.SetActive(!isActive);
                QuickButton.interactable = !isActive;

                if(isActive) 
                {
                    TextMeshProUGUI selectedText = buttonNumber == "1" ? QuickSlotText1 : QuickSlotText2;
                    Image selectedIconInven = buttonNumber == "1" ? Regist_Item_Icon1 : Regist_Item_Icon2;
                    selectedText.gameObject.SetActive(false);
                    selectedIconInven.gameObject.SetActive(false); 
                    Debug.Log("같은 아이템을 발견하여 해제함!");
                    duplicationIconFalse(buttonNumber);
                } 
                else 
                {
                    SetRegistText(itemButtonIcon.sprite.name, buttonNumber, inventorySlot);
                    duplicationIconTrue(buttonNumber);
                    if(Item_btn_Icon1.sprite == Item_btn_Icon2.sprite)
                    {
                        SetIconFalse(buttonNumber, "swap");
                    }
                    Debug.Log("같은 아이템 발견하여 이미지 활성화!");
                }
                
            }   
            else                                                // 아이템 등록 하는곳 (주 기능)
            {
                checkedSwap(buttonNumber, Tooltip_Icon);
                itemButtonIcon.sprite = Tooltip_Icon.sprite;
                InvenButtonIcon.sprite = Tooltip_Icon.sprite;
                SetRegistText(itemButtonIcon.sprite.name, buttonNumber, inventorySlot);  
                itemButtonIcon.gameObject.SetActive(true);
                InvenButtonIcon.gameObject.SetActive(true);       
                QuickButton.interactable = true;      
                Debug.Log(buttonNumber + "번째 칸에 등록됨!");
            }
        }
        public void checkedSwap(string buttonNumber, Image Tooltip_Icon)         // 스왑 여부 확인
        {
            bool isActive1 = Item_btn_Icon1.gameObject.activeSelf;
            bool isActive2 = Item_btn_Icon2.gameObject.activeSelf;
            Image itemButtonIcon = buttonNumber == "1" ? Item_btn_Icon2 : Item_btn_Icon1;

            if(isActive1 == true && isActive2 == true)
            {
                SwapSlot();
                Debug.Log("퀵슬롯 스왑 실행");
            }
            else if(isActive1 || isActive2)
            {
                if(Tooltip_Icon.sprite == itemButtonIcon.sprite) 
                {    
                SetIconFalse(buttonNumber, "swap");
                Debug.Log($"두 슬롯 같은 아이템 감지 {buttonNumber} 슬롯만 활성화");
                }
            }
        }
        
        #endregion 

        #region------------------오브젝트 활성화/비활성화 관련-------------

        private void SelectElements(string buttonNumber, string check, out Button selectedButton, out Image selectedIcon, out Image selectedIconInven, out TextMeshProUGUI selectedText)
        {
            bool isSwap = check == "swap";
            selectedButton = buttonNumber == "1" ? (isSwap ? QuickSlotBtn2 : QuickSlotBtn1) : (isSwap ? QuickSlotBtn1 : QuickSlotBtn2);
            selectedIcon = buttonNumber == "1" ? (isSwap ? Item_btn_Icon2 : Item_btn_Icon1) : (isSwap ? Item_btn_Icon1 : Item_btn_Icon2);
            selectedIconInven = buttonNumber == "1" ? (isSwap ? Regist_Item_Icon2 : Regist_Item_Icon1) : (isSwap ? Regist_Item_Icon1 : Regist_Item_Icon2);
            selectedText = buttonNumber == "1" ? (isSwap ? QuickSlotText2 : QuickSlotText1) : (isSwap ? QuickSlotText1 : QuickSlotText2);
        }

        public void SetIconFalse(string buttonNumber, string check) // 아이템 슬롯 비활성화
        {
            SelectElements(buttonNumber, check, out Button selectedButton, out Image selectedIcon, out Image selectedIconInven, out TextMeshProUGUI selectedText);
            selectedIcon.gameObject.SetActive(false);
            selectedIconInven.gameObject.SetActive(false);
            selectedButton.interactable = false;
            selectedText.gameObject.SetActive(false);

            Debug.Log(buttonNumber + "번 아이템 슬롯 비활성화");
        }
        
        public void SetIconTrue(string buttonNumber) // 아이템 슬롯 활성화
        {
            SelectElements(buttonNumber, "!swap", out Button selectedButton, out Image selectedIcon, out Image selectedIconInven, out TextMeshProUGUI selectedText);
            selectedIcon.gameObject.SetActive(true);
            selectedIconInven.gameObject.SetActive(true);
            selectedButton.interactable = true;
            selectedText.gameObject.SetActive(true);

            Debug.Log(buttonNumber + "번 아이템 슬롯 비활성화");
        }


        public void SwapSlot()       // 슬롯 스왑
        {
            Sprite tempSpriteQuick = Item_btn_Icon1.sprite;
            Sprite tempSpriteRegist = Regist_Item_Icon1.sprite;
            string tempText = QuickSlotText1.text; // 텍스트 값을 저장

            Item_btn_Icon1.sprite = Item_btn_Icon2.sprite;
            Item_btn_Icon2.sprite = tempSpriteQuick;

            Regist_Item_Icon1.sprite = Regist_Item_Icon2.sprite;
            Regist_Item_Icon2.sprite = tempSpriteRegist;

            QuickSlotText1.text = QuickSlotText2.text; // 텍스트 값을 교환
            QuickSlotText2.text = tempText; // 이전에 저장한 값을 할당
        }

        public void duplicationIconFalse(string buttonNumber)  // 중복 아이템이 있을시 비활성화
        {
            SetIconFalse(buttonNumber, "!swap");
            Debug.Log($"중복 아이템 감지 {buttonNumber} 슬롯 duplicationIconFalse 실행");
        }
        public void duplicationIconTrue(string buttonNumber)  // 중복 아이템이 있을시 활성화
        {
            SetIconTrue(buttonNumber);
            Debug.Log($"중복 아이템 감지 {buttonNumber} 슬롯 duplicationIconTrue 실행");
        }
        #endregion

        #region ------------------텍스트 업데이트 관련--------------------
        public void UpdateTextIfActiveAndMatch(TextMeshProUGUI text, Image icon, string itemId, int count)  // textUpdate 하기전 체크
        {
            if (text.gameObject.activeSelf && icon.sprite.name == itemId)
            {
                text.text = (int.Parse(text.text) + count).ToString();
            }
        }

        public void textUpdate(string Item_id, int count)  // 드랍템 먹을때 퀵슬롯 텍스트 업데이트
        {
            UpdateTextIfActiveAndMatch(QuickSlotText1, Item_btn_Icon1, Item_id, count);
            UpdateTextIfActiveAndMatch(QuickSlotText2, Item_btn_Icon2, Item_id, count);
        }

        public Transform FindSlot(string ItemBtnID, InventorySlot[] inventorySlot)  // 인벤토리에서 아이템 슬롯 찾는 용도
        {
            foreach (var slot in inventorySlot)
            {
                if(slot.itemIcon_Image.sprite.name == ItemBtnID)
                {
                    return slot.transform;
                }
            }
            Debug.Log("사용한 아이템이랑 슬롯 이미지가 일치하지 않음");
            return null;
        }

        public void SetRegistText(string ItemBtnID, string buttonNumber, InventorySlot[] inventorySlot) // 등록시 텍스트 설정
        {
            ChickedSlot = FindSlot(ItemBtnID, inventorySlot);
            if (ChickedSlot == null)
            {
                return;
            }
            InventorySlot QuickSlot_SC = ChickedSlot.GetComponent<InventorySlot>();
            if (int.TryParse(QuickSlot_SC.itemCount_Text.text, out int count))
            {
                Set_Text(buttonNumber, count);
            }
        }
        public void Set_Text(string buttonNumber, int count)     // 텍스트 업데이트
        {
            TextMeshProUGUI selectedText = buttonNumber == "1" ? QuickSlotText1 : QuickSlotText2;
            selectedText.text = count.ToString();
            selectedText.gameObject.SetActive(true);       
        }
        #endregion
    }
}

