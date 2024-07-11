using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PuzzleController : MonoBehaviour
{

    
    [SerializeField] private List<PuzzleRoom> puzzleRooms;
    [SerializeField] private PuzzleRoom currentRoom;

    private SpawnSystem spawnSystem;
    private int lastEnteredPuzzleIndex = -1;
    public static PuzzleController Singleton { get; private set; }
    

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            
        }
        else
        {
            Destroy(gameObject);
        }

        //spawnSystem = FindObjectOfType<SpawnSystem>();
        //if (spawnSystem == null)
      //  {
        //    Debug.LogError("SpawnSystem not found in the scene.");
      //  }

        for (int i = 0; i < puzzleRooms.Count; i++)
        {
            puzzleRooms[i].InitializeRoom(this);
        }

       
    }

    public void ChangePuzzleRoom(PuzzleRoom newRoom)
    {
        if (newRoom == null)
        {
            Debug.LogError("New room is null");
            return;
        }

        if (currentRoom)
        {
            currentRoom.PuzzleExit();
        }

        

        currentRoom = newRoom;
        currentRoom.PuzzleEnter();

        lastEnteredPuzzleIndex = puzzleRooms.IndexOf(newRoom);
      // spawnSystem.SetLastEnteredPuzzleIndex(lastEnteredPuzzleIndex);

        UnityEngine.Debug.Log($"Changed to room {newRoom.name}, spawn point index: {lastEnteredPuzzleIndex}");
    }
}
    /*public bool IsPuzzleFailed()
    {
        if (HealthModule != null)
        {
            if (HealthModule.isDead) 
            {
                Debug.Log("Player isDead, Puzzle is failed.");
                return true;
            }
            else
            {
                Debug.Log("Player is notDead. HealthModule.isDead: " + HealthModule.isDead);
            }
        }
        else
        {
            Debug.LogWarning("HealthModule reference is null.");
        }

        Debug.Log("Puzzle is not failed.");
        return false;
    }

    public void CheckPuzzleFailure()
    {
        if (IsPuzzleFailed())
        {
            Debug.Log("Puzzle failed. Implement failure logic.");
            GameManager.Singleton.RespawnPlayer();
        }
        else
        {
            Debug.Log("Puzzle not failed. Continue game.");
        }
    }*/

 

    

 