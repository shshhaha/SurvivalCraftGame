using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_Boat : MonoBehaviour
{

    [SerializeField]
    protected GameObject[] Boat;
    [SerializeField]
    private GameEnd_Clear gameEnd_Clear;

    private Button BoatButton;

    private Collider doorCollider;


    private GameObject door;

    private bool isDoorOpen = false;


    private float detectionRange = 3f;// 감지 범위
    private float checkInterval = 0.3f; // 감지 간격


    void Start()
    {
        GameObject buttonPrefab = Resources.Load("Prefabs/DoorOpenButton") as GameObject;
        // 버튼 인스턴스 생성
        Vector3 position = new Vector3(-420f, 540f, 0f);
        BoatButton = Instantiate(buttonPrefab, position, Quaternion.identity).GetComponent<Button>();
        // 캔버스 찾기
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        // 버튼의 부모를 캔버스로 설정
        BoatButton.transform.SetParent(canvas.transform, false);

        doorCollider = this.GetComponent<Collider>();
        door = this.gameObject;
        BoatButton.onClick.AddListener(OnOpenButtonClick);
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
                if (isPlayerNearby)
                {
                    BoatButton.gameObject.SetActive(true);
                }
                else
                {
                    BoatButton.gameObject.SetActive(false);
                }

                yield return new WaitForSeconds(checkInterval);
            }
        }

    void OnOpenButtonClick()
    {
        BoatButton.interactable = false;
        StartCoroutine(BoatSet());
        gameEnd_Clear.GameEndClear();
    }

    IEnumerator BoatSet()
    {
        yield return new WaitForSeconds(0f);

        if (Boat.Length > 0)
        {
            Instantiate(Boat[0], transform.position, Quaternion.identity);
        }
    }

}
