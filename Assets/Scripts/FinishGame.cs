using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{

    public string finishScreenScene = "FinishScreen";
   
 //  public bool isFinished;
    // Start is called before the first frame update

    //void GameIsFinished()

    //{
    ///    isFinished = true;
    //}
      
    public void GameisFinished()
    {
        Debug.Log("Loading scene: " + finishScreenScene);
        if (GameManager.Singleton != null)
        {
          //  GameManager.Singleton.LoadScene(finishScreenScene); 
        }
            

    }    


}  
