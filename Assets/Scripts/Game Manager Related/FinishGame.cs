using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public string finishScreenScene = "FinishScreen";

    public void GameisFinished()
    {
        Debug.Log("Loading scene: " + finishScreenScene);
    }
}
