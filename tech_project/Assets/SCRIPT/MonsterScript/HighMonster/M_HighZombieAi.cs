using AssetKits.ParticleImage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class M_HighZombieAi : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    public Transform player;
    private float range = 10f;
    // Start is called before the first frame update
    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= range)
        { 
            agent.SetDestination(player.position);
        }
    }
}
