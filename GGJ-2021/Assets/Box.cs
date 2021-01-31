using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public List<GameObject> spawnPool;
    public List<GameObject> boxBag;
    public int bagSize = 4;

    // Start is called before the first frame update
    void Start()
    {
        int randomItem = 0;
        GameObject bagItem;
        for (int i = 0; i < bagSize; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            bagItem = spawnPool[randomItem];
            boxBag[i] = bagItem;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bagSize == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boxBag.Remove(collision.gameObject);
    }
}
