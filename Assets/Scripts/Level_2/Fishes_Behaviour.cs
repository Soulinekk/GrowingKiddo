using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishes_Behaviour : MonoBehaviour {

    private int thirdStage = Animator.StringToHash("ThirdStage");
    private int secondStage = Animator.StringToHash("SecondStage");
    private int forthStage = Animator.StringToHash("ForthStage");
    private int deadSpawn = Animator.StringToHash("DeadSpawn");


    public void SecondStage()
    {
        Animator anim = this.GetComponent<Animator>();
        anim.SetTrigger(secondStage);
    }

    public void ThirdStage()
    {
        Animator anim = this.GetComponent<Animator>();
        anim.SetTrigger(thirdStage);
    }

    public void ForthStage()
    {
        Animator anim = this.GetComponent<Animator>();
        anim.SetTrigger(forthStage);
    }

    public void SpawnWithoutRiver()
    {
        Animator anim = this.GetComponent<Animator>();
        anim.SetTrigger(deadSpawn);
    }
}
