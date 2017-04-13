using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear_Behaviour : MonoBehaviour
{



    public void BearAttackHuman(int stage)
    {
        switch (stage)
        {
            case 1:
                Debug.Log("BearAttackHuman stage 1");
                break;

            case 2:
                Debug.Log("BearAttackHuman stage 1");
                break;
        }
    }

    public void BearAttackWolfs(int stage)
    {
        switch (stage)
        {
            case 1:
                Debug.Log("BearAttackWolfs stage 1");
                break;

            case 2:

                Debug.Log("BearAttackWolfs stage 2");

                break;
        }
    }

    public void BearGoingForFishes(int stage)
    {
        switch (stage)
        {
            case 1:

                Debug.Log("BearGoingForFishes stage 1");
                break;

            case 2:
                Debug.Log("BearGoingForFishes stage 1");
                break;
            case 3:
                Debug.Log("BearGoingForFishes stage 1");
                break;
        }
    }
}