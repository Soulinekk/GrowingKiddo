﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_2 : MonoBehaviour {

    public GameObject bgEnviroment;
    public GameObject TreesActive;
    public GameObject treesPassive;


    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update()
    {
		
	}

    public void OnTurnOnGravity()
    {
        bgEnviroment.GetComponent<Rigidbody>().useGravity = true;
        Destroy(bgEnviroment, 6f);
    }

    public void SetParameter_Bool(string parameterName, bool value)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool(parameterName, value);
    }

    public void SetParameter_Int(string parameterName, int value)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetInteger(parameterName, value);
    }

    public void Bool_GravityOn()
    {
        GetComponent<Animator>().SetBool("GravityOn", true);
    }

    public void Trigger_OnTriggerActive(string triggerName)
    {
        GetComponent<Animator>().SetTrigger(triggerName);
    }

    public void Int_IceBlockStage(int value)
    {
        GetComponent<Animator>().SetInteger("IceBlockStage", value);
    }

    public void Int_TreesStage(int value)
    {
        GetComponent<Animator>().SetInteger("Trees_Stage", value);
    }

    public void Int_ShipStage(int value)
    {
        GetComponent<Animator>().SetInteger("Ship_Stage", value);
    }

    public void TurnOnTrees()
    {
        treesPassive.SetActive(true);
        TreesActive.SetActive(true);
    }
}
