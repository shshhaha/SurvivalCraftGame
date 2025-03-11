using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Boss_Move : MonoBehaviour
{
    public float chaseRange = 11f; // 추적 범위
    public float attackRange = 9f; // 공격 범위
    private Transform player;
    private NavMeshAgent agent;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 startPosition = transform.position + new Vector3(0, 3, 0);

        Vector3 playerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        NavStopReset();

        if (distanceToPlayer <= 5f)
        {
            NavStopSet();
        }
        else if (distanceToPlayer <= 14f)
        {
            transform.LookAt(player.position);
            agent.SetDestination(player.position);
        }
        else if (distanceToPlayer > 14f)
        {
            NavStopSet();
        }
    }


    public void NavStopReset()
    {
        this.agent.ResetPath();
        this.agent.isStopped = false;
        this.agent.updatePosition = true;
        this.agent.updateRotation = true;
    }


    //네비메쉬 멈춤
    public void NavStopSet()
    {
        this.agent.isStopped = true;
        this.agent.updatePosition = false;
        this.agent.updateRotation = false;
        this.agent.velocity = Vector3.zero;
    }
}
