
using DTO.WeaponDTO.GrenadeDTO;
using DTO.WeaponDTO.GunDTO;
using DTO.PlayerDTO;
using sound.monsterSound;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using GameEnd;

public class LongDMon : MonoBehaviour
{
    private ItemDrop itemDrop;
    public KillReward getKillReward;

    //스텟------------------------------------------------------------------------------
    public float attackRange = 9f; // 공격 범위
    public float bulletSpeed = 10f; // 투사체 속도
    private float hp = 100f; // 체력
    private float destroy_range = 140f;  // 삭제 거리
    //---------------------------------------------------------------------------------

    private GunDTO rwdto;//VO 접근
    private GrenadeDTO grdto;//VO 접근
    private PlayerDTO pdto; //VO 접근
    public GameObject projectile; // 발사할 투사체
    private bool picker_wait = false;//드랍테이블 쿨타임
    private bool count_wait = false;//몹 카운트 쿨타임

    public GameObject playerObj;
    public Transform player;
    private NavMeshAgent agent;

    private bool isAttacking = false;
    public GameObject BulletPoint;
    private bool _isAlive = true;
    private Animator animator;

    private Vector3 LongBPoint;
    

    [SerializeField]
    private LongDisMonAni animationController;
    

    void Start()
    {
        rwdto = GunDTO.Instance;//VO 접근
        grdto = GrenadeDTO.Instance;//VO 접근
        pdto = PlayerDTO.Instance;//VO 접근
        playerObj = GameObject.Find("Player");
        player = playerObj.transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        itemDrop = GetComponent<ItemDrop>();
        getKillReward = GetComponent<KillReward>();
        animationController = GameObject.Find("LongDMonAnimationCtrl").GetComponent<LongDisMonAni>();
    }

    void Update()
    {
        Vector3 playerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

        Vector3 startPosition = transform.position + new Vector3(0, 3, 0);

        RaycastHit hit;
        NavStopReset();
        /*
        if (Physics.Raycast(startPosition, player.position - transform.position, out hit, distanceToPlayer))
        {
            Debug.DrawRay(startPosition, (player.position - transform.position) * distanceToPlayer, Color.red); // 레이를 빨간색으로 그립니다.

            if (hit.collider.tag != "Player" && hit.collider.tag != "laser")
            {
                Debug.Log("플레이어가 시야에 없습니다.");
                if (distanceToPlayer > 15f)
                {
                    animationController.longDIdle();
                }
                else if (distanceToPlayer <= 15f)
                {
                    agent.SetDestination(player.position);
                    animationController.longDChase();
                    if (distanceToPlayer <= attackRange && isAttacking == false)
                    {
                        NavStopSet();
                        StartCoroutine(RangedAttack());
                    }
                }
            }
        }
    */
        if(distanceToPlayer <= 13f && _isAlive == true)
        {
            transform.LookAt(player.position);
            agent.SetDestination(player.position);
            longDChase();
            if (distanceToPlayer <= attackRange)
            {
                NavStopSet();
                if (isAttacking == false) StartCoroutine(RangedAttack());
                longDAttack();
            }
        }
        else if(distanceToPlayer > 13f)
        {
            longDIdle();
            NavStopSet();
        }


        if (hp <= 0)
        {
            longDDead();
            this.gameObject.GetComponent<Collider>().enabled = false;
            _isAlive = false;
            M_Spanwer.numberOfMonster_1--;
            if (!count_wait)
            {
                StartCoroutine(MiddleMobCount());
            }
            Destroy(this.gameObject, 3.1f);
            if(picker_wait == false)
            {
                picker_wait = true;
                getKillReward.killReward();
                itemDrop.dropItem();
            }    
            NavStopSet();
        }

        if (distanceToPlayer > destroy_range && _isAlive == true){     // 거리 멀어지면 삭제                   
                Destroy(this.gameObject, 1f);
                Debug.Log("거리 멀어져서 몹 삭제");
            }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _MonsterSound.instance.PlayMonsterSFX(_MonsterSound.MonsterSfx.ZombiHit);
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

    IEnumerator RangedAttack()
    {
        isAttacking = true;
        LongBPoint = BulletPoint.transform.position; // Empty Object의 위치를 LongBPoint로 설정

        // 투사체를 발사하는 코드
        GameObject bullet = Instantiate(projectile, LongBPoint, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // 포물선 운동을 위한 초기 속도 계산
        Vector3 direction = (player.position - transform.position);
        float distance = direction.magnitude;

        // 수직 방향의 속도 계산
        float velocityY = Mathf.Sqrt(-2 * Physics.gravity.y * (distance - transform.position.y));
        // 수평 방향의 속도 계산
        float velocityXZ = distance / (Mathf.Sqrt((-2 * (distance - transform.position.y)) / Physics.gravity.y));

        // 수직 속도 감소
        velocityY *= 0.4f;
        velocityXZ *= 1.3f;

        Vector3 velocity = direction.normalized * velocityXZ;
        velocity.y = velocityY;

        bulletRb.velocity = velocity;

        yield return new WaitForSeconds(2.35f); // 3초 동안 대기

        isAttacking = false;
    }

    IEnumerator MiddleMobCount()
    {
        count_wait = true;
        pdto.setMiddleCount(pdto.getMiddleCount()+1); 
        Debug.Log("몹 카운트 : " + pdto.getMiddleCount());
        if(pdto.getMiddleCount() == 1)
        {
            Escape.instance.EscapeItemUpdate("quest2(Clone)", 10);
        }
        yield return new WaitForSeconds(3f);
        count_wait = true;
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

    public void longDIdle()
    {
        animator.SetBool("LongDIdle", true);
        animator.SetBool("LongChase", false);
        animator.SetBool("LongAttack", false);
        animator.SetBool("LongDDead", false);
    }

    public void longDChase()
    {
        animator.SetBool("LongDIdle", false);
        animator.SetBool("LongChase", true);
        animator.SetBool("LongAttack", false);  
        animator.SetBool("LongDDead", false);
    }

    public void longDAttack()
    {
        animator.SetBool("LongDIdle", false);
        animator.SetBool("LongChase", false);
        animator.SetBool("LongAttack", true);
        animator.SetBool("LongDDead", false);
    }

    public void longDDead()
    {
        animator.SetBool("LongDIdle", false);
        animator.SetBool("LongChase", false);
        animator.SetBool("LongAttack", false);
        animator.SetBool("LongDDead", true);
    }
}