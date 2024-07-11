using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float startTime;
    private float currentTime;

    private bool gameIsRunning = true;
    private UIGameTimer uiGameTimer;

    public static float FinalTime { get; private set; }
    private void Start()
    {
        startTime = Time.time; 
        uiGameTimer = FindObjectOfType<UIGameTimer>();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (gameIsRunning)
        {
            currentTime = Time.time - startTime;
            uiGameTimer?.UpdateTimerUI(currentTime);
            //Debug.Log("Timer: " + currentTime.ToString("F2")); // Log or display the current time    
        }
    } 

    public void EndGame()
    {
        
            gameIsRunning = false; 
            FinalTime = currentTime;
            uiGameTimer?.SetFinalTimeDisplay(true);
            uiGameTimer?.UpdateTimerUI(currentTime);

            Debug.Log("Game Over! Timer reached " + currentTime.ToString("F2") + " seconds.");
            // You can add code here to trigger end game actions, like loading a game over scene or displaying a UI message.
        
       
    }
}
