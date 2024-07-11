using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameSceneName = "StartScreen";
    // Start is called before the first frame update
    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.Singleton;
    }
    public void StartScreen()
    {

        //GameManager.Singleton.LoadScene(gameSceneName);
    }
}
