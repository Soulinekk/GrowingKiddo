using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_Level_1 : MonoBehaviour {

    public static int thinsToFinish;

    #region Levels of things
    int river_lvl;
    int trees_lvl;
    int bear_lvl;
    int wolfs_lvl;
    int fishes_lvl;
    int human_lvl;

    int r_lvl;
    int f_lvl;
    int t_lvl;
    int b_lvl;
    int w_lvl;
    int h_lvl;
    #endregion

    #region Things
    public GameObject bg_trees_Parent_Object;
    public GameObject active_Trees_Parent_Object;
    public GameObject wolfs;
    public GameObject bear;
    public GameObject human;
    public GameObject river;
    public GameObject fishes;
    public GameObject tilts;
    public GameObject bridge;
#endregion

    #region UI things
    public GameObject wonScreen;
    public GameObject lostScreen;
    public GameObject[] _buttons;
    public GameObject[] _buttonsOrder;
    public GameObject[] _objectsLevels;
    public GameObject[] _scoreMaxedFrame;
    public GameObject[] _lvlUpPlaceHolders;
    public GameObject lvlUpText;
    private int order = 0;
#endregion

    private bool wolfsAlreadyMoved = false;

    // Use this for initialization
    void Start () {
        river_lvl = -1;
        trees_lvl = -1;
        bear_lvl = -1;
        wolfs_lvl = -1;
        fishes_lvl = -2;
        human_lvl = -1;
        order = 0;
        wolfsAlreadyMoved = false;
    }

    #region UI Buttons Behaviour
    public void OnItemActive_1()        // Tree
    {
        _buttons[0].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[0].GetComponent<Text>().text = order.ToString();
        trees_lvl = 0;
        StageStartup();
    }

    public void OnItemActive_2()        // River
    {
        _buttons[1].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[1].transform.GetComponent<Text>().text = order.ToString();
        river_lvl = 0;
        StageStartup();
    }

    public void OnItemActive_3()        // Wolf
    {
        _buttons[2].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[2].GetComponent<Text>().text = order.ToString();
        wolfs_lvl = 0;
        StageStartup();
    }

    public void OnItemActive_4()        // Bear
    {
        _buttons[3].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[3].GetComponent<Text>().text = order.ToString();
        bear_lvl = 0;
        StageStartup();
    }

    public void OnItemActive_5()        // Human
    {
        _buttons[4].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[4].GetComponent<Text>().text = order.ToString();
        human_lvl = 0;
        StageStartup();
    }

    public void OnItemActive_6()        // Fish
    {
        _buttons[5].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[5].GetComponent<Text>().text = order.ToString();
        fishes_lvl = -1;
        StageStartup();
    }
    #endregion

    void StageStartup()
    {
        RiverBehaviour();                               // This stage call another, when its finished, and so on.
    }

    void RiverBehaviour()
    {
        if (river_lvl == 0)
        {
            river.GetComponent<River_Behaviour>().Stage_1();
            river_lvl = 1;
            r_lvl = 1;
            _objectsLevels[1].GetComponent<Text>().text = r_lvl.ToString();
            StartCoroutine(LvlUpAfterTime(0, 3));
        }
        else if (river_lvl == 1)
        {
            river.GetComponent<River_Behaviour>().Stage_2();
            river_lvl = 2;
            r_lvl = 2;
            _scoreMaxedFrame[1].SetActive(true);
            _objectsLevels[1].GetComponent<Text>().text = r_lvl.ToString();
            StartCoroutine(LvlUpAfterTime(0, 3));
        }

        FishBehaviour();
    }

    void FishBehaviour()
    {
        if(fishes_lvl == -1)
        {
            if(river_lvl != -1)
            {
                fishes.SetActive(true);
                fishes_lvl = 2;
                f_lvl = 2;
                _objectsLevels[5].GetComponent<Text>().text = f_lvl.ToString();
                _scoreMaxedFrame[5].SetActive(true);
                StartCoroutine(LvlUpAfterTime(0, 6));
                StartCoroutine(LvlUpAfterTime(0.5f, 6));
            }
            else
            {
                fishes.transform.position = new Vector3(-8.82f, 1.6f, -4.65f);
                fishes.SetActive(true);
                fishes.GetComponent<Fishes_Behaviour>().SpawnWithoutRiver();
                Destroy(fishes, 2f);
                fishes_lvl = 1;
                f_lvl = 1;
                _objectsLevels[5].GetComponent<Text>().text = f_lvl.ToString();
            }
        }
        else switch (fishes_lvl)
        {
            case 2:
                fishes.GetComponent<Fishes_Behaviour>().SecondStage();
                fishes_lvl = 3;
                break;

            case 3:
                fishes.GetComponent<Fishes_Behaviour>().ThirdStage();
                fishes_lvl = 4;
                break;

            case 4:
                fishes.GetComponent<Fishes_Behaviour>().ForthStage();
                Destroy(fishes, 2f);
                fishes_lvl = 5;
                break;
        }

        TreeBehaviour();
    }

    void TreeBehaviour()
    {
        if (trees_lvl == 0)
        {
            bg_trees_Parent_Object.SetActive(true);
            active_Trees_Parent_Object.SetActive(true);
            trees_lvl = 1;
            t_lvl = 1;
            _objectsLevels[0].GetComponent<Text>().text = t_lvl.ToString();
            StartCoroutine(LvlUpAfterTime(0.2f, 1));
            StartCoroutine(LvlUpAfterTime(0.2f, 0));
            StartCoroutine(LvlUpAfterTime(0.2f, 2));
        }
        else if (trees_lvl == 1 && river_lvl == 2)
        {
            tilts.SetActive(false);
            bg_trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesSecoundStage();
            active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesSecoundStage();
            trees_lvl = 2;
            t_lvl = 2;
            _objectsLevels[0].GetComponent<Text>().text = t_lvl.ToString();
            StartCoroutine(LvlUpAfterTime(0.2f, 1));
            StartCoroutine(LvlUpAfterTime(0.2f, 0));
            StartCoroutine(LvlUpAfterTime(0.2f, 2));
        }
        else if (trees_lvl == 2)
        {
            bg_trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesThirdStage();
            active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesThirdStage();
            trees_lvl = 3;
            t_lvl = 3;
            _objectsLevels[0].GetComponent<Text>().text = t_lvl.ToString();
            StartCoroutine(LvlUpAfterTime(0.2f, 1));
            StartCoroutine(LvlUpAfterTime(0.2f, 0));
            StartCoroutine(LvlUpAfterTime(0.2f, 2));
        }

        BearBehaviour();
    }

    void BearBehaviour()
    {
        if (bear_lvl == 0)
        {
            bear.SetActive(true);
            bear_lvl = 1;
            b_lvl = 1;
            _objectsLevels[3].GetComponent<Text>().text = b_lvl.ToString();
            StartCoroutine(LvlUpAfterTime(0f, 8));
        }

        switch (bear_lvl)
        {
            #region Case 1:
            case 1:
                if(fishes_lvl == 4)
                {
                    bear.GetComponent<Bear_Behaviour>().BearGoingForFishes(1);
                    bear_lvl = 6;
                }
                else if(wolfs_lvl == 2)
                {
                    bear.GetComponent<Bear_Behaviour>().SecondStage();
                    bear.GetComponent<Bear_Behaviour>().Invoke("SecondStageAttack", 1f);
                    Destroy(wolfs, 1.5f);
                    bear_lvl = 2;
                    wolfs_lvl = 3;
                    b_lvl = 2;
                    _objectsLevels[3].GetComponent<Text>().text = b_lvl.ToString();
                    _scoreMaxedFrame[3].SetActive(true);
                    bear.GetComponent<Bear_Behaviour>().LevelUp();
                    StartCoroutine(LvlUpAfterTime(1.7f, 5));
                }
                else
                {
                    bear.GetComponent<Bear_Behaviour>().SecondStage();
                    bear_lvl = 2;
                }
                break;
            #endregion

            #region Case 2:
            case 2:
                if (fishes_lvl == 3)
                {
                    bear.GetComponent<Bear_Behaviour>().BearGoingForFishes(2);
                    bear_lvl = 5;
                }
                else if (wolfs_lvl == 1)
                {
                    wolfs.GetComponent<Wolfs_Behaviour>().SecondStage();
                    wolfs_lvl = 2;
                    bear.GetComponent<Bear_Behaviour>().ThirdStage();
                    bear_lvl = 3;
                }
                else
                {
                    bear.GetComponent<Bear_Behaviour>().ThirdStage();
                    bear_lvl = 3;
                }
                break;
            #endregion

            #region Case 3:
            case 3:
                if (fishes_lvl == 2)
                {
                    bear.GetComponent<Bear_Behaviour>().BearGoingForFishes(3);
                    bear_lvl = 4;
                }
                else if(wolfs_lvl == 2)
                {
                    bear.GetComponent<Bear_Behaviour>().ThirdToSecond();
                    bear.GetComponent<Bear_Behaviour>().Invoke("SecondStageAttack", 1.5f);
                    Destroy(wolfs, 2f);
                    bear_lvl = 2;
                    b_lvl = 2;
                    _objectsLevels[3].GetComponent<Text>().text = b_lvl.ToString();
                    _scoreMaxedFrame[3].SetActive(true);
                    StartCoroutine(LvlUpAfterTime(2f, 5));
                    wolfs_lvl = 3;
                }
                else
                {
                    bear.GetComponent<Bear_Behaviour>().ThirdToSecond();
                    bear_lvl = 2;
                }
                break;
            #endregion

            #region Case 4:
            case 4:
                if(wolfs_lvl == 1)
                {
                    wolfs.GetComponent<Wolfs_Behaviour>().SecondStage();
                    wolfs_lvl = 2;
                    bear.GetComponent<Bear_Behaviour>().ForthToThird();
                    bear_lvl = 3;
                }
                else
                {
                    bear.GetComponent<Bear_Behaviour>().ForthToThird();
                    bear_lvl = 3;
                }
                    break;
                
            #endregion

            #region Case 5:
            case 5:
                if (wolfs_lvl == 2)
                {
                    bear.GetComponent<Bear_Behaviour>().FifthToSecond();
                    bear.GetComponent<Bear_Behaviour>().Invoke("SecondStageAttack", 1f);
                    Destroy(wolfs, 1.5f);
                    bear_lvl = 2;
                    wolfs_lvl = 3;
                    b_lvl = 2;
                    _objectsLevels[3].GetComponent<Text>().text = b_lvl.ToString();
                    _scoreMaxedFrame[3].SetActive(true);
                    bear.GetComponent<Bear_Behaviour>().Invoke("LevelUp", 2.5f);
                    StartCoroutine(LvlUpAfterTime(1.5f, 5));
                }
                else
                {
                    bear.GetComponent<Bear_Behaviour>().FifthToSecond();
                    bear_lvl = 2;
                }
                break;
            #endregion

            #region Case 6:
            case 6:
                if (wolfs_lvl == 2)
                {
                    bear.GetComponent<Bear_Behaviour>().SixthToSecond();
                    bear.GetComponent<Bear_Behaviour>().Invoke("SecondStageAttack", 1f);
                    Destroy(wolfs, 1.5f);
                    bear_lvl = 2;
                    wolfs_lvl = 3;
                    b_lvl = 2;
                    _objectsLevels[3].GetComponent<Text>().text = b_lvl.ToString();
                    _scoreMaxedFrame[3].SetActive(true);
                    bear.GetComponent<Bear_Behaviour>().Invoke("LevelUp", 2.5f);
                    StartCoroutine(LvlUpAfterTime(1.5f, 5));
                }
                else
                {
                    bear.GetComponent<Bear_Behaviour>().SixthToSecond();
                    bear_lvl = 2;
                }
                break;
            #endregion
        }


        WolfsBehaviour();
    }

    void WolfsBehaviour()
    {
        if (wolfs_lvl == 0)
        {
            if(bear_lvl == 3)
            {
                wolfs.SetActive(true);
                wolfs.GetComponent<Wolfs_Behaviour>().SecondStage();
                wolfs_lvl = 2;
                w_lvl = 1;
                _objectsLevels[2].GetComponent<Text>().text = w_lvl.ToString();
                _scoreMaxedFrame[2].SetActive(true);
                StartCoroutine(LvlUpAfterTime(0.1f, 4));
            }
            else
            {
                wolfs.SetActive(true);
                wolfs_lvl = 1;
                w_lvl = 1;
                _objectsLevels[2].GetComponent<Text>().text = w_lvl.ToString();
                _scoreMaxedFrame[2].SetActive(true);
                StartCoroutine(LvlUpAfterTime(0.1f, 4));
            }
        }
        else if (wolfsAlreadyMoved == false)
        {
            if(wolfs_lvl == 1 && bear_lvl != 2)
            {
                wolfs.GetComponent<Wolfs_Behaviour>().SecondStage();
                wolfs_lvl = 2;
            }
        }

        HumanBehaviour();
    }

    void HumanBehaviour()
    {
        if (human_lvl == 0)
        {
            human.SetActive(true);
            human_lvl = 1;
            h_lvl = 1;
            _objectsLevels[4].GetComponent<Text>().text = h_lvl.ToString();
        }

        if (trees_lvl == 3 && human_lvl > 0)
        {
            human.GetComponent<Human_Behaviour>().ChopTrees();
            active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesFallStage();
            human_lvl = 2;
            trees_lvl = 4;
            t_lvl = 4;
            _objectsLevels[0].GetComponent<Text>().text = t_lvl.ToString();
            StartCoroutine(LvlUpAfterTime(1f, 0));
        }
        else if (trees_lvl == 4)
        {
            Invoke("LateBridgeActivate", 0.5f);
            human.GetComponent<Human_Behaviour>().Invoke("BuildBridgePartOne", 0.4f);
            Destroy(active_Trees_Parent_Object.transform.GetChild(1).gameObject, 0.3f);
            Destroy(active_Trees_Parent_Object.transform.GetChild(0).gameObject, .3f);
            human_lvl = 3;
            trees_lvl = 5;
            t_lvl = 5;
            _objectsLevels[0].GetComponent<Text>().text = t_lvl.ToString();
            StartCoroutine(LvlUpAfterTime(0.8f, 9));
        }
        else if (trees_lvl == 5)
        {
            human.GetComponent<Human_Behaviour>().Invoke("BuildBridgePartTwo", 0f);
            bridge.GetComponent<Bridge_Behaviour>().Invoke("SecondStage", 1f);
            Destroy(active_Trees_Parent_Object.transform.GetChild(0).gameObject, .5f);
            human_lvl = 4;
            trees_lvl = 6;
            t_lvl = 6;
            _objectsLevels[0].GetComponent<Text>().text = t_lvl.ToString();
            _scoreMaxedFrame[0].SetActive(true);
            StartCoroutine(LvlUpAfterTime(1f, 9));
        }

        if (trees_lvl == 6)
        {
            if (bear_lvl == 2)
            {
                human.GetComponent<Human_Behaviour>().PassBridgeLose();
                bear.GetComponent<Bear_Behaviour>().Invoke("AttackFromSecondStage", 3f);
                Destroy(human, 4f);
                human_lvl = 5;
                Invoke("GameOver", 1.5f);
            }
            else if(wolfs_lvl == 2)
            {
                human.GetComponent<Human_Behaviour>().PassBridgeLose();
                wolfs.GetComponent<Wolfs_Behaviour>().Invoke("WolfsAttackingHuman", 2f);
                Destroy(human, 4f);
                human_lvl = 5;
                Invoke("GameOver", 2.5f);
            }
            else
            {
                human.GetComponent<Human_Behaviour>().Invoke("PassBridgeWin", 1f);
                human_lvl = 6;
                h_lvl = 2;
                _objectsLevels[4].GetComponent<Text>().text = h_lvl.ToString();
                _scoreMaxedFrame[4].SetActive(true);
                Invoke("Win", 3.3f);
                StartCoroutine(LvlUpAfterTime(2.4f, 10));
            }
        }

        if(order == 6 && human_lvl < 4)
        {
            Invoke("GameOver", 1f);
        }
    }

    void LateBridgeActivate()
    {
        bridge.SetActive(true);
    }

    public void OnRetryButtonPress()
    {
        SceneManager.LoadSceneAsync(0);
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        lostScreen.SetActive(true);
        ShowScore();
    }

    void Win()
    {
        Debug.Log("You have Won");
        wonScreen.SetActive(true);
        ShowScore();
    }

    void ShowScore()
    {
        for (int i = 0; i < 6; i++)
        {
            _buttonsOrder[i].SetActive(true);
        }
        _scoreMaxedFrame[6].SetActive(true);
    }

    IEnumerator LvlUpAfterTime(float t, int placeHolderNumber)
    {
        yield return new WaitForSeconds(t);
        GameObject close = Instantiate(lvlUpText, _lvlUpPlaceHolders[placeHolderNumber].transform);
        Destroy(close, 1f);
    }
}
