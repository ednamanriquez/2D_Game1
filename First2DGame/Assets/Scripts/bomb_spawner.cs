using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class bomb_spawner : MonoBehaviour
{

    public GameObject itemPrefab;
    public float spawnInterval = 1f;


    public float spawnXMin = -8f;
    public float spawnXMax = 8f;

    public float spawnY = 5f;
    // Start is called before the first frame update
    void Start()
    {  
        
       StartCoroutine(spawnBomb());
    }

    IEnumerator spawnBomb()
    {
        while (true)
        {
            spawObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    // Update is called once per frame


    void spawObject()
    {
        float randomX = UnityEngine.Random.Range(spawnXMin, spawnXMax);
        Vector3 randomPos = new Vector3(randomX, spawnY, 0);
        Instantiate(itemPrefab, randomPos, Quaternion.identity);

    }
}
