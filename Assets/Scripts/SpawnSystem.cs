using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{   /*
    public GameObject playerPrefab;
    private GameObject playerInstance;
    private int lastEnteredPuzzleIndex = -1;
    [SerializeField] private List<Transform> respawnPoints;
    [SerializeField] private List<PuzzleRoom> puzzleRooms;
    
    public GameObject PlayerPrefab
    {
        get { return playerPrefab; }
        set { playerPrefab = value; }
    }
    // Start is called before the first frame update
    void Start() 
    {
        Transform respawnPoint = GetSpawnPoint(0);
        InstantiatePlayer(playerPrefab, respawnPoint);
       
    }

    private void Update()     
    {
        
    }
    private void InstantiatePlayer(GameObject playerPrefab, Transform respawnPoint)
    {
        if (playerPrefab != null)
        {


            if (playerInstance != null)
            {
                Destroy(playerInstance); // Destroy existing player instance if any
            }

            playerInstance = Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);
            Debug.Log("Player instantiated at: " + respawnPoint.position);

            
        }
    }
    public void PlayerDied()
   {
   //     RespawnPlayer();
  }

    

    /* public void RespawnPlayer()
     {
         int lastEnteredIndex = GetLastEnteredPuzzleIndex();
         Transform respawnPoint = GetSpawnPoint(lastEnteredIndex); //get respawn point 

         if (respawnPoint != null)
         {
             if (playerInstance == null)

             {
                 InstantiatePlayer(playerPrefab, respawnPoint);
                 Debug.Log($"Player respawned at: {respawnPoint.position}");

                 if (lastEnteredIndex >= 0 && lastEnteredIndex < puzzleRooms.Count)
                 {
                     PuzzleRoom currentRoom = puzzleRooms[lastEnteredIndex];
                     currentRoom.PlayerRespawned();
                 }
             }

         }
     }
    
    private Transform GetSpawnPoint(int index)
    {
        if (index >= 0 && index < respawnPoints.Count)
        {
            return respawnPoints[index];
        }
        else
        {
            Debug.LogError("Invalid respawn point index");
            return transform; // Fallback to GameManager's own position if index is invalid
        }
    }

    public void SetLastEnteredPuzzleIndex(int index)
    {
        lastEnteredPuzzleIndex = index;
    }

    public int GetLastEnteredPuzzleIndex()
    {
        return lastEnteredPuzzleIndex;
    }
    */
}
