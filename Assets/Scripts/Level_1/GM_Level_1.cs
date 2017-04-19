using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_Level_1 : MonoBehaviour {

    public static int thinsToFinish;

    #region Levels of things
    public int river_lvl;
    public int trees_lvl;
    public int bear_lvl;
    public int wolfs_lvl;
    public int fishes_lvl;
    public int human_lvl;
    public int bridge_lvl;

    public int r_lvl;
    public int f_lvl;
    public int t_lvl;
    public int b_lvl;
    public int w_lvl;
    public int h_lvl;
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
    public GameObject bridge; // probably to delete, but who knows 
#endregion

    #region UI things
    public GameObject wonScreen;
    public GameObject lostScreen;
    public GameObject[] _buttons;
    public GameObject[] _buttonsOrder;
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
        bridge_lvl = -1;
        order = 0;
        wolfsAlreadyMoved = false;
    }

    #region UI Buttons Behaviour
    public void OnItemActive_1()        // Tree
    {
        _buttons[0].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[0].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[0].SetActive(true);
        trees_lvl = 0;
        StageStartup();
    }

    public void OnItemActive_2()        // River
    {
        _buttons[1].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[1].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[1].SetActive(true);
        river_lvl = 0;
        StageStartup();
    }

    public void OnItemActive_3()        // Wolf
    {
        _buttons[2].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[2].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[2].SetActive(true);
        wolfs_lvl = 0;
        StageStartup();
    }

    public void OnItemActive_4()        // Bear
    {
        _buttons[3].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[3].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[3].SetActive(true);
        bear_lvl = 0;
        StageStartup();
    }

    public void OnItemActive_5()        // Human
    {
        _buttons[4].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[4].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[4].SetActive(true);
        human_lvl = 0;
        StageStartup();
    }

    public void OnItemActive_6()        // Fish
    {
        _buttons[5].GetComponent<Button>().interactable = false;
        order++;
        _buttonsOrder[5].GetComponent<Text>().text = order.ToString();
        _buttonsOrder[5].SetActive(true);
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
        }
        else if (river_lvl == 1)
        {
            river.GetComponent<River_Behaviour>().Stage_2();
            river_lvl = 2;
            r_lvl = 2;
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
                fishes_lvl = 1;
                f_lvl = 2;
            }
            else
            {
                fishes.transform.position = new Vector3(-8.82f, 1.6f, -4.65f);
                fishes.SetActive(true);
                fishes.GetComponent<Fishes_Behaviour>().SpawnWithoutRiver();
                Destroy(fishes, 2f);
                fishes_lvl = 0;
                f_lvl = 1;
            }
        }
        else switch (fishes_lvl)
        {
            case 1:
                fishes.GetComponent<Fishes_Behaviour>().SecondStage();
                fishes_lvl = 2;
                break;

            case 2:
                fishes.GetComponent<Fishes_Behaviour>().ThirdStage();
                fishes_lvl = 3;
                break;

            case 3:
                fishes.GetComponent<Fishes_Behaviour>().ForthStage();
                Destroy(fishes, 2f);
                fishes_lvl = 4;
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
        }

        if (trees_lvl == 1 && river_lvl == 2)
        {
            tilts.SetActive(false);
            bg_trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesSecoundStage();
            active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesSecoundStage();
            trees_lvl = 2;
            t_lvl = 2;
        }
        else if (trees_lvl == 2)
        {
            bg_trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesThirdStage();
            active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesThirdStage();
            trees_lvl = 3;
            t_lvl = 3;
        }

        BearBehaviour();
    }

    void BearBehaviour()
    {


        WolfsBehaviour();
    }

    void WolfsBehaviour()
    {


        HumanBehaviour();
    }

    void HumanBehaviour()
    {
        if (human_lvl == 0)
        {
            human.SetActive(true);
            human_lvl = 1;
        }

        if (trees_lvl == 3)
        {
            human.GetComponent<Human_Behaviour>().ChopTrees();
            active_Trees_Parent_Object.GetComponent<Tree_Behaviour>().TreesFallStage();
            human_lvl = 2;
            trees_lvl = 4;
            t_lvl = 4;
        }
        else if (trees_lvl == 4)
        {
            bridge.SetActive(true);
            human.GetComponent<Human_Behaviour>().BuildBridge(1);
            Destroy(active_Trees_Parent_Object.transform.GetChild(0).gameObject, 1f);
            Destroy(active_Trees_Parent_Object.transform.GetChild(0).gameObject, 1f);
            human_lvl = 3;
            bridge_lvl = 1;
            trees_lvl = 5;
            t_lvl = 5;
        }
        else if (trees_lvl == 5)
        {
            human.GetComponent<Human_Behaviour>().BuildBridge(2);
            bridge.GetComponent<Bridge_Behaviour>().SecondStage();
            Destroy(active_Trees_Parent_Object.transform.GetChild(0).gameObject);
            human_lvl = 4;
            bridge_lvl = 2;
            trees_lvl = 6;
            t_lvl = 6;
        }
        else if(trees_lvl == 6)
        {
            if (wolfs_lvl == 2 || bear_lvl == 2)
            {

            }
        }
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

    public void Win()
    {
        Debug.Log("You have Won");
        wonScreen.SetActive(true);
    }
}
