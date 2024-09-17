using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnButtonPressed;
    public UnityEvent OnKeyPickedUp;
    private Material originalMaterial;
    [SerializeField] private Material unlockedMaterial;
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

    }
    public void OnHoverExit()
    {
        myRender.material = originalMaterial;
    }
    public void KeyPickup()
    {
        Debug.Log("KeyPickup method called on InteractableButton");
        myRender.material = unlockedMaterial;
    }
}
