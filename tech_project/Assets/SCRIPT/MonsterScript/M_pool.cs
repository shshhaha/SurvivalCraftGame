using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_pool : MonoBehaviour
{
    //프리펩들 보관할 변수
    public GameObject[] prefabs;

    //리스트
    List<GameObject>[] spawner;


    void Awake()
    {
        spawner = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < spawner.Length; i++)
        {
            spawner[i] = new List<GameObject>();
        }
    }

    public GameObject Mon(int a)
    {
        GameObject select = null;
        //선택한 스포너에 비활성화 된 오브젝트 접근
        foreach (GameObject item in spawner[a])
        {
            if (!item.activeSelf)
            {
                //발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //못 찾으면
        if (!select)
        {
            //새롭게 생성해서 select 변수에 할당
            select = Instantiate(prefabs[a], transform);
            spawner[a].Add(select);
        }

        return select;
    }
}