using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRNG : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] int spawnCount;
    [SerializeField] int pickupCount;
    private int spawnChoice = 0;
    [Header("References for RNG")]
    [SerializeField] GameObject[] spawns;
    [SerializeField] GameObject pickups;
    //private int[] choice;

    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
    }

    void RandomSpawn()
    {
        int i=0;
        while (i != pickupCount) {
            spawnChoice = Random.Range(0, spawnCount);
            if (i <= 1)
            {
                if (spawns[spawnChoice].transform.childCount <= 0)
                {
                    spawnChoice = Random.Range(0, spawnCount);
                }
            }
            GameObject pickup = (GameObject)Instantiate(pickups, spawns[spawnChoice].transform);
            i++;

        }
    }
}
