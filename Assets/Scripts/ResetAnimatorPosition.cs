using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimatorPosition : MonoBehaviour
{
    [SerializeField] private Vector3 resetPosition;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ResetPositionToSpecific()
    {
        transform.position = resetPosition; // Reset position to specified resetPosition
    }
}
