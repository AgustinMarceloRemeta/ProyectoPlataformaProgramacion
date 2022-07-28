using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : StateMachineBehaviour
{
    [SerializeField] float Cd, CdWin;
    float Cd2;
    public int attack;
    [SerializeField] int Attacks;
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attack = Random.Range(0, Attacks);
        animator.SetInteger("Type",attack);
        Cd2 = Cd;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Cd -= Time.deltaTime;
        CdWin -= Time.deltaTime;
        if (Cd <= 0) animator.SetTrigger("Attack");
        if (CdWin <= 0) animator.SetBool("Win", true);
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        Cd = Cd2;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
