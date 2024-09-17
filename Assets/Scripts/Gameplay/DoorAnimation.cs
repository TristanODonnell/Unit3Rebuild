using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 openDoorOffset;
    private Vector3 originalPosition;
    private bool isOpen;
    void Start()
    {
        originalPosition = transform.position;
    }
    void Update()
    {
        Vector3 targetPosition = originalPosition;
        if (isOpen)
        {
            targetPosition = originalPosition + openDoorOffset;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }
    public void OpenDoor()
    {
        isOpen = true;
    }
    public void CloseDoor()
    {
        isOpen = false;
    }
}
