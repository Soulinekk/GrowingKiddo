using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour {

    #region Viarables
    private GameObject riverMainPart;
    private GameObject riverSecondPart;
    public Material waterMaterial;

#endregion

    // Use this for initialization
    void Start () {

        riverMainPart = transform.GetChild(1).gameObject;
        riverSecondPart = transform.GetChild(2).gameObject;
        Debug.Log("Delete 2 lines below");
        Stage_1();
        Stage_2();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Stage_1()
    {
        riverMainPart.transform.position = new Vector3(-0.1280411f, 2.41f, -0.36f);
        riverMainPart.GetComponent<Renderer>().material = waterMaterial;
    }

    public void Stage_2()
    {
        riverSecondPart.transform.position = new Vector3(-2.475322f, 2.83f, -10.70798f);
        riverSecondPart.GetComponent<Renderer>().material = waterMaterial;
        riverSecondPart.transform.rotation = Quaternion.Euler(-89.48f, 0f, 0f);
    }
}
