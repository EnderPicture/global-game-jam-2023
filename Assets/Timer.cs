using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float seconds = 30.0f;
    public float timeElasped = 0.0f;
    public Image pieTimer;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(pieTimer.fillAmount);
        float currentTime = seconds;
        if (seconds >= 0.0f)
        {
            Debug.Log(timeElasped);
            pieTimer.fillAmount = timeElasped / 30.0f;
        } else {
            Debug.Log("OVER FILLED");
            pieTimer.fillAmount = 1.0f;
        }
        seconds -= Time.deltaTime;
        timeElasped += Time.deltaTime;
    }

    public bool isTimeUp() {
        if(seconds <= 0.0f) {
            return true;
        } else {
            return false;
        }
    }
}
