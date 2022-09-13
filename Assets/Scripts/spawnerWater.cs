using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerWater : MonoBehaviour
{
    public GameObject[] prefabWaterLevel;
    int levelwater;
    // Start is called before the first frame update
    void Start()
    {
        levelwater = prefabWaterLevel.Length;

    }

    // Update is called once per frame
    public void spawnWater(bool isSpawn)
    {
        if (isSpawn)
        {
            print("kena");
            int rand = Random.Range(0, levelwater);
            Instantiate(prefabWaterLevel[rand], transform.position, Quaternion.identity);
            isSpawn = false;
        }

    }
}
