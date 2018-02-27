using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager = null;

    void Awake()
    {
        Debug.Log("created!");
        if (manager == null)
        {
            manager = this;
        }
        else
        {
            Debug.Log("Multiple managers! existential crisis!");
        }
        DontDestroyOnLoad(gameObject);
        Initialize();
    }


    void Initialize()
    {
        //load menu
        SetCurrentUserLevel(1);
        SceneManager.LoadScene("Main_Menu");
    }

    public void LoadLevel(int levelToLoad)
    {
        Debug.Log("Loadlevel: " + levelToLoad);
        SceneManager.LoadScene(PlayerPrefs.GetInt("level") + 1);
                SetCurrentUserLevel(levelToLoad);
    }

    public void loadLastLevel()
    {
        if (PlayerPrefs.GetInt("level") < 2)
        {
            Debug.Log("Load Last Level: 2");

            LoadLevel(2);
        }
        else
        {
            Debug.Log("Load Last Level: " + PlayerPrefs.GetInt("level"));
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        }
    }
    private void SetCurrentUserLevel(int levelToSave)
    {
        Debug.Log("Setting current level to: " + levelToSave);
        PlayerPrefs.SetInt("level", levelToSave);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }




    public void endGameState()
    {
        //TODO: do transition stuff between changing gamestate.
        LoadLevel(PlayerPrefs.GetInt("level") + 1);
    }
}
