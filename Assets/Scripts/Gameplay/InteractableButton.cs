using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnButtonPressed;
    //[SerializeField] private Material highlightedMaterial;

    private Material originalMaterial;
    private MeshRenderer myRender;
    public TextMeshProUGUI openDoorString;
    private void Awake()
    {
        myRender = GetComponent<MeshRenderer>();
        originalMaterial = myRender.material;

    }
    public void Interact(PlayerInput player)
    {
        OnButtonPressed.Invoke();
    }

    public void OnHoverEnter()
    {
        //myRender.material = highlightedMaterial;
        //if (openDoorString != null)
       // {
       //     openDoorString.gameObject.SetActive(true); // Show the text
       // }
       // else
       // {
        //    Debug.LogWarning("openDoorString is not assigned.");
        //}
    

    }

    public void OnHoverExit()
    {
        myRender.material = originalMaterial;
       /* if (openDoorString != null)
        {
            openDoorString.gameObject.SetActive(false); // Hide the text 
        }
        else 
        {
            Debug.LogWarning("openDoorString is not assigned.");
        }
       */
    }
}
