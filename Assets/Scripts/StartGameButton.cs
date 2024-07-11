using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{

    public string gameSceneName = "PuzzleTest";
    // Start is called before the first frame update
   public GameManager gameManager;

        public void StartGame()
    {
        //GameManager.Singleton.LoadScene(gameSceneName); SceneManager.LoadScene(gameSceneName);
    }


}
 