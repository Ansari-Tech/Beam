using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private List<GameObject> goals = new List<GameObject>();
    private List<GameObject> mirrors = new List<GameObject>();

    public void init(int goalsNum, int mirrorsNum)
    {

    }

    private void spawnEntity(int spawnCount, GameObject objectToSpawn)
    {
        for (int i = 0; i < spawnCount; i++)
        {
			GameObject tempSpawnedObject = GameObject.Instantiate(objectToSpawn);
        }
    }
}
