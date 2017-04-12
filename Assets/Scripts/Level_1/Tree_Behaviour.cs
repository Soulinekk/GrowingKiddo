using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Behaviour : MonoBehaviour {

    private int thirdStage = Animator.StringToHash("ThirdStage");
    private int secondStage = Animator.StringToHash("SecondStage");


    void Start ()
    {

    }
	
	void Update ()
    {
		
	}

    private void TreesThirdStage()
    {
        foreach (Transform child in transform)
        {
            StartCoroutine("LateThirdStage", child.gameObject);
        }
    }

    private void TreesSecoundStage()
    {
        foreach (Transform child in transform)
        {
            StartCoroutine("LateSecondStage", child.gameObject);
        }
    }

    private IEnumerator LateThirdStage(GameObject tree)
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        Animator anim = tree.GetComponent<Animator>();
        anim.SetTrigger(thirdStage);
    }

    private IEnumerator LateSecondStage(GameObject tree)
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        Animator anim = tree.GetComponent<Animator>();
        anim.SetTrigger(secondStage);
    }
}
