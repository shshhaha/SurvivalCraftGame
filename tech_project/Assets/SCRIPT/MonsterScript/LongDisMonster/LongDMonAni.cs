using DTO.PlayerDTO;
using DTO.WeaponDTO.GrenadeDTO;
using DTO.WeaponDTO.GunDTO;
using sound.monsterSound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDMonAni : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    private float hp = 100f;

    private GunDTO rwdto;//VO 접근
    private GrenadeDTO grdto;//VO 접근
    private PlayerDTO pdto; //VO 접근

    private bool _isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        rwdto = GunDTO.Instance;//VO 접근
        pdto = PlayerDTO.Instance;//VO 접근
        grdto = GrenadeDTO.Instance;//VO 접근
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 12f)
        {
            animator.SetBool("LongChase", true);
            if(distance <= 9f)
            {
                animator.SetBool("LongAttack", true);
            }
            else
            {
                animator.SetBool("LongAttack", false);
            }
        }
        else
        {
            animator.SetBool("LongChase", false);
        }

        if (hp <= 0)
        {
            animator.SetBool("LongIdleChaseDead", true);
            this.gameObject.GetComponent<Collider>().enabled = false;
            _isAlive = false;
            M_Spanwer.numberOfMonster_1--;
            Destroy(this.gameObject, 10f);
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
}
