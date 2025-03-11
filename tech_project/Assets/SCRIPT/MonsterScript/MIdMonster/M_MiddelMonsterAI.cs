using DTO.PlayerDTO;
using DTO.WeaponDTO.GrenadeDTO;
using DTO.WeaponDTO.GunDTO;
using sound.monsterSound;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using DTO.WeaponDTO.GrenadeDTO; // 가중치 접근
using GameEnd;
using sound.playerSound;

public class M_MiddleMonsterAi : MonoBehaviour
{
    private ItemDrop itemDrop;
    public KillReward getKillReward;

    //스텟------------------------------------------------------------------------------
    private float speed = 5f; // 이동속도
    private float range = 10f; 
    private float destroy_range = 140f;  // 삭제 거리
    private float hp = 100f; // 체력
    private int atk = 10; // 공격력
    //---------------------------------------------------------------------------------

    private GunDTO rwdto;//VO 접근
    private GrenadeDTO grdto;//VO 접근
    private PlayerDTO pdto; //VO 접근

    [SerializeField]
    Animator animator;
    NavMeshAgent agent;
    public Transform player;
    public GameObject playerObj;
    
    private bool _isAlive = true;
    private bool _wait = false;//공격 쿨타임
    private bool count_wait = false;//몹 카운트 쿨타임
    private bool picker_wait = false;//드랍테이블 쿨타임

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        rwdto = GunDTO.Instance;//VO 접근
        pdto = PlayerDTO.Instance;//VO 접근
        grdto = GrenadeDTO.Instance;//VO 접근
        Animator animator = GameObject.Find("MiddelMonster(Clone)").GetComponent<Animator>();
        playerObj = GameObject.Find("Player");
        player = playerObj.transform;
        itemDrop = GetComponent<ItemDrop>();
        getKillReward = GetComponent<KillReward>();
    }

    void FixedUpdate()
    {
        /*if(playerObj == null)
        {
            playerObj = GameObject.Find("Player");
            player = playerObj.transform;
        }*/
        NavStopReset();
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= range && _isAlive == true)
        {
            agent.SetDestination(player.position);
            
            animator.SetBool("IsChase", true);
            if (distance <= 2f)
            {
                
                animator.SetTrigger("MidAttack");
                
                if (_wait == false)
                {
                    _wait = true;
                    AtkToPlayer();
                }
            }
            else
            {
                
                animator.SetBool("PlayerOut", true);
                animator.SetBool("IsChase", true);
            }
        }
        else
        {
            NavStopSet();
            animator.SetBool("IsChase", false);
        }

        if (hp <= 0 && animator.GetBool("IsChase") == false)
        {
            animator.SetBool("MidDead", true);
            this.gameObject.GetComponent<Collider>().enabled = false;
            _isAlive = false;
            M_Spanwer.numberOfMonster_1--;

            if(!count_wait)
            {
                StartCoroutine(MiddleMobCount());
            }  
            Destroy(this.gameObject, 3f);
        
            if(picker_wait == false)
            {
                picker_wait = true;
                getKillReward.killReward();
                itemDrop.dropItem();
            }    
        }
        else if (hp <= 0 && animator.GetBool("IsChase") == true)
        {
            animator.SetBool("MidChaseDead", true);
            this.gameObject.GetComponent<Collider>().enabled = false;
            _isAlive = false;
            M_Spanwer.numberOfMonster_1--;
            if(!count_wait)
            {
                StartCoroutine(MiddleMobCount());
            }
            Destroy(this.gameObject, 3f);

            if(picker_wait == false)
            {
                picker_wait = true;
                getKillReward.killReward();
                itemDrop.dropItem();
            }    
        }
        if (distance > destroy_range && _isAlive == true){     // 거리 멀어지면 삭제                   
                Destroy(this.gameObject, 1f);
                Debug.Log("거리 멀어져서 몹 삭제");
            }
    }
    private void AtkToPlayer()
    {
        pdto.setCurrentHp((int)pdto.getCurrentHp() - atk);
        StartCoroutine(AttackCooldownCoroutine());
        _PlayerSound.instance.PlayPlayerSFX(_PlayerSound.PlayerSfx.PlayerHit);
    }
    private IEnumerator AttackCooldownCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        _wait = false;
    }

    //총알 맞았을때
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

    //네비메쉬 멈춤 초기화
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
        count_wait = false;
    }
}
   