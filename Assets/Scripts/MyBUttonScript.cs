using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MyBUttonScript : MonoBehaviour, IPointerClickHandler
{

	public Text label;

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("!!");
	}


}
