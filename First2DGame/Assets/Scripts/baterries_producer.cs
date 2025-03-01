using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baterries_producer : MonoBehaviour
{
    public GameObject itemPrefab;
    public float spawnInterval = 1f; 
    public float spawnXMin = -8f;
    public float spawnXMax = 8f;
    public float spawnY = 5f;

    
    void Start()
    {  
        
        StartCoroutine(spawnBatteries());

    }

    IEnumerator spawnBatteries()
    {
        while (true)
        {
            spawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void spawnObject()
    {
        float randomX = UnityEngine.Random.Range(spawnXMin, spawnXMax);
        Vector3 randomPos = new Vector3(randomX, spawnY, 0);
        Instantiate(itemPrefab,randomPos,Quaternion.identity);

    }
}
