using UnityEngine;
using DTO.TimerDTO;
public class M_Spanwer : MonoBehaviour
{
    private TimerDTO tmr;
    public Transform[] spawnPoint;
    public static int numberOfMonster_1 = 0;
    public int MaxMonster;
    public float spownDelay;
    float spownTimer = 0f;
    
    public GameObject mob;
    public Transform zombiepos;
    void Start()
    {
        tmr = TimerDTO.Instance;
    }
    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();//스폰 포인트로 지정된 위치에서 몹 스폰
    }
    void FixedUpdate()
    {
        spownTimer += Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        if((tmr.getHour() >= 6 || tmr.getHour() < 18) && numberOfMonster_1 < MaxMonster){
            if(spownTimer > spownDelay){
                Debug.Log("Spawn");
                //GameObject monster = F_GameManager.instance.pool.Mon(0); //몹 여러개 할려면 M_pool에 몹 추가해서 랜덤으로 뽑아야함
                //monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
                GameObject intantMob = Instantiate(mob, zombiepos.position, zombiepos.rotation);
                numberOfMonster_1++;
                spownTimer = 0f;
            }
        }
    }
}
