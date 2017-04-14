using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_Level_1 : MonoBehaviour {
    
    public static class LvlInfo{
        
        public static int stage = 0;
        public static bool stageFinished = true;                                                            // Checking if current animations and interactions had finished

        public static bool fishes_eaten = false;

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


    private void Start()
    {
        LvlInfo.fishes_eaten = false;
        LvlInfo.stageFinished = true;
        LvlInfo.river_lvl = -1;
        LvlInfo.trees_lvl = -1;
        LvlInfo.bear_lvl = -1;
        LvlInfo.wolfs_lvl = -1;
        LvlInfo.fishes_lvl = -1;
        LvlInfo.human_lvl = -1;
        LvlInfo.bridge_lvl = -1;
    }


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
        RiverBehaviour();                               // This stage call another, when its finished, and so on.
    }

    #region On new stage behaviour
    void HumanBehaviour()
    {
        if (LvlInfo.human_lvl == 0)
        {
            human.SetActive(true);
            LvlInfo.human_lvl = 1;
        }

        if (LvlInfo.trees_lvl == 3 && LvlInfo.human_lvl == 1)
        {
            LvlInfo.stageFinished = false;

            human.GetComponent<Human_Behaviour>().ChopTrees();
            active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesFallStage();
            LvlInfo.human_lvl = 1;
            LvlInfo.trees_lvl = 4;
        }
        else if (LvlInfo.trees_lvl == 4 && LvlInfo.human_lvl == 1)
        {
            LvlInfo.stageFinished = false;

            bridge.SetActive(true);
            human.GetComponent<Human_Behaviour>().BuildBridge();
            Destroy(active_Trees_Parent_Object.transform.GetChild(1).gameObject);
            Destroy(active_Trees_Parent_Object.transform.GetChild(0).gameObject);
            LvlInfo.human_lvl = 2;
            LvlInfo.bridge_lvl = 1;
        }
        else if (LvlInfo.bridge_lvl == 1 && LvlInfo.human_lvl == 2)
        {
            LvlInfo.stageFinished = false;

            bridge.GetComponent<Bridge_Behaviour>().SecondStage();
            Destroy(active_Trees_Parent_Object.transform.GetChild(0).gameObject);
            LvlInfo.human_lvl = 3;
            LvlInfo.bridge_lvl = 2;
        }
        else if (LvlInfo.bridge_lvl == 2 && LvlInfo.human_lvl == 3)
        {
            LvlInfo.stageFinished = false;

            LvlInfo.human_lvl = 4;
            // if bear or wolf
        }

        FishesBehaviour();
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

        TreesBehaviour();
    }

    void FishesBehaviour()
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
                if(LvlInfo.fishes_eaten == false)
                {
                    LvlInfo.stageFinished = false;

                    fishes.GetComponent<Fishes_Behaviour>().SecondStage();
                    LvlInfo.fishes_lvl = 2;
                }
                break;

            case 2:
                if(LvlInfo.fishes_eaten == false)
                {
                    LvlInfo.stageFinished = false;

                    fishes.GetComponent<Fishes_Behaviour>().ThirdStage();
                    LvlInfo.fishes_lvl = 3;
                }
                break;

            case 3: 
                if(LvlInfo.fishes_eaten == false)
                {
                    LvlInfo.stageFinished = false;

                    fishes.GetComponent<Fishes_Behaviour>().ForthStage();
                    Destroy(fishes, 2f);
                    LvlInfo.fishes_lvl = 4;
                }
                break;
        }

        BearBehaviour();
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

        HumanBehaviour();
    }

    void WolfsBehaviour()
    {
        if (LvlInfo.wolfs_lvl == 0)
        {
            wolfs.SetActive(true);
            LvlInfo.wolfs_lvl = 1;
        }
        else if(LvlInfo.wolfs_lvl == 1)
        {
            wolfs.GetComponent<Wolfs_Behaviour>().SecondStage();
            LvlInfo.wolfs_lvl = 2;
        }
        else if(LvlInfo.wolfs_lvl == 2)
        {
            wolfs.GetComponent<Wolfs_Behaviour>().FirstStage();
            LvlInfo.wolfs_lvl = 2;
        }


    }

    void BearBehaviour()
    {
        if (LvlInfo.bear_lvl == 0)
        {
            bear.SetActive(true);
            LvlInfo.bear_lvl = 1;
        }

        switch (LvlInfo.bear_lvl)
        {
            #region Case 1: Bear_Lvl == 1
            case 1:
                if (LvlInfo.fishes_lvl == 3)                                                            // bear lv == 1 && fishes lv == 3
                {
                    LvlInfo.stageFinished = false;

                    bear.GetComponent<Bear_Behaviour>().BearGoingForFishes(3);
                    LvlInfo.fishes_eaten = true;
                    LvlInfo.bear_lvl = 6;
                }
                else if(LvlInfo.wolfs_lvl == 2)                                                         // Bear lv == 1 && wolfs lv == 2
                {
                    LvlInfo.stageFinished = false;

                    bear.GetComponent<Bear_Behaviour>().BearAttackWolfs(2);
                    LvlInfo.bear_lvl = 2;
                    LvlInfo.wolfs_lvl = 3;
                }

                if (LvlInfo.human_lvl == 4)                                                             // Bear lv == (1 or 2) && Human lv == 4
                {
                    if(LvlInfo.bear_lvl == 1)
                    {
                        LvlInfo.stageFinished = false;

                        bear.GetComponent<Bear_Behaviour>().BearAttackHuman(1);
                        LvlInfo.bear_lvl = 7;
                    }
                    else if (LvlInfo.bear_lvl == 2)
                    {
                        LvlInfo.stageFinished = false;

                        bear.GetComponent<Bear_Behaviour>().BearAttackHuman(2);
                        LvlInfo.bear_lvl = 7;
                    }
                }

                if (LvlInfo.bear_lvl == 1)
                {
                    LvlInfo.stageFinished = false;

                    bear.GetComponent<Bear_Behaviour>().BearSecondStage();
                    LvlInfo.bear_lvl = 2;
                }
                break;
#endregion

            case 2:

                #region Case 2: Bear_Lvl == 2
                if(LvlInfo.human_lvl == 4)
                {
                    LvlInfo.stageFinished = false;

                    bear.GetComponent<Bear_Behaviour>().BearAttackHuman(2);
                    LvlInfo.bear_lvl = 7;
                }
                else if(LvlInfo.fishes_lvl == 2)
                {
                    bear.GetComponent<Bear_Behaviour>().BearGoingForFishes(2);
                    LvlInfo.bear_lvl = 5;
                }
                else
                {
                    bear.GetComponent<Bear_Behaviour>().BearThirdStage();
                    LvlInfo.bear_lvl = 3;
                    if(LvlInfo.wolfs_lvl == 1)
                    {
                        wolfs.GetComponent<Wolfs_Behaviour>().SecondStage();
                        LvlInfo.wolfs_lvl = 2;
                    }
                }
                break;
                #endregion

            case 3:

                break;
        }

        WolfsBehaviour();
    }
#endregion

    public void OnRetryButtonPress()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
