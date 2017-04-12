using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_Level_1 : MonoBehaviour {
    
    public static class LvlInfo{
        
        public static int stage = 0;

        #region Levels of things
        public static int river_lvl = 0;
        public static int trees_lvl = 0;
        public static int bear_lvl = 0;
        public static int wolfs_lvl = 0;
        public static int fishes_lvl = 0;
        #endregion

        public static bool bridgeConstructed = false;

    }

    public GameObject[] _buttons;                                                                           // UI Buttons
    public GameObject bg_trees_Parent_Object;                                                               // Parent of trees in background
    public GameObject active_Trees_Parent_Object;
    private bool stageFinished = true;                                                                      // Checking if current animations and interactions had finished
    


    void Start ()
    {
        
	}
	
	void Update ()
    {

	}


    #region UI Buttons Behaviour
    public void OnItemActive_1()                                                                            // Tree
    {
        if (stageFinished)
        {
            _buttons[0].GetComponent<Button>().interactable = false;

        }  
    }

    public void OnItemActive_2()                                                                            // 
    {
        if (stageFinished)
        {
            _buttons[1].GetComponent<Button>().interactable = false;
        }
    }

    public void OnItemActive_3()                                                                            // 
    {
        if (stageFinished)
        {
            _buttons[2].GetComponent<Button>().interactable = false;
        }
    }

    public void OnItemActive_4()                                                                            // 
    {
        if (stageFinished)
        {
            _buttons[3].GetComponent<Button>().interactable = false;
        }
    }

    public void OnItemActive_5()                                                                            // 
    {
        if (stageFinished)
        {
            _buttons[4].GetComponent<Button>().interactable = false;
        }
    }

    public void OnItemActive_6()                                                                            // 
    {
        if (stageFinished)
        {
            _buttons[5].GetComponent<Button>().interactable = false;
        }
    }
#endregion
}
