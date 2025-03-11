using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBase;
using MainInventory;
using sound.uiSound;
using Item_Base;
using Item_QuickSlot;

public class ItemPickup : MonoBehaviour
{
    public DatabaseManager theDatabase;

    private string itemID;
    private Item item;
    private int itemCount =1;

    void Start()
    {

    }
        


    private void OnTriggerEnter(Collider collider)
    {
        // 충돌한 오브젝트가 아이템이면
        if (collider.gameObject.tag == "Item")
        {
            _UiSound.instance.PlayUiSFX(_UiSound.UiSfx.ItemPickUp);

            //itemID = itemID.Substring(0, itemID.Length - 7); // 아이템 이름에서 뒤에서 5글자를 제외한 모든 글자를 가져옵니다. ((Clone) 제거)

            itemID = collider.gameObject.name;// 아이템 이름을 저장합니다.           
            //Debug.Log("아이템 이름: " + collider.gameObject.name);// 아이템 이름을 출력합니다.

            item = theDatabase.itemList.Find(x=> x.itemID == itemID); // 아이템 정보를 가져옵니다.
            
            if(item.itemType == Item.ItemType.Craft) //타입 확인하여 제작대에 넣을지 인벤토리에 넣을지 판단
            {
                CraftTableDAO.instance.GetMaterItem(itemID, itemCount);
            }
            else if(item.itemType == Item.ItemType.Use || item.itemType == Item.ItemType.Equip)
            {
                InventoryDAO.instance.GetInvenItem(itemID, itemCount);
                ItemQuickSlot.instance.textUpdate(itemID, itemCount);
            }     
            Destroy(collider.gameObject);
            //Debug.Log("아이템 삭제함");
        }
    }
}
