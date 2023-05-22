using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterMovement : MonoBehaviour
{
    [SerializeField] protected static float gravity = -9.81f;
    
    [SerializeField] protected CharacterController characterController = null;

    [SerializeField] protected GroundCheck groundCheckCollider = null;

    [SerializeField] protected float movementSpeed = 1f;
    [SerializeField] protected float jumpSpeed = 10f;
    [SerializeField] protected float sprintMultiplier = 1.5f;
    [SerializeField] protected float groundSpeedMultiplier = 1f;
    [SerializeField] protected float airSpeedMultiplier = .2f;

    //the current velocity of the character
    protected Vector3 velocity;

    protected bool grounded = false;

    /// <summary>
    /// Takes the movement input vector and converts it to a vector3 to match the character orientation
    /// </summary>
    /// <param name="movementInput"></param>
    /// <param name="isSprinting"></param>
    /// <returns>Vector of converted 3D movement</returns>
    protected Vector3 ApplyMovementInput(Vector2 movementInput, bool isSprinting)
    {
        Vector3 finalVector = Vector3.zero;

        finalVector += transform.forward * movementInput.y * movementSpeed;
        finalVector += transform.right * movementInput.x * movementSpeed;

        //apply sprint multiplier
        if(isSprinting)
        {
            finalVector *= sprintMultiplier;
        }

        return finalVector;
    }

    /// <summary>
    /// Gets the jump vector as the world up
    /// </summary>
    /// <returns>Up vector with jump speed applied</returns>
    protected Vector3 ApplyJumpVector()
    {
        Vector3 finalVector = Vector3.zero;

        finalVector += Vector3.up * jumpSpeed;

        return finalVector;
    }

    /// <summary>
    /// Checks if the character is touching the ground
    /// </summary>
    /// <returns>Grounded status</returns>
    protected bool CheckGrounded()
    {
        grounded = groundCheckCollider.CheckGroundedStatus();
        return grounded;
    }

    /// <summary>
    /// Will apply all of the player movement input to the character's physics
    /// </summary>
    /// <param name="motionInput">X and Z is the attempted horizontal movement. Y is the attempted jumping height</param>
    protected void ApplyMotion(Vector3 motionInput)
    {
        CheckGrounded();

        velocity.y += gravity * Time.deltaTime;

        if (grounded)
        {
            velocity.y = -.2f;
            velocity = motionInput * groundSpeedMultiplier;
        }
        else
        {
            motionInput.y = 0f;
            velocity += motionInput * airSpeedMultiplier;
        }

        characterController.Move(velocity * Time.deltaTime);

        velocity = characterController.velocity;
    }
}
