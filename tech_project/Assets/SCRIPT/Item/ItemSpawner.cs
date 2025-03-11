using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private Vector3 spawnAreaSize; // 스폰 범위

    [SerializeField]
    [Tooltip("충돌 감지 범위 추가 보정값 ex) 1 으로 지정시 추가 보정 없음, 1.1으로 지정시 10%만큼 범위만큼 추가 보정됨")]
    private float calibrateDetectionRange = 1f; // 충돌 감지 범위 추가 보정값

    [SerializeField]
    [Tooltip("스폰할 아이템 리스트 지정")]
    public List<GameObject> items; // 스폰할 아이템 리스트

    [Tooltip("각 아이템의 스폰 확률 리스트의 순서와 동일하게 지정")]
    public List<float> probabilities; // 각 아이템의 스폰 확률

    [Tooltip("스포너가 활성화되면 스폰할 아이템의 개수")]
    public int repetitions;
    private bool spownerActive = true;
    [Tooltip("스포너 재사용 대기시간 ex) 0으로 설정시 1회용 그 이상의 값으로 설정시 값만큼의 시간(초) 후 재사용 가능 시간은 리얼타임 기준임 단, 재사용 시간을 설정하기 위해서는 충돌 스폰일 경우에만 사용 가능")]
    public float reuseTime = 0f;
    
    [SerializeField]
    public ActivationCondition activationCondition;
    public enum ActivationCondition { 충돌, 시작 }

    private void Start()
    {
        spawnAreaSize = GetComponent<Renderer>().bounds.size;
        
        CalibrateColliderSize();

        if (activationCondition == ActivationCondition.시작)
        {
            Debug.Log("아이템 스포너 활성화");
            SpawnItem();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && activationCondition == ActivationCondition.충돌)
        {
            Debug.Log("아이템 스포너 활성화");
            SpawnItem();
        }
    }
    void CalibrateColliderSize()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            Vector3 originalScale = collider.transform.localScale;
            Vector3 additionalScale = (calibrateDetectionRange - 1) * originalScale;
            collider.transform.localScale += new Vector3(additionalScale.x, 0f, additionalScale.z);
        }
    }

    private IEnumerator ReuseSpawner()
    {
        if(reuseTime == 0f || reuseTime < 0){yield break;}
        else{
        yield return new WaitForSeconds(reuseTime);
        spownerActive = true;}
    }
    private void SpawnItem()
    {
        for (int i = 0; i < repetitions; i++)
        {
            if (spownerActive == true)
            {
                float totalProbability = 0f;
                foreach (float probability in probabilities)
                {
                    totalProbability += probability;
                }

                float randomValue = Random.Range(0f, totalProbability);
                float cumulativeProbability = 0f;

                for (int j = 0; j < items.Count; j++)
                {
                    // 누적 확률 더하기 이거 계산 안하면 리스트 뒤로갈수록 확률이 뒤틀림
                    cumulativeProbability += probabilities[j];

                    if (randomValue <= cumulativeProbability)
                    {
                        // 아이템 스폰 코드
                        GameObject itemToSpawn = items[j];
                        Vector3 spawnPosition = new Vector3(
                            transform.position.x + Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                            transform.position.y,
                            transform.position.z + Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
                        );
                        Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);
                        break;
                    }
                }
            }
        }
        spownerActive = false;
        StartCoroutine(ReuseSpawner());
    }
}