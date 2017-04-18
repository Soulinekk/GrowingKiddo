using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfs_Behaviour : MonoBehaviour {

    private int firstStage = Animator.StringToHash("FirstStage");
    private int secondStage = Animator.StringToHash("SecondStage");
    private int thirdStage = Animator.StringToHash("ThirdStage");

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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

    public void ThirdStage()  // do i even need this one? yes i do
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(thirdStage);
    }

    public void WolfsAttackingHuman()
    {
        Debug.Log("Wolfs attacing human, Game Over");
    }
}
