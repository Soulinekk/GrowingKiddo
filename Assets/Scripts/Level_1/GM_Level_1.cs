using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_Level_1 : MonoBehaviour {
    
    public static class LvlInfo{
        
        public static bool stageFinished = true;     

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
    public GameObject wonScreen;
    public GameObject lostScreen;
    public GameObject[] _buttonsOrder;
    private int order = 0;
    private bool wolfsAlreadyMoved = false;


    private void Start()
    {
        LvlInfo.stageFinished = true;
        LvlInfo.river_lvl = -1;
        LvlInfo.trees_lvl = -1;
        LvlInfo.bear_lvl = -1;
        LvlInfo.wolfs_lvl = -1;
        LvlInfo.fishes_lvl = -1;
        LvlInfo.human_lvl = -1;
        LvlInfo.bridge_lvl = -1;
        order = 0;
        wolfsAlreadyMoved = false;
    }


    #region UI Buttons Behaviour
    public void OnItemActive_1()        // Tree
    {
        //if (LvlInfo.stageFinished)
        //{
        _buttons[0].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[0].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[0].SetActive(true);
        LvlInfo.trees_lvl = 0;
        StageStartup();
        //}  
    }

    public void OnItemActive_2()        // River
    {
        //if (LvlInfo.stageFinished)
        //{
        _buttons[1].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[1].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[1].SetActive(true);
        LvlInfo.river_lvl = 0;
        StageStartup();
        //}
    }

    public void OnItemActive_3()        // Wolf
    {
        //if (LvlInfo.stageFinished)
        //{
        _buttons[2].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[2].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[2].SetActive(true);
        LvlInfo.wolfs_lvl = 0;
        StageStartup();
        //}
    }

    public void OnItemActive_4()        // Bear
    {
        //if (LvlInfo.stageFinished)
        //{
        _buttons[3].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[3].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[3].SetActive(true);
        LvlInfo.bear_lvl = 0;
        StageStartup();
        //}
    }

    public void OnItemActive_5()        // Human
    {
        //if (LvlInfo.stageFinished)
        //{
        _buttons[4].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[4].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[4].SetActive(true);
        LvlInfo.human_lvl = 0;
        StageStartup();
        //}
    }

    public void OnItemActive_6()        // Fish
    {
        //if (LvlInfo.stageFinished)
        //{
        _buttons[5].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[5].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[5].SetActive(true);
        LvlInfo.fishes_lvl = 0;
        StageStartup();
        //}
    }
    #endregion

    void StageStartup()
    {
        RiverBehaviour();                               // This stage call another, when its finished, and so on.
    }
    
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
            human.GetComponent<Human_Behaviour>().BuildBridge(1);
            Destroy(active_Trees_Parent_Object.transform.GetChild(1).gameObject, 1f);
            Destroy(active_Trees_Parent_Object.transform.GetChild(0).gameObject, 1f);
            LvlInfo.human_lvl = 2;
            LvlInfo.bridge_lvl = 1;
        }
        else if (LvlInfo.bridge_lvl == 1 && LvlInfo.human_lvl == 2)
        {
            LvlInfo.stageFinished = false;

            human.GetComponent<Human_Behaviour>().BuildBridge(2);
            bridge.GetComponent<Bridge_Behaviour>().SecondStage();
            Destroy(active_Trees_Parent_Object.transform.GetChild(0).gameObject);
            LvlInfo.human_lvl = 3;
            LvlInfo.bridge_lvl = 2;
        }

        if (LvlInfo.bridge_lvl == 2 && LvlInfo.human_lvl == 3)
        {
            if (LvlInfo.wolfs_lvl == 2 || LvlInfo.bear_lvl == 2)
            {
                LvlInfo.human_lvl = 4;
                human.GetComponent<Human_Behaviour>().PassBridgeLose();
                GameOver();
            }
            else
            {
                LvlInfo.human_lvl = 5;
                human.GetComponent<Human_Behaviour>().PassBridgeWin();
            }
        }
        if(order ==6 && LvlInfo.human_lvl < 4)
        {
            GameOver();
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

        FishesBehaviour();
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
                LvlInfo.stageFinished = false;

                fishes.GetComponent<Fishes_Behaviour>().SecondStage();
                LvlInfo.fishes_lvl = 2;
                break;

            case 2:
                LvlInfo.stageFinished = false;

                fishes.GetComponent<Fishes_Behaviour>().ThirdStage();
                LvlInfo.fishes_lvl = 3;
                break;

            case 3: 
                LvlInfo.stageFinished = false;

                fishes.GetComponent<Fishes_Behaviour>().ForthStage();
                Destroy(fishes, 2f);
                LvlInfo.fishes_lvl = 4;
                break;
        }

        TreesBehaviour();
    } 

    void TreesBehaviour()
    {
        if(LvlInfo.trees_lvl == 0)
        {
            bg_trees_Parent_Object.SetActive(true);
            active_Trees_Parent_Object.SetActive(true);
            LvlInfo.trees_lvl = 1;
        }
        
        if(LvlInfo.trees_lvl == 1 && LvlInfo.river_lvl == 2)
        {
            tilts.SetActive(false);
            bg_trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesSecoundStage();
            active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesSecoundStage();
            LvlInfo.trees_lvl = 2;
        } 
        else if(LvlInfo.trees_lvl == 2)
        {
            bg_trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesThirdStage();
            active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesThirdStage();
            LvlInfo.trees_lvl = 3;
        }

        BearBehaviour();
    }

    void WolfsBehaviour()
    {
        if (wolfsAlreadyMoved == false)
        {
            if (LvlInfo.wolfs_lvl == 0)
            {
                wolfs.SetActive(true);
                LvlInfo.wolfs_lvl = 1;
            }
            else if (LvlInfo.wolfs_lvl == 1 && LvlInfo.bear_lvl != 2)
            {
                wolfs.GetComponent<Wolfs_Behaviour>().SecondStage();
                LvlInfo.wolfs_lvl = 2;
            }
            wolfsAlreadyMoved = false;
        }
        HumanBehaviour();
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
                if (LvlInfo.fishes_lvl == 3)                    // bear vs fishes(3)
                {
                    LvlInfo.stageFinished = false;

                    bear.GetComponent<Bear_Behaviour>().BearGoingForFishes(3);
                    LvlInfo.bear_lvl = 6;
                }
                else if(LvlInfo.wolfs_lvl == 2)                 
                {
                    if(LvlInfo.human_lvl == 4)                  // bear(1) attack human 
                    {
                        LvlInfo.stageFinished = false;

                        bear.GetComponent<Bear_Behaviour>().AttackFromFirstStage();
                        LvlInfo.bear_lvl = 7;
                        GameOver();
                    }
                    else                                        // bear vs wolfs(2)
                    {
                        wolfs.GetComponent<Wolfs_Behaviour>().ThirdStage();
                        bear.GetComponent<Bear_Behaviour>().BearAttackWolfs(2);
                        LvlInfo.wolfs_lvl = 3;
                        LvlInfo.bear_lvl = 2;
                        if (LvlInfo.fishes_lvl == 2)
                        {
                            bear.GetComponent<Bear_Behaviour>().BearGoingForFishes(2);
                            LvlInfo.bear_lvl = 5;
                        }
                    }
                }
                else if (LvlInfo.human_lvl == 4)                // Bear lv == (1 or 2) && Human lv == 4
                {
                    bear.GetComponent<Bear_Behaviour>().BearAttackHuman(1);
                    LvlInfo.bear_lvl = 7;
                    GameOver();
                }
                else
                {
                    bear.GetComponent<Bear_Behaviour>().SecondStage();
                    LvlInfo.bear_lvl = 2;
                }
                break;
#endregion

            #region Case 2: Bear_Lvl == 2
            case 2:

                if (LvlInfo.fishes_lvl == 2)
                {
                    bear.GetComponent<Bear_Behaviour>().BearGoingForFishes(2);
                    LvlInfo.bear_lvl = 5;
                }
                else if (LvlInfo.human_lvl == 4)
                {
                    bear.GetComponent<Bear_Behaviour>().BearAttackHuman(2);
                    LvlInfo.bear_lvl = 7;
                    GameOver();
                }
                else if (LvlInfo.wolfs_lvl == 1)
                {
                    LvlInfo.wolfs_lvl = 2;
                    wolfs.GetComponent<Wolfs_Behaviour>().SecondStage();
                    wolfsAlreadyMoved = true;
                    LvlInfo.bear_lvl = 3;
                    bear.GetComponent<Bear_Behaviour>().ThirdStage();
                }
                else
                {
                    bear.GetComponent<Bear_Behaviour>().ThirdStage();
                    LvlInfo.bear_lvl = 3;
                }
                break;
            #endregion

            #region Case 3: Bear_Lvl == 3
            case 3:
                if (LvlInfo.fishes_lvl == 3)
                {
                    bear.GetComponent<Bear_Behaviour>().BearGoingForFishes(1);
                    LvlInfo.bear_lvl = 4;
                }
                else if(LvlInfo.wolfs_lvl == 2)
                {
                    wolfs.GetComponent<Wolfs_Behaviour>().ThirdStage();
                    LvlInfo.wolfs_lvl = 3;
                    bear.GetComponent<Bear_Behaviour>().ThirdToSecond();
                    LvlInfo.bear_lvl = 2;
                }
                else
                {
                    bear.GetComponent<Bear_Behaviour>().ThirdToSecond();
                    LvlInfo.bear_lvl = 2;
                }
                break;
            #endregion

            #region Case 4: Bear_Lvl == 4
            case 4:
                if(LvlInfo.wolfs_lvl == 1)
                {
                    wolfs.GetComponent<Wolfs_Behaviour>().SecondStage();
                    LvlInfo.wolfs_lvl = 2;
                    wolfsAlreadyMoved = true;
                }
                bear.GetComponent<Bear_Behaviour>().ForthToThird();
                LvlInfo.bear_lvl = 3;
                break;
            #endregion

            #region Case 5: Bear_Lvl == 5
            case 5:
                if(LvlInfo.wolfs_lvl == 2)
                {
                    wolfs.GetComponent<Wolfs_Behaviour>().ThirdStage();
                    LvlInfo.wolfs_lvl = 3;
                }
                bear.GetComponent<Bear_Behaviour>().FifthToSecond();
                LvlInfo.bear_lvl = 2;
                break;
            #endregion

            #region Case 6: Bear_Lvl == 6
            case 6:
                if (LvlInfo.wolfs_lvl == 2)
                {
                    wolfs.GetComponent<Wolfs_Behaviour>().ThirdStage();
                    LvlInfo.wolfs_lvl = 3;
                }
                bear.GetComponent<Bear_Behaviour>().SixthToSecond();
                LvlInfo.bear_lvl = 2;
                break;
#endregion
        }

        WolfsBehaviour();
    }

    public void OnRetryButtonPress()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        lostScreen.SetActive(true);
    }
}
