using System.Collections.Generic;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public GameObject heartPrefab;  
    public Transform heartsContainer;   

    private List<GameObject> hearts = new List<GameObject>();

    public void UpdateLives(int lives)
    {
        foreach (GameObject heart in hearts)
        {
            Destroy(heart);
        }
        hearts.Clear();

        for (int i = 0; i < lives; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsContainer);
            hearts.Add(heart);
        }
    }
}
