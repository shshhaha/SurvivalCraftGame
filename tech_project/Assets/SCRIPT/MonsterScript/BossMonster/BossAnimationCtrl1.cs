using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationCtrl1 : MonoBehaviour
{
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("BossMonster1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void bossIdle()
    {
        animator.SetBool("BossIdle", true);
        animator.SetBool("BossWalk", false);
        animator.SetBool("BossAttack", false);
        animator.SetBool("BossDeath", false);
    }

    public void bossWalk()
    {
        animator.SetBool("BossIdle", false);
        animator.SetBool("BossWalk", true);
        animator.SetBool("BossAttack", false);
        animator.SetBool("BossDeath", false);
    }
    public void bossAttack()
    {
        animator.SetBool("BossIdle", false);
        animator.SetBool("BossWalk", false);
        animator.SetBool("BossAttack", true);
        animator.SetBool("BossDeath", false);
    }

    public void bossDead()
    {
        animator.SetBool("BossIdle", false);
        animator.SetBool("BossWalk", false);
        animator.SetBool("BossAttack", false);
        animator.SetBool("BossDeath", true);
    }

}