using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfs_Behaviour : MonoBehaviour {

    private int firstStage = Animator.StringToHash("FirstStage");
    private int secondStage = Animator.StringToHash("SecondStage");
    private int attack = Animator.StringToHash("Attack");


    public void FirstStage()
    {
        Animator anim = this.GetComponent<Animator>();
        anim.SetTrigger(firstStage);
    }

    public void SecondStage()
    {
        Animator anim = this.GetComponent<Animator>();
        anim.SetTrigger(secondStage);
    }

    public void WolfsAttackingHuman()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(attack);
    }
}
