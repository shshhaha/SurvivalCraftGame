using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    [Tooltip("스폰할 아이템 리스트 지정")]
    public List<GameObject> items; // 스폰할 아이템 리스트

    [Tooltip("각 아이템의 스폰 확률 리스트의 순서와 동일하게 지정")]
    public List<float> probabilities; // 각 아이템의 스폰 확률

    [Tooltip("스포너가 활성화되면 스폰할 아이템의 개수")]
    public int repetitions;

    [Tooltip("아이템 라이프타임(second) (lofeTime = 0 이면 무한대)")]
    public float lifeTime;

    private bool isMonsterActive; //몬스터 사망판정

    public void dropItem()
    {
        
        for (int i = 0; i < repetitions; i++)
        {
            if (isMonsterActive == false)
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
                        GameObject spawnedItem = Instantiate(itemToSpawn, transform.position, Quaternion.identity);
                        if(lifeTime > 0)
                        {
                            Destroy(spawnedItem, lifeTime);
                        }
                        break;
                    }
                }
            }
        }
    }
}
