using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RushMAni : MonoBehaviour
{
    public float chargeDistance = 10f; // 돌진 거리
    public float speed = 5f; // 돌진 속도
    public float chargeDelay = 4f; // 돌진 딜레이
    public float pushBackForce = 5f; // 플레이어를 밀어내는 힘
    private Transform player;
    private Vector3 targetPosition; // 돌진할 위치
    private bool isCharging = false; // 돌진 중인지 여부


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어의 위치를 찾습니다.
        GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate; // 떨림 현상을 줄입니다.
    }

    void FixedUpdate()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // 플레이어와의 거리를 계산합니다.

        if (distanceToPlayer <= chargeDistance && !isCharging) // 거리가 돌진 거리 이하이고 돌진 중이 아니라면
        {
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer = directionToPlayer.normalized; // 정규화
            targetPosition = player.position + directionToPlayer * (chargeDistance * 0.7f); // 돌진할 위치를 설정합니다. 플레이어 위치보다 더 멀리 설정합니다.

            StartCoroutine(ChargeDelay()); // 돌진 딜레이 코루틴을 시작합니다.
        }
        else if (isCharging) // 돌진 중이라면
        {
            Charge(); // 돌진 메서드를 호출합니다.
        }
    }

    IEnumerator ChargeDelay()
    {
        Debug.Log("ChargeDelay started at: " + Time.time); // 코루틴 시작 로그
        yield return new WaitForSeconds(chargeDelay); // 돌진 딜레이만큼 대기합니다.
        isCharging = true; // 돌진 중으로 표시합니다.
        Debug.Log("ChargeDelay ended at: " + Time.time); // 코루틴 종료 로그
    }


    void Charge()
    {
        Vector3 direction = (new Vector3(targetPosition.x, 0, targetPosition.z) - transform.position).normalized; // 돌진할 위치를 향하는 방향을 계산합니다.

        transform.position += direction * speed * Time.deltaTime; // 이 방향으로 이동합니다.

        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // 플레이어와의 거리를 계산합니다.

        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f) // 플레이어에게 충분히 가까워졌다면
        {
            isCharging = false; // 돌진 중이 아님으로 표시합니다.
            StartCoroutine(ChargeDelay()); // 돌진 딜레이 코루틴을 시작합니다.
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 플레이어와 충돌했다면
        {
            Rigidbody playerRigidbody = collision.rigidbody; // 플레이어의 Rigidbody를 가져옵니다.
            if (playerRigidbody != null) // Rigidbody가 있다면
            {
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized; // 밀릴 방향을 계산합니다.
                playerRigidbody.AddForce(pushDirection * pushBackForce, ForceMode.Impulse); // 이 방향으로 힘을 가합니다.
            }

            isCharging = false; // 돌진 중이 아님으로 표시합니다.
            StartCoroutine(ChargeDelay()); // 돌진 딜레이 코루틴을 시작합니다.
        }
        else if (collision.gameObject.CompareTag("Building")) // 건물과 충돌했다면
        {
            isCharging = false; // 돌진 중이 아님으로 표시합니다.
        }
    }
}

