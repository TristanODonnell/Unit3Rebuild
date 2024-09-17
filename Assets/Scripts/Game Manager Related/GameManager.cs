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

    public CutSceneControl CutSceneControl;
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
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private void Start()
    {
        StartLevel();
    }
    public void StartLevel()
    {
        OnLevelStart?.Invoke();
        player = FindObjectOfType<PlayerInput>();
    }
    public void FailedLevel()
    {
        SceneManager.LoadScene("RestartGame");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void FinishLevel()
    {
        OnLevelFinished?.Invoke();
    }
    public void LockPlayer(bool isLocked)
    {
        player.enabled = isLocked;
    }
}










