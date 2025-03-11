using Function.ItemEffect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBTNSlot1Controller : MonoBehaviour
{
    public Button item_btn_UI1;
    public Button item_btn_UI2;
    private ItemEffect ItemEffect;  //아이템 적용 효과 클래스
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        GetItemEffect();
        item_btn_UI1.onClick.AddListener(UseItem1);
        item_btn_UI2.onClick.AddListener(UseItem2);
    }
    void UseItem1(){
        ItemEffect.UseItemEffect(1);
    }
    void UseItem2(){
        ItemEffect.UseItemEffect(2);
    }
    void GetItemEffect(){
        ItemEffect = ItemEffect.Instance; //아이템 효과 클래스 인스턴스
    }
}
