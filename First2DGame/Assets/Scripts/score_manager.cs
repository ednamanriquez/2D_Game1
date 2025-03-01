using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score_manager : MonoBehaviour
{
    public static score_manager instance;
    public TMP_Text score_text;
    int score = 0; 

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score_text.text = score.ToString() + " Points";
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void addPoints(int points = 1)
    {
        score +=points;
        score_text.text = score.ToString() + " Points";
    }
    public void removePoints(int points = 5)
    {
        score -= points;
        score_text.text = score.ToString() + " Points";
    }

    }
