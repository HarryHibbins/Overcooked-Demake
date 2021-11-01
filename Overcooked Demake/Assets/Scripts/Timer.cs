using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
 
    public float Duration = 60.0f;
    private float CountdownTime;
    public float elapsed_time = 0.0f;
    public Text TimerText;
 
    void Update()
    {
        elapsed_time += Time.deltaTime;
      
        
        if (Duration <= 0.0f)
        {
            timerEnded();
            
        }
        else
        {
           
            Duration -= Time.deltaTime;
            CountdownTime = Mathf.Round(Duration);
            TimerText.text = CountdownTime.ToString();
        }

    }
 
    void timerEnded()
    {
        //End Game
        Debug.Log("End Game");
    }
}
