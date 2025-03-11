using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDisMonAni : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GameObject.Find("LongDMonster(Clone)").GetComponent<Animator>();
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
