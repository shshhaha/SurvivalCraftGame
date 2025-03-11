using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushMAni1 : MonoBehaviour
{

    public Animator animator;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance <= 12f)
        {
            smoothAniT();
            animator.SetBool("IsRushChase", true);
        }
        else
        {
            animator.SetBool("IsRushChase", false);
        }
        IEnumerator smoothAniT()
        {
            animator.SetBool("RushChaseTrans", true);
            yield return new WaitForSeconds(0.2f);
        }
        IEnumerator smoothAniF()
        {
            animator.SetBool("RushChaseTrans", false);
            yield return new WaitForSeconds(0.2f);

        }
    }
}