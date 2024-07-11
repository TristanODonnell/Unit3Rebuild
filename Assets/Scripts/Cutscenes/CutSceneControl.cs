using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutSceneControl : MonoBehaviour
{

    [SerializeField] private PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Singleton.OnLevelStart.AddListener(PlayCutscene);
        GameManager.Singleton.OnLevelFailed.AddListener(PlayCutscene);
    }

 

    public  void PlayCutscene()
    {
        director.Play();
    }

    public virtual void OnCutsceneEnter()
    {
        GameManager.Singleton.LockPlayer(false);
    }

    public virtual void OnCutsceneFinish()
    {
        GameManager.Singleton.OnLevelStart.RemoveListener(PlayCutscene);
        
        GameManager.Singleton.LockPlayer(true);
        Destroy(gameObject);
    }
}
