using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GM_Multilevel : MonoBehaviour {

    public List<GameObject> buttonsOfObjects = new List<GameObject>();
    public GameObject winScreen;
    public GameObject loseScreen;
    
    private bool buttonsActive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel(int level_id)
    {
        SceneManager.LoadScene(level_id);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ActiveButtons()
    {
        if(buttonsActive == false)
        {
            buttonsActive = true;
            foreach (GameObject button in buttonsOfObjects)
            {
                button.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            buttonsActive = false;
            foreach (GameObject button in buttonsOfObjects)
            {
                button.GetComponent<Button>().interactable = false;
            }
        }
    }
    

    private void SetLevelsOfObject()
    {

    }

    public void GameOver()
    {
        loseScreen.SetActive(true);
    }

    public void YouWin()
    {
        winScreen.SetActive(true);
    }

    public void OnButtonPress(string triggerToActive)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger(triggerToActive);
        NewStageTrigger();
    }

    public void DisableButton(int id)
    {
        for (int i = 0; i < buttonsOfObjects.Count; i++)
        {
            if (buttonsOfObjects[i].GetComponent<ButtonsId>().id == id)
            {
                buttonsOfObjects[i].GetComponent<Button>().interactable = false;
                buttonsOfObjects.RemoveAt(i);
            }
        }
    }

    public void NewStageTrigger()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("NewStage");
    }
}
