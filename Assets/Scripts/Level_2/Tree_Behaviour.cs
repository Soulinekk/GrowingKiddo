using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Behaviour : MonoBehaviour {

    private int thirdStage = Animator.StringToHash("ThirdStage");
    private int secondStage = Animator.StringToHash("SecondStage");
    private int fallStage = Animator.StringToHash("FallStage");


    public void TreesThirdStage()
    {
        foreach (Transform child in transform)
        {
            StartCoroutine("LateThirdStage", child.gameObject);
        }
    }

    public void TreesSecoundStage()
    {
        foreach (Transform child in transform)
        {
            StartCoroutine("LateSecondStage", child.gameObject);
        }
    }

    public void TreesFallStage()
    {
        foreach (Transform child in transform)
        {
            StartCoroutine("LateFallStage", child.gameObject);
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

    private IEnumerator LateFallStage(GameObject tree)
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        Animator anim = tree.GetComponent<Animator>();
        anim.SetTrigger(fallStage);
    }
}
