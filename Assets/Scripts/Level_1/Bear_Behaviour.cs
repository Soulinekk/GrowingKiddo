using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear_Behaviour : MonoBehaviour
{

    private int secondStage = Animator.StringToHash("SecondStage");                                 // Its also Wolfs Attack animation
    private int thirdStage = Animator.StringToHash("ThirdStage");                                   // Its also Wolfs Attack animation 
    private int forthStage = Animator.StringToHash("ForthStage");
    private int fifthStage = Animator.StringToHash("FifthStage");
    private int sixthStage = Animator.StringToHash("SixhStage");
    private int sixthToSecond = Animator.StringToHash("SixthToSecond");
    private int fifthToSecond = Animator.StringToHash("FifthToSecond");
    private int forthToThird = Animator.StringToHash("ForthToThird");
    private int thirdToSecond = Animator.StringToHash("ThirdToSecond");
    private int humanAttackFromFirstStage = Animator.StringToHash("Attack1");
    private int humanAttackFromSecondStage = Animator.StringToHash("Attack2");


    public void BearAttackHuman(int BearStance)
    {
        switch (BearStance)
        {
            case 1:
                AttackFromFirstStage();
                break;

            case 2:
                AttackFromSecondStage();
                break;
        }
    }

    public void BearAttackWolfs(int wolfsStage)
    {
        switch (wolfsStage)
        {
            case 1:
                ThirdStage();
                break;

            case 2:
                SecondStage();
                break;
        }
    }

    public void BearGoingForFishes(int FishesStage)
    {
        switch (FishesStage)
        {
            case 1:
                SixthStage();
                break;

            case 2:
                FifthStage();
                break;
            case 3:
                ForthStage();
                break;
        }
    }

    public void SecondStage()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(secondStage);
    }

    public void ThirdStage()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(thirdStage);
    }

    public void ForthStage()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(forthStage);
    }

    public void FifthStage()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(fifthStage);
    }

    public void SixthStage()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(sixthStage);
    }

    public void SixthToSecond()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(sixthToSecond);
    }

    public void FifthToSecond()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(fifthToSecond);
    }

    public void ForthToThird()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(forthToThird);
    }

    public void ThirdToSecond()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(thirdToSecond);
    }

    public void AttackFromFirstStage()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(humanAttackFromFirstStage);
    }

    public void AttackFromSecondStage()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(humanAttackFromSecondStage);
    }
}