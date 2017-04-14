using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfs_Behaviour : MonoBehaviour {

    private int firstStage = Animator.StringToHash("FirstStage");
    private int secondStage = Animator.StringToHash("SecondStage");

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

    public void ThirdStage()  // do i even need this one?
    {
        Debug.Log("Wolfs_Third_Stage animation");
    }
}
