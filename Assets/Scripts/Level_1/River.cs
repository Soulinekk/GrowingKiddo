using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour {

    #region Viarables
    private GameObject[] riverParts;
    public Material waterMaterial;

#endregion
    
    void Start () {

        riverParts = new GameObject[transform.childCount];
        riverParts[0] = gameObject.transform.GetChild(0).gameObject;                        // River bigger part
        riverParts[1] = gameObject.transform.GetChild(1).gameObject;                        // River smaller part
        riverParts[2] = transform.GetChild(2).gameObject;                                   // Waterfall
	}
	
	void Update () {
		
	}

    public void Stage_1()
    {
        
        riverParts[0].transform.position = new Vector3(-0.1280411f, -0.66f, -0.3624908f);
        riverParts[0].GetComponent<Renderer>().material = waterMaterial;
    }

    public void Stage_2()
    {
        riverParts[1].transform.position = new Vector3(-2.72287f, -0.26f, -10.24156f);
        riverParts[1].GetComponent<Renderer>().material = waterMaterial;
        riverParts[1].transform.rotation = Quaternion.Euler(-89.19f, 0f, 0f);
        riverParts[2].SetActive(true);
    }
}
