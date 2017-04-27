using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour {

    public GameObject tilt;
    public Level_2 lvl2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    /// <summary>
    /// Turns on ice block's falling animation
    /// </summary>
    public void DestroyRockTilt()
    {
        Destroy(tilt);
    }

    public void WinGame()
    {
        lvl2.shipAnimator.SetTrigger("FlyAway");
    }
}
