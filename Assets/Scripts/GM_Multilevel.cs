using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_Multilevel : MonoBehaviour {

    public GameObject[] buttonsOfObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadSceneById(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void OnButtonPress()
    {
        GameObject.Find("Scene").GetComponent<Animator>().SetTrigger("NewStage");
    }

    void ActiveButtons(bool active)
    {
        if(active == true)
        {
            foreach (GameObject button in buttonsOfObjects)
            {
                button.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject button in buttonsOfObjects)
            {
                button.SetActive(false);
            }
        }
    }
    

    private void SetLevelsOfObject()
    {

    }

    public void GameOver()
    {

    }

    public void YouWin()
    {

    }
}
