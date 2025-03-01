using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class battery_function : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int batteryPoints = 1; 
    public GameObject sparkEffectPrefab;


    void Update()
    {
       
        Vector3 bottomWorld = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        float buffer = 3f;

        if (transform.position.y < bottomWorld.y - buffer)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Battery touched by Player!");

            score_manager.instance.addPoints(batteryPoints);
            StartCoroutine(DespawnWithEffects());
        }
    }

    IEnumerator DespawnWithEffects()
    {
        if (sparkEffectPrefab)
        {
            Instantiate(sparkEffectPrefab, transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(0.2f); 

        Destroy(gameObject);
    }
}

