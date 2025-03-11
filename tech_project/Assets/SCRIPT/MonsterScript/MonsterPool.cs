using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public static MonsterPool sharedInstance;
    public GameObject MonsterPrefab;
    public int poolSize = 10;
    private Queue<GameObject> monsterPool;

    void Awake()
    {
        sharedInstance = this;
        monsterPool = new Queue<GameObject>(poolSize);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject monster = Instantiate(MonsterPrefab);
            monster.SetActive(false);
            monsterPool.Enqueue(monster);
        }
    }

    public GameObject GetMonster()
    {
        GameObject monster;
        if (monsterPool.Count > 0)
        {
            monster = monsterPool.Dequeue();
        }
        else
        {
            monster = Instantiate(MonsterPrefab);  
            monsterPool.Enqueue(monster);
        }

        monster.SetActive(true);
        ActivateRandomModel(monster);
        return monster;
    }

    public void ReturnMonster(GameObject monster)
    {
        monster.SetActive(false);
        monsterPool.Enqueue(monster);
    }

    public IEnumerator ReturnMonsterAfterSeconds(GameObject monster, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (monster.activeInHierarchy)
        {
            ReturnMonster(monster);
        }
    }
    private void ActivateRandomModel(GameObject monster)
    {
        GameObject modelContainer = monster.transform.Find("Model").gameObject;     // 오브젝트 찾기

        foreach (Transform child in modelContainer.transform)           // 모든 모델 비활성화
        {
            child.gameObject.SetActive(false);
        }

        if (modelContainer.transform.childCount > 0)
        {
            int randomIndex = Random.Range(0, modelContainer.transform.childCount);     // 랜덤 모델 활성화
            modelContainer.transform.GetChild(randomIndex).gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("자식 모델 오브젝트 미발견함");
        }
    }
}
