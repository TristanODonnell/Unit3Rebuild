using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PuzzleRoom : MonoBehaviour
{
    public int spawnPointIndex;
    // private IPuzzlePiece[] allPieces;
    [SerializeField] private bool isPuzzleFailed = false;
    private PuzzleController puzzleController;
    [SerializeField] private List<GameObject> objectiveObjects;
    
    public UnityEvent OnPuzzleStart;
    public UnityEvent OnPuzzleFinish;
    public UnityEvent OnPlayerRespawn;
    private MainMenu mainMenu;
    //THIS IS EXPERIMENTAL

    public void InitializeRoom(PuzzleController controller)
    {
        puzzleController = controller;
        //allPieces = GetComponentsInChildren<IPuzzlePiece>();
            
       
      
    }
    private void Update()
    {
       
    }



     
    //public void CheckRoomStatus() //SHOULD RUN EVERYTIME PIECE GETS UPDATED (PressurePlate OnActive())
    //  {
    //     //foreach (IPuzzlePiece piece in allPieces)
    // {
    //       if (!piece.IsCorrect) isPuzzleCompleted = false;
    //    }
    //
    //   if(isPuzzleCompleted)
    //    {
    //        Debug.Log("ALL REQUIREMENTS MET");
    //    }
    //  }

    public void PuzzleEnter()
    {
        OnPuzzleStart?.Invoke();
        Debug.Log("player entered the room");
    }

    public void PuzzleExit()
    {
        OnPuzzleFinish?.Invoke();
        Debug.Log("player exited the room");
    }

    public void PlayerRespawned()
    {
        OnPlayerRespawn?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzleController.ChangePuzzleRoom(this);
    }

    
}
