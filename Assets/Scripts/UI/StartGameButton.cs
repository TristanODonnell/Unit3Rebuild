using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string gameSceneName = "PuzzleTest";
    
    public void OnClick()
    {
        SceneManager.LoadScene(gameSceneName);
        GameManager.Singleton.StartLevel();
    }

}
 