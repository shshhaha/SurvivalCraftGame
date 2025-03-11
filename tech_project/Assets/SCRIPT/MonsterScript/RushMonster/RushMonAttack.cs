using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float chargeDistance = 8f; // 돌진 거리
    public float speed = 5f; // 돌진 속도
    public float delay = 3f; // 두 번째 돌진부터의 딜레이
    private Transform player;
    private int chargeCount = 0; // 돌진 횟수
    private float nextChargeTime = 0f; // 다음 돌진 가능 시간
    private Vector3 chargePosition; // 돌진할 위치

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어의 위치를 찾습니다.
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // 플레이어와의 거리를 계산합니다.

        if (distanceToPlayer <= chargeDistance && Time.time >= nextChargeTime) // 플레이어가 돌진 거리 안에 있고, 돌진 가능 시간이 되었을 경우
        {
            chargePosition = player.position; // 돌진할 위치를 플레이어의 현재 위치로 설정합니다.
            Charge(); // 돌진합니다.
        }
    }

    void Charge()
    {
        Vector3 direction = (chargePosition - transform.position).normalized; // 돌진할 위치를 향하는 방향을 계산합니다.
        transform.position += direction * speed * Time.deltaTime; // 돌진할 위치를 향해 이동합니다.

        chargeCount++; // 돌진 횟수를 증가시킵니다.

        if (chargeCount >= 2) // 두 번째 돌진부터는
        {
            nextChargeTime = Time.time + delay; // 다음 돌진 가능 시간을 딜레이 후로 설정합니다.
        }
    }
}
