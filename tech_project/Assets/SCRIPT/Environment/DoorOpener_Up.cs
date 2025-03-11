using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpener : MonoBehaviour
{
    private Button openButton;
    private Collider doorCollider;

    [SerializeField]
    [Tooltip("문이 열리는 각도")]
    private float openAngle = 120f;

    [SerializeField]
    private float duration = 0.6f; // 문이 완전히 열리는 데 걸리는 시간

    private GameObject door;
    private bool isDoorOpen = false;



    private float detectionRange = 2.25f;// 감지 범위
    private float checkInterval = 0.3f; // 감지 간격

    private void Start()
    {
        GameObject buttonPrefab = Resources.Load("Prefabs/DoorOpenButton") as GameObject;

        // 버튼 인스턴스 생성
        Vector3 position = new Vector3(-420f, 540f, 0f);
        openButton = Instantiate(buttonPrefab, position, Quaternion.identity).GetComponent<Button>();
        // 캔버스 찾기
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        // 버튼의 부모를 캔버스로 설정
        openButton.transform.SetParent(canvas.transform, false);

        doorCollider = this.GetComponent<Collider>();

        door = this.gameObject;
        openButton.onClick.AddListener(OnOpenButtonClick);
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
                openButton.gameObject.SetActive(true);
            }
            else
            {
                openButton.gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }
    
    void OnOpenButtonClick()
    {
        openButton.interactable = false;
        StartCoroutine(OpenDoor());
    }

    private IEnumerator OpenDoor()
    {
        Quaternion startRotation = door.transform.rotation;
        Quaternion endRotation;

        if (isDoorOpen)
        {
            // 문이 이미 열려있는 경우, 문을 닫는 방향으로 회전
            endRotation = Quaternion.Euler(door.transform.eulerAngles.x, door.transform.eulerAngles.y - openAngle, door.transform.eulerAngles.z);
        }
        else
        {
            // 문이 닫혀있는 경우, 문을 여는 방향으로 회전
            endRotation = Quaternion.Euler(door.transform.eulerAngles.x, door.transform.eulerAngles.y + openAngle, door.transform.eulerAngles.z);
        }

        // 문이 움직이는 동안 콜라이더를 비활성화
        doorCollider.enabled = false;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            door.transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        door.transform.rotation = endRotation;
        isDoorOpen = !isDoorOpen;

        // 문의 움직임이 끝나면 콜라이더를 다시 활성화
        doorCollider.enabled = true;

        // 선형 보간이 끝나면 버튼을 다시 활성화
        openButton.interactable = true;
    }
}