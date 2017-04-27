using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1_Trees : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActiveTrigger(string triggerName)
    {
        GetComponent<Animator>().SetTrigger(triggerName);
    }
}
