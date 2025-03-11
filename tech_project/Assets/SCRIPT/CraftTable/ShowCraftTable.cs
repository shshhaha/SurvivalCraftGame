using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using MainInventory;
using sound.uiSound;
using System;

public class ShowCraftTable : MonoBehaviour
{
    public GameObject CraftTableUI;
    public Button ShowCraftTable_Button;
    public Button CloseCraftTable_Button;




    public void Start()
    {
        CraftTableUI.SetActive(false); // 게임 오브젝트 비활성화
        //Debug.Log("제작대 비활성화");

        ShowCraftTable_Button.onClick.AddListener(ShowCraftTableUI); //제작대 켜짐 
        CloseCraftTable_Button.onClick.AddListener(CloseCraftTableUI); // 제작대 꺼짐
    }


    public void ShowCraftTableUI()
    {
        CraftTableUI.SetActive(true);
        StartCoroutine(DelayShowTab());
        //Debug.Log("제료탬, 제작탬 보여주기22222222");
    }
    private IEnumerator DelayShowTab()
    {
        yield return null;
        CraftTableDAO.ShowMaterTab();
        CraftTableDAO.ShowCraftTab();
    }


    public void CloseCraftTableUI()
    {
        InventoryDAO.ShowInvenTab();
        CraftTableUI.SetActive(false); 
    }
    
}
