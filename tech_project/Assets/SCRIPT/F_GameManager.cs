using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_GameManager : MonoBehaviour
{
    public static F_GameManager instance;

    public M_pool pool;

    void Awake()
    {
        instance = this;
    }
}
