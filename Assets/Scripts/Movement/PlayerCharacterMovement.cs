using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterMovement : BaseCharacterMovement
{
    [SerializeField] protected float sensitivity = .5f;
    [SerializeField] protected float groundStickDistance = 1.0f;

    protected void Update()
    {

        Vector2 mouseDelta = Mouse.current.delta.ReadValue() * sensitivity;

        Look(mouseDelta.x, mouseDelta.y);

        grounded = groundCheckCollider.CheckGroundedStatus();

        Move(new Vector3(PlayerInputManager.instance.GetMovementVector().x, 0, PlayerInputManager.instance.GetMovementVector().y));
        
        if(PlayerInputManager.instance.GetJumpInput())
        {
            Jump();
        }

        //apply gravity
        if (!grounded)
            velocity += Vector3.up * gravity * Time.deltaTime;

        //set downward velocity to small number to prevent stacking speed
        else if(grounded && velocity.y < 0)
        {
            characterController.Move(new Vector3(0, -groundStickDistance, 0));
            velocity = new Vector3(velocity.x, -.3f, velocity.z);
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
