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
            UpdateScore(30,20);
        }
    }

    public void UpdateScore(int score_amount, int timer_amount)
    {
        //if recipe complete
        score += score_amount; //Change value depending on recipe completed
        timer.Duration += timer_amount;//Change value depending on recipe completed


    }
}
