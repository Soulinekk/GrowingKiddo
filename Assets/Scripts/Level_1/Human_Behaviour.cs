using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Behaviour : MonoBehaviour {

    private int Chopping = Animator.StringToHash("Chopchop");
    private int Bridge = Animator.StringToHash("Bridge");
    private int Bridge2 = Animator.StringToHash("Bridge2");
    private int win = Animator.StringToHash("Win");
    private int death = Animator.StringToHash("Death");

    public void ChopTrees()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(Chopping);
    }

    public void BuildBridge(int stageOfBuild)
    {
        if(stageOfBuild == 1)
        {
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger(Bridge);
        }
        else
        {
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger(Bridge2);
        }
    }

    public void PassBridgeWin()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(win);
    }

    public void PassBridgeLose()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(death);
    }
}
