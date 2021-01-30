using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public int numberToSpawn;
    public float spawnSpeed = 2f;
    public List<GameObject> spawnPool;
    public GameObject quad;
    public GameObject spawner;

    void Start()
    {
        // auto spawn every 2 second
        InvokeRepeating("spawnObjects", 2.0f, spawnSpeed);
    }

    void Update()
    {

    }

    public void spawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;

        // random spawn item from spawner position
        for (int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];
            Instantiate(toSpawn, spawner.transform.position, toSpawn.transform.rotation);
        }

    }


    // for later use
    private void destroyObjects()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }
}

