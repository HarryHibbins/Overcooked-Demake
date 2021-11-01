using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public int score;

    public Timer timer;
    void Start()
    {
        
    }

    void Update()
    {

        ScoreText.text = ("Score: ") + score.ToString();

        
        
        //--------Testing-----------
        if (Input.GetKeyDown(KeyCode.F))
        {
            UpdateScore();
        }
    }

    public void UpdateScore()
    {
        //if recipe complete
        score += 20; //Change value depending on recipe completed
        timer.Duration += 10;//Change value depending on recipe completed


    }
}
