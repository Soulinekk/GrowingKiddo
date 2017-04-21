using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Levels_Buttons : MonoBehaviour {

    public void LoadLevel(int level_id)
    {
        SceneManager.LoadScene(level_id);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
