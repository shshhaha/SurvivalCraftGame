using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using MainInventory;
using sound.uiSound;

public class UI_ShowInventory : MonoBehaviour
{
    public GameObject inventoryUI;
    public Button ShowInventory_Button;
    public Button CloseInventory_Button;




    public void Start()
    {
        InventoryDAO.selectedTab = 0;
        inventoryUI.SetActive(false); // 게임 오브젝트 비활성화
        //Debug.Log("인벤토리 비활성화");

        ShowInventory_Button.onClick.AddListener(ShowInventoryUI); //인벤토리 보여짐 
        CloseInventory_Button.onClick.AddListener(CloseInventoryUI); // 인벤토리 꺼짐
    }


    public void ShowInventoryUI()
    {
        _UiSound.instance.PlayUiSFX(_UiSound.UiSfx.OpenInventory);

        inventoryUI.SetActive(true); // 버튼 클릭 시 게임 오브젝트 활성화
        Time.timeScale = 0.05f;
        
        if (InventoryDAO.selectedTab == 0 || InventoryDAO.selectedTab == 1)
        {
            StartCoroutine(Test());
            //InventoryDAO.ShowInvenTab();
            //Debug.Log(InventoryDAO.selectedTab+"탭 인벤토리 활성화");
        }
    }

    private IEnumerator Test()
    {
        yield return null;
        InventoryDAO.ShowInvenTab();
    }


    public void CloseInventoryUI()
    {
        _UiSound.instance.PlayUiSFX(_UiSound.UiSfx.CloseInventory);

        inventoryUI.SetActive(false); // 버튼 클릭 시 게임 오브젝트 활성화
        Time.timeScale = 1;
        //Debug.Log("인벤토리 비활성화");
    }
    
}
