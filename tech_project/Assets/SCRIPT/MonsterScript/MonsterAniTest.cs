using DTO.PlayerDTO;
using DTO.WeaponDTO.GrenadeDTO;
using DTO.WeaponDTO.GunDTO;
using sound.monsterSound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAniTest : MonoBehaviour
{
    private GunDTO rwdto;
    private GrenadeDTO grdto;
    private PlayerDTO pdto;
    public GameObject player;
    public Animator animator;
    NavMeshAgent nav;
    private float hp = 100f;
    private int atk = 10;
    private bool _isAlive = true;
    private bool _wait = false;




    //네비메쉬 적용
    void Awake()
    {
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NavStopReset();
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 10f)
        {
            nav.SetDestination(player.transform.position);
            animator.SetBool("chase", true);
            if(distance <= 2f)
            {
                animator.SetBool("attack", true);

                if(_wait == false)
                {
                    _wait = true;
                    AtkToPlayer();
                }
            }
            else
            {
                animator.SetBool("attack", false);
            }
        }
        else
        {
            NavStopSet();
            animator.SetBool("chase", false);
        }

        if(hp <= 0 && animator.GetBool("chase") == false)
        {
            animator.SetBool("deadIdle", true);
            this.gameObject.GetComponent<Collider>().enabled = false;
            _isAlive = false;
            M_Spanwer.numberOfMonster_1--;
            Destroy(this.gameObject, 10f);
        }
        else if (hp <= 0 && animator.GetBool("IsChase") == true)
        {
            animator.SetBool("deadBack", true);
            this.gameObject.GetComponent<Collider>().enabled = false;
            _isAlive = false;
            M_Spanwer.numberOfMonster_1--;
            Destroy(this.gameObject, 10f);
        }



    }



    //네비메쉬 멈춤 초기화
    public void NavStopReset()
    {
        this.nav.ResetPath();
        this.nav.isStopped = false;
        this.nav.updatePosition = true;
        this.nav.updateRotation = true;
    }


    //네비메쉬 멈춤
    public void NavStopSet()
    {
        this.nav.isStopped = true;
        this.nav.updatePosition = false;
        this.nav.updateRotation = false;
        this.nav.velocity = Vector3.zero;
    }

    private void AtkToPlayer()
    {
        pdto.setCurrentHp((int)pdto.getCurrentHp() - atk);
        StartCoroutine(AttackCooldownCoroutine());
    }

    private IEnumerator AttackCooldownCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        _wait = false;
    }

    //총알 피격
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _MonsterSound.instance.PlayMonsterSFX(_MonsterSound.MonsterSfx.ZombiHit);
            hp -= rwdto.getDamage();
        }
    }
}
