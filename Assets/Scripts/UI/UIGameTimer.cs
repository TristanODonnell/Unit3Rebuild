using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameTimer : MonoBehaviour
{
    private bool isFinalTimeDisplay = false;

    public TextMeshProUGUI timerText;

    public void SetFinalTimeDisplay(bool isFinal)
    {
        isFinalTimeDisplay = isFinal;
    }
    // Start is called before the first frame update
    private void Start()
    {
        if (!GameTimer.FinalTime.Equals(0))
        {
            SetFinalTimeDisplay(true);
            UpdateTimerUI(GameTimer.FinalTime); 
        }
    } 
    public void UpdateTimerUI(float currentTime)
    {
        // Format currentTime into minutes and seconds
        float minutes = Mathf.FloorToInt(currentTime / 60f);
        float seconds = Mathf.FloorToInt(currentTime % 60f);

        if (isFinalTimeDisplay)
        {
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
        else
        {
            timerText.text = $"{minutes:00}:{seconds:00}";
        }


    }

    
}
