using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Behaviour : MonoBehaviour {



    public void ChopTrees()
    {
        Debug.Log("Human chopping trees");
    }

    public void BuildBridge()
    {
        Debug.Log("Human build bridge");
    }

    public void PassBridgeWin()
    {
        Debug.Log("Human pass bridge - WIN");
    }

    public void PassBridgeLose()
    {
        Debug.Log("Human pass bridge - LOSE");
    }
}
