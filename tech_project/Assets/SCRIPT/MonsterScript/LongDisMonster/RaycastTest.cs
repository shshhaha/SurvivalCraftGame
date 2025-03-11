using sound.monsterSound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaycastTest : MonoBehaviour
{
    [SerializeField]
    private LongDisMonAni animationController;

    public float chaseRange = 12f; // 추적 범위
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

        RaycastHit hit;



        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        NavStopReset();

        if (distanceToPlayer <= attackRange)
        {
            transform.LookAt(player.position);
                if (Physics.Raycast(startPosition, player.position - transform.position, out hit, distanceToPlayer))
                {
                    if (hit.collider.tag != "Player")
                    {
                        Debug.Log("플레이어가 시야에 없습니다.");
                        if (distanceToPlayer > chaseRange)
                        {
                            agent.isStopped = true;
                        }
                        else if (distanceToPlayer <= chaseRange)
                        {
                            agent.isStopped = false;
                            agent.SetDestination(player.position);
                        }
                    }
                }
        }
        else if (distanceToPlayer <= chaseRange)
        {
            transform.LookAt(player.position);
            agent.SetDestination(player.position);
        }
        else
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

