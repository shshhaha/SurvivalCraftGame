using DTO.PlayerDTO;
using DTO.WeaponDTO.GrenadeDTO;
using DTO.WeaponDTO.GunDTO;
using sound.monsterSound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using GameEnd;

public class BossAnimation2 : MonoBehaviour
{
    private ItemDrop itemDrop;
    public KillReward getKillReward;

    //스텟------------------------------------------------------------------------------
    private float hp = 100f; // 체력
    private int atk = 10; // 공격력
    //---------------------------------------------------------------------------------

    private NavMeshAgent agent;

    private GunDTO rwdto;//VO 접근
    private GrenadeDTO grdto;//VO 접근
    private PlayerDTO pdto; //VO 접근

    [SerializeField]
    private BossAnimationCtrl2 animationController;
    public GameObject player;
    public Transform playerT;
    private bool _isAlive = true;
    private bool _wait = false;//공격 쿨타임
    private bool count_wait = false;//몹 카운트 쿨타임
    private bool picker_wait = false;//드랍테이블 쿨타임

    // Start is called before the first frame update
    void Start()
    {
        rwdto = GunDTO.Instance;//VO 접근
        pdto = PlayerDTO.Instance;//VO 접근
        grdto = GrenadeDTO.Instance;//VO 접근
        itemDrop = GetComponent<ItemDrop>();
        getKillReward = GetComponent<KillReward>();



        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = new Vector3(playerT.position.x, transform.position.y, playerT.position.z);
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        NavStopReset();

        if (distanceToPlayer <= 13f && _isAlive == true)
        {
            agent.SetDestination(playerT.position);
            animationController.bossWalk();
            if (distanceToPlayer <= 5f)
            {
                StartCoroutine(attackDelay());
                NavStopSet();

                if (_wait == false)
                {
                    _wait = true;
                    AtkToPlayer();
                }
            }
            else animationController.bossWalk();
        }
        else if (distanceToPlayer > 14f)
        {
            animationController.bossIdle();
            NavStopSet();
        }

        if (hp <= 0)
        {
            animationController.bossDead();
            NavStopSet();    
            this.gameObject.GetComponent<Collider>().enabled = false;
            _isAlive = false;
            if(!count_wait)
            {
                StartCoroutine(BossCount());
            } 
            Destroy(this.gameObject, 3f);
            if(picker_wait == false)
            {
                picker_wait = true;
                getKillReward.killReward();
                itemDrop.dropItem();
            }
        }
    }


    private void AtkToPlayer()
    {
        StartCoroutine(DelayedDamageCoroutine());
    }

    private IEnumerator DelayedDamageCoroutine()
    {
        yield return new WaitForSeconds(1f); // 1초의 딜레이를 추가합니다.
        pdto.setCurrentHp((int)pdto.getCurrentHp() - atk);
        StartCoroutine(AttackCooldownCoroutine());
    }
    private IEnumerator AttackCooldownCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _wait = false;
    }

    IEnumerator attackDelay()
    {
        animationController.bossAttack();
        yield return new WaitForSeconds(2f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= rwdto.getDamage();
        }
    }
    private void OnParticleCollision(GameObject other)    // Particlesystem 전용 Collision 호출용
    {
        if (other.CompareTag("Grenade"))
        {
            Debug.Log("수류탄 맞았어");
            hp -= grdto.getG_damage();
        }
        else if (other.CompareTag("RPG"))
        {
            Debug.Log("RPG 폭발 피격");
            hp -= rwdto.getCurrentDamage();
        }
    }
    IEnumerator BossCount()
    {
        count_wait = true;
        pdto.setBossCount(pdto.getBossCount()+1); 
        Debug.Log("몹 카운트 : " + pdto.getBossCount());
        if(pdto.getBossCount() == 1)
        {
            Escape.instance.EscapeItemUpdate("quest3(Clone)", 3);
        }
        yield return new WaitForSeconds(3f);
        count_wait = false;
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