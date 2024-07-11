using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPoint;

    public void DestroySpawnPoint()
    {
        if (spawnPoint != null)
        {
            Destroy(spawnPoint);
        }
    }
}



