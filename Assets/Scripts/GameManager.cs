using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEvent OnLevelStart;
    public UnityEvent OnLevelFinished;
    public UnityEvent OnLevelFailed;


    private PlayerInput player;


    public static GameManager Singleton
    {
        get; private set;
    }

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //if (mainMenu == null)
        // {
        ///    mainMenu = FindObjectOfType<MainMenu>();
        //    if (mainMenu == null)
        //    {
        //   Debug.LogWarning("MainMenu not found in the scene!");
        //   }
        //    }
    }

    public void LoadScene(string sceneName)
     {
         SceneManager.LoadScene(sceneName);
      }



    private void Start()
    {

        StartLevel();

    }
    private void Update()
    {

    }
    public void StartLevel()
    {

        OnLevelStart?.Invoke();
        player = FindObjectOfType<PlayerInput>();



    }

   public void FailedLevel()
    {
        OnLevelFailed?.Invoke();
    }
    public void FinishLevel()
    {
    OnLevelFinished?.Invoke();
    }

   




    public void LockPlayer(bool isLocked)
    {
        player.enabled = isLocked;
    }
    //public void GameOver()
  //  {

  //      Debug.Log("Puzzle failed. Game Over!");
        // Restart game or load game over screen
        
   //     LoadScene("StartScreen");
   ///     StartLevel();

   // }




}

    /*public void SetRespawnPoint(int index)
    {
        if (index >= 0 && index < respawnPoints.Count)
        {
            currentRespawnIndex = index;
            Debug.Log($"Respawn point set to index {index}");
        }
        else
        {
            Debug.LogError("Invalid respawn point index");
        }
    }
    */

    /*if (respawnedPlayer == null)
    {
        // Instantiate a new player instance at the respawn point
        if (respawnPoints.Count > 0 && currentRespawnIndex >= 0 && currentRespawnIndex < respawnPoints.Count)
        {
            Transform respawnPoint = respawnPoints[currentRespawnIndex];
            respawnedPlayer = Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);

            // Set respawnedPlayer as the respawned player instance
            Debug.Log("Player respawned at: " + respawnPoint.position);
        }
        else
        {
            Debug.LogError("Respawn failed, check respawn point and index");
        }
    }
    else
    {
        // Move the existing respawned player instance to the respawn point
        if (respawnPoints.Count > 0 && currentRespawnIndex >= 0 && currentRespawnIndex < respawnPoints.Count)
        {
            Transform respawnPoint = respawnPoints[currentRespawnIndex];
            respawnedPlayer.transform.position = respawnPoint.position;
            respawnedPlayer.transform.rotation = respawnPoint.rotation;

            Debug.Log($"Player respawned at: {respawnPoint.position}");
        }
        else
        {
            Debug.LogError("Respawn failed, check respawn point and index");
        }
    }
}*/








