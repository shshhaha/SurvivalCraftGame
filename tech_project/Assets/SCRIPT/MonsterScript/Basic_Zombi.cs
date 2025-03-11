using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using DTO.PlayerDTO;//DTO 접근
using DTO.MoneyDTO;//DTO 접근
using DTO.TimerDTO;//DTO 접근
using sound.playerSound;
using sound.monsterSound;
using DTO.WeaponDTO.GunDTO;
using DTO.WeaponDTO.GrenadeDTO; // 가중치 접근
using GameEnd;

namespace Monster.Basic_Zombi{
    public class Basic_Zombi : MonoBehaviour
    {

        private ItemDrop itemDrop;
        public KillReward getKillReward;

        //스텟------------------------------------------------------------------------------
        private float speed = 3.5f;   // 이동속도
        private float hp = 70f;      // 체력
        private int atk = 10;         // 공격력
        private float range = 40f;   // 추적 범위
        private float maxHP = 100f;                           // 풀 반환시 최대체력 저장용
        private float return_pool_range = 140f;              // pool 반환 거리 값
        //---------------------------------------------------------------------------------
        private GunDTO rwdto;//VO 접근
        private GrenadeDTO grdto;//VO 접근
        private PlayerDTO pdto; //VO 접근
        Transform target;
        NavMeshAgent nmAgent;
        Monster_Anime_Controller monster_Anime_Controller;
        public Transform player;
        public GameObject playerObj;
        
        private bool _isAlive = true;
        private bool _wait = false;//공격 쿨타임
        private bool count_wait = false;//몹 카운트 쿨타임
        private bool picker_wait = false;//드랍테이블 쿨타임
        void Start(){
            rwdto = GunDTO.Instance;//VO 접근
            pdto = PlayerDTO.Instance;//VO 접근
            grdto = GrenadeDTO.Instance;//VO 접근

            itemDrop = GetComponent<ItemDrop>();
            nmAgent = GetComponent<NavMeshAgent>();
            playerObj = GameObject.Find("Player");
            player = playerObj.transform;
            monster_Anime_Controller = GetComponent<Monster_Anime_Controller>();
            monster_Anime_Controller.IdleType();
        }
        void FixedUpdate()
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= range && _isAlive == true)
            {
                transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                monster_Anime_Controller.MonsterTrace();
                if (distance <= 2f && !monster_Anime_Controller.animator.GetCurrentAnimatorStateInfo(0).IsName("Zombi_Attack"))
                {
                    monster_Anime_Controller.MonsterAttack();
                    if(_wait == false){
                        _wait = true;
                        AtkToPlayer();
                    }
                }
                else{
                    monster_Anime_Controller.animator.SetBool("playerExit",true);
                    monster_Anime_Controller.animator.SetBool("Trace", true);
                }
            }
            else{
                monster_Anime_Controller.animator.SetBool("Trace", false);
            }
            if(hp <= 0){//죽음
                monster_Anime_Controller.Zombi_Dead();
                this.gameObject.GetComponent<Collider>().enabled = false;
                _isAlive = false;
                StartCoroutine(ResetHP());
                if(count_wait == false)
                {
                    StartCoroutine(MobCount());
                }
                StartCoroutine(MonsterPool.sharedInstance.ReturnMonsterAfterSeconds(this.gameObject, 3f));
        
                if(picker_wait == false){
                    picker_wait = true;
                    getKillReward.killReward();
                    itemDrop.dropItem();
                }
            }
            if (distance > return_pool_range && _isAlive == true){     // 거리 멀어지면 pool 반환                        
                StartCoroutine(MonsterPool.sharedInstance.ReturnMonsterAfterSeconds(this.gameObject, 3f));
                Debug.Log("거리 멀어져서 pool 반환");
            }
        }

        //플레이어 피격
        private void AtkToPlayer(){
            pdto.setCurrentHp((int)pdto.getCurrentHp()-atk);
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
                hp -= rwdto.getCurrentDamage();
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

        IEnumerator ResetHP()
        {
            yield return new WaitForSeconds(3f);
            hp = maxHP;
            _isAlive = true;
            this.gameObject.GetComponent<Collider>().enabled = true;
            //Debug.Log("리셋" + hp);
        }

        IEnumerator MobCount()
        {
            count_wait = true;
            pdto.setMobCount(pdto.getMobCount()+1); 
            Debug.Log("몹 카운트 : " + pdto.getMobCount());
            if(pdto.getMobCount() == 1)
            {
                Escape.instance.EscapeItemUpdate("quest(Clone)", 100);
            }
            yield return new WaitForSeconds(3f);
            count_wait = false;
        }

    }
}