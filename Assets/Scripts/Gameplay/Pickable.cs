using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private GameObject originalPrefab;
    [SerializeField] private Transform boxSpawn;
    public void Interact(PlayerInput player)
    {
        if (transform.parent == null)
        {


            transform.position = player.GetPickUpLocation().position;


            transform.SetParent(player.GetPickUpLocation());

            myRigidbody.useGravity = false;
            myRigidbody.isKinematic = true;
        }

        else
        {

            transform.SetParent(null);
            myRigidbody.useGravity = true;
            myRigidbody.isKinematic = false;
        }

    }


    public void OnHoverEnter()
    {

    }

    public void OnHoverExit()
    {

    }
     
    public void DropBox()
    {
        transform.SetParent(null);
        myRigidbody.useGravity = true;
        myRigidbody.isKinematic = false;
    }
}
 