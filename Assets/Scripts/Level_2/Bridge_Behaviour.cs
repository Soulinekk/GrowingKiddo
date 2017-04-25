using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Behaviour : MonoBehaviour {
   

    public void SecondStage()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
