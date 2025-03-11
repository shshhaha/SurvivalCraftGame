using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOpener : MonoBehaviour
{
    private Button openShopButton;
    public Button closeShopButton;

    public Button InventoryButton;

    private GameObject shop;
    public GameObject ShopUI;
    public GameObject InventoryUI;



    private float detectionRange = 2.25f;// 감지 범위
    private float checkInterval = 0.1f; // 감지 간격

    private void Start()
    {
        GameObject buttonPrefab = Resources.Load("Prefabs/ShopOpenButton") as GameObject;

        // 버튼 인스턴스 생성
        Vector3 position = new Vector3(-420f, 540f, 0f);
        openShopButton = Instantiate(buttonPrefab, position, Quaternion.identity).GetComponent<Button>();
        // 캔버스 찾기
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        // 버튼의 부모를 캔버스로 설정
        openShopButton.transform.SetParent(canvas.transform, false);


        shop = this.gameObject;
        ShopUI.SetActive(false);
        openShopButton.onClick.AddListener(OnOpenButtonClick);
        closeShopButton.onClick.AddListener(OnCloseButtonClick);
        StartCoroutine(CheckPlayerNearby());
    }

    IEnumerator CheckPlayerNearby()
    {
        while (true)
        {

            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange);
            bool isPlayerNearby = false;

            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.tag == "Player")
                {
                    isPlayerNearby = true;
                    break;
                }
            }
            
            // 플레이어가 근처에 있을 때만 이 문의 버튼을 활성화
            if (isPlayerNearby && !ShopUI.activeSelf && !InventoryUI.activeSelf)
            {
                openShopButton.gameObject.SetActive(true);
            }
            else
            {
                openShopButton.gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(checkInterval);
            
        }
    }
    
    void OnOpenButtonClick()
    {
        openShopButton.interactable = false;
        InventoryButton.interactable = false;
        ShopUI.SetActive(true);
    }

    public void OnCloseButtonClick()
    {
        ShopUI.SetActive(false);
        openShopButton.interactable = true;
        InventoryButton.interactable = true;
    }

    
}
