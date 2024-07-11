using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ShootBehavior shoot;
    [SerializeField] private JumpBehavior jump;

    private void Update()
    {
      CheckJumpInput();
       CheckShootInput();
        
        
    }

    private void CheckShootInput()
    {
        if (shoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shoot.ShootWeapon();
            }
        }         
    }

    private void CheckJumpInput()
    {
       if(jump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump.JumpCharacter();
            }
        }
    }
}
