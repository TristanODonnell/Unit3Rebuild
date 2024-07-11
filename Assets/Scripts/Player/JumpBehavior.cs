using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : MonoBehaviour
{
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask floorFilter;
    [SerializeField] private Rigidbody rb;
   private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, groundCheckRadius, floorFilter) ;
    }
   public void JumpCharacter()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    internal void JumpPlayer()
    {
        throw new NotImplementedException();
    }
}
