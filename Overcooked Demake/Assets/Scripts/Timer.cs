using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
 
    public float Duration = 60.0f;
    private float CountdownTime;
    public Text TimerText;
 
    void Update()
    {
      
        
        if (Duration <= 0.0f)
        {
            timerEnded();
        }
        else
        {
           
            Duration -= Time.deltaTime;
            TimerText.text = CountdownTime.ToString();
            CountdownTime = Mathf.Round(Duration);
        }

    }
 
    void timerEnded()
    {
        //End Game
        Debug.Log("End Game");
    }
}
