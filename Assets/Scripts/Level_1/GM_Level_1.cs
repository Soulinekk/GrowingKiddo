using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_Level_1 : MonoBehaviour {
    
    public static class LvlInfo{
        
        public static int stage = 0;
        public static bool stageFinished = true;                                                            // Checking if current animations and interactions had finished

        #region Levels of things
        public static int river_lvl = -1;
        public static int trees_lvl = -1;
        public static int bear_lvl = -1;
        public static int wolfs_lvl = -1;
        public static int fishes_lvl = -1;
        public static int human_lvl = -1;
        public static int bridge_lvl = -1;
        #endregion

    }

    #region Objects on scene to interact with
    public GameObject bg_trees_Parent_Object;                                                               // Parent of trees in background
    public GameObject active_Trees_Parent_Object;                                                           // Trees player will interact with
    public GameObject bridge;
    public GameObject wolfs;
    public GameObject bear;
    public GameObject human;
    public GameObject tilts;
    public GameObject river;
    public GameObject fishes;
#endregion

    public GameObject[] _buttons;                                                                           // UI Buttons
    



    #region UI Buttons Behaviour
    public void OnItemActive_1()        // Tree
    {
        //if (LvlInfo.stageFinished)
        //{
            _buttons[0].GetComponent<Button>().interactable = false;
            LvlInfo.stage++;
            LvlInfo.trees_lvl = 0;
            StageStartup();
        //}  
    }

    public void OnItemActive_2()        // River
    {
        //if (LvlInfo.stageFinished)
        //{
            _buttons[1].GetComponent<Button>().interactable = false;
            LvlInfo.stage++;
            LvlInfo.river_lvl = 0;
            StageStartup();
        //}
    }

    public void OnItemActive_3()        // Wolf
    {
        //if (LvlInfo.stageFinished)
        //{
            _buttons[2].GetComponent<Button>().interactable = false;
            LvlInfo.stage++;
            LvlInfo.wolfs_lvl = 0;
            StageStartup();
        //}
    }

    public void OnItemActive_4()        // Bear
    {
        //if (LvlInfo.stageFinished)
        //{
            _buttons[3].GetComponent<Button>().interactable = false;
            LvlInfo.stage++;
            LvlInfo.bear_lvl = 0;
            StageStartup();
        //}
    }

    public void OnItemActive_5()        // Human
    {
        //if (LvlInfo.stageFinished)
        //{
            _buttons[4].GetComponent<Button>().interactable = false;
            LvlInfo.stage++;
            LvlInfo.human_lvl = 0;
            StageStartup();
        //}
    }

    public void OnItemActive_6()        // Fish
    {
        //if (LvlInfo.stageFinished)
        //{
            _buttons[5].GetComponent<Button>().interactable = false;
            LvlInfo.stage++;
            LvlInfo.fishes_lvl = 0;
            StageStartup();
        //}
    }
    #endregion

    void StageStartup()
    {
        HumanBehaviour();
        FishedBehaviour();
        TreesBehaviour();
        RiverBehaviour();
        WolfsBehaviour();
        Bearbehaviour();
    }

    #region On new stage behaviour

    void HumanBehaviour()
    {
        if (LvlInfo.trees_lvl == 3 && LvlInfo.human_lvl == 0)
        {
            LvlInfo.stageFinished = false;

            human.GetComponent<Human_Behaviour>().ChopTrees();
            LvlInfo.human_lvl = 1;
            LvlInfo.trees_lvl = 4;
        }
        else if (LvlInfo.trees_lvl == 4 && LvlInfo.human_lvl == 1)
        {
            LvlInfo.stageFinished = false;

            bridge.SetActive(true);
            human.GetComponent<Human_Behaviour>().BuildBridge();
            Destroy(active_Trees_Parent_Object.transform.GetChild(0));
            Destroy(active_Trees_Parent_Object.transform.GetChild(1));
            LvlInfo.human_lvl = 2;
            LvlInfo.bridge_lvl = 1;
        }
        else if (LvlInfo.bridge_lvl == 1 && LvlInfo.human_lvl == 2)
        {
            LvlInfo.stageFinished = false;

            bridge.GetComponent<Bridge_Behaviour>().SecondStage();
            Destroy(active_Trees_Parent_Object.transform.GetChild(2));
            LvlInfo.human_lvl = 3;
            LvlInfo.bridge_lvl = 2;
        }
        else if (LvlInfo.bridge_lvl == 2 && LvlInfo.human_lvl == 3)
        {
            LvlInfo.stageFinished = false;

            LvlInfo.human_lvl = 4;
            // if bear or wolf
        }
    }

    void RiverBehaviour()
    {
        if(LvlInfo.river_lvl == 0)
        {
            river.GetComponent<River_Behaviour>().Stage_1();
            LvlInfo.river_lvl = 1;
        }
        else if(LvlInfo.river_lvl == 1)
        {
            river.GetComponent<River_Behaviour>().Stage_2();
            LvlInfo.river_lvl = 2;
        }
    }

    void FishedBehaviour()
    {
        switch (LvlInfo.fishes_lvl)
        {
            case 0:
                if(LvlInfo.river_lvl != -1)
                {
                    fishes.SetActive(true);
                    LvlInfo.fishes_lvl = 1;
                }
                else
                {
                    LvlInfo.stageFinished = false;

                    fishes.transform.position = new Vector3(-8.82f, 1.6f, -4.65f);
                    fishes.SetActive(true);
                    fishes.GetComponent<Fishes_Behaviour>().SpawnWithoutRiver();
                    Destroy(fishes, 2f);
                    LvlInfo.fishes_lvl = -1;
                }
                break;

            case 1:
                if(fishes != null)
                {
                    LvlInfo.stageFinished = false;

                    fishes.GetComponent<Fishes_Behaviour>().SecondStage();
                    LvlInfo.fishes_lvl = 2;
                }
                break;

            case 2:
                if(fishes != null)
                {
                    LvlInfo.stageFinished = false;

                    fishes.GetComponent<Fishes_Behaviour>().ThirdStage();
                    LvlInfo.fishes_lvl = 3;
                }
                break;
        }
    }

    void TreesBehaviour()
    {
        switch (LvlInfo.trees_lvl)
        {
            case 0:
                LvlInfo.stageFinished = false;
                
                bg_trees_Parent_Object.SetActive(true);
                active_Trees_Parent_Object.SetActive(true);
                LvlInfo.trees_lvl = 1;
                break;

            case 1:
                if(LvlInfo.river_lvl == 2)
                {
                    LvlInfo.stageFinished = false;
                    
                    tilts.SetActive(false);
                    bg_trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesSecoundStage();
                    active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesSecoundStage();
                    LvlInfo.trees_lvl = 2;
                }
                break;

            case 2:
                LvlInfo.stageFinished = false;
                
                bg_trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesThirdStage();
                active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesThirdStage();
                LvlInfo.trees_lvl = 3;
                break;
        }
    }

    void WolfsBehaviour()
    {

    }

    void Bearbehaviour()
    {

    }
    
#endregion


}
