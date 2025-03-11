using UnityEngine;

public class Monster_Anime_Controller : MonoBehaviour
{   
    public Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
    public void IdleType(){
        int type = Random.Range(0, 3);
        animator.SetInteger("IdleType", type);
        animator.SetBool("Trace", false);
    }
    public void MonsterTrace(){
        animator.SetBool("Trace", true);
    }
    public void MonsterAttack(){
        animator.SetTrigger("Zombi_Attack");
    }
    public void Zombi_Dead(){
        animator.SetTrigger("Zombi_Dead");
    }
}
