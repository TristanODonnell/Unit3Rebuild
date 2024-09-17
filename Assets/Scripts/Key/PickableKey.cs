using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableKey : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private InteractableButton myInteractableButton;

    public void Interact(PlayerInput player)
    {
        if (transform.parent == null)
        {
            transform.position = player.GetPickUpLocation().position;
            transform.SetParent(player.GetPickUpLocation());

            myRigidbody.useGravity = false;
            myRigidbody.isKinematic = true;

            KeyPickUp();
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
    public void KeyPickUp()
    {
        Debug.Log("KeyPickUp method called on PickableKey");
        myInteractableButton.OnKeyPickedUp.Invoke();
    }
    public void DropKey()
    {
        transform.SetParent(null);
        myRigidbody.useGravity = true;
        myRigidbody.isKinematic = false;
    }
    public void OnOpened()
    {
        Destroy(gameObject);
    }
}
