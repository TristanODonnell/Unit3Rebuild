using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private Animator animator;

    

    public void OpenDoor()
    {
       
        animator.SetBool("DoorOpen", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("DoorOpen", false);
    }
    
    public void DynamicOpenCloseDoor()
    {
        if(animator.GetBool("DoorOpen"))
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }
}
