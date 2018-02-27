using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public void Continue()
    {
		GameManager.manager.loadLastLevel();
    }

    public void NewGame()
    {
		GameManager.manager.LoadLevel(2);
    }
}
