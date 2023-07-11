using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterMovement : MonoBehaviour
{
    [SerializeField] protected static float gravity = -9.81f;
    
    [SerializeField] protected CharacterController characterController = null;

    [SerializeField] protected GroundCheck groundCheckCollider = null;

    [SerializeField] protected Transform headTransform = null;

    [SerializeField] protected float movementSpeed = 1f;
    [SerializeField] protected float jumpSpeed = 10f;
    [SerializeField] protected float sprintMultiplier = 1.5f;
    [SerializeField] protected float groundSpeedMultiplier = 1f;
    [SerializeField] protected float airSpeedMultiplier = .1f;

    //the current velocity of the character
    protected Vector3 velocity;

    protected float headXRotation = 0f;

    protected bool grounded = false;
    protected bool jumpReady = true;

    protected bool movementEnabled = true;

    /// <summary>
    /// Moves the character on the horizontal axis
    /// </summary>
    /// <param name="direction">The local direction of desired movement</param>
    public void Move(Vector3 direction)
    {
        if(!movementEnabled) return;

        direction = direction.normalized;
        Vector3 worldSpaceDirection = transform.TransformVector(direction);

        if(grounded)
        {
            //sets horizontal movement speed
            velocity = worldSpaceDirection * groundSpeedMultiplier * movementSpeed + new Vector3(0, velocity.y, 0);
        }
        else
        {
            //adds horizontal movement speed

            //old calculation
            velocity += worldSpaceDirection * airSpeedMultiplier * movementSpeed;
        }
    }

    /// <summary>
    /// Makes the character jump if grounded
    /// </summary>
    public void Jump() 
    {
        if (!movementEnabled) return;

        if (grounded && velocity.y <= 0) 
        {
            velocity += transform.up * jumpSpeed;
            StartCoroutine(groundCheckCollider.DelayChecks(.1f));
            grounded = false;
        }
    }

    /// <summary>
    /// Applies body turning and head nodding
    /// </summary>
    /// <param name="horizontalRoation">The angle in degrees that you want the character to turn horizontally</param>
    /// <param name="verticalRotation">The angle in degrees that you want the camera to turn vertically</param>
    public void Look(float horizontalRoation, float verticalRotation)
    {
        if (!movementEnabled) return;

        headXRotation -= verticalRotation;
        headXRotation = Mathf.Clamp(headXRotation, -90f, 90f);

        headTransform.localRotation = Quaternion.Euler(headXRotation, 0, 0);

        transform.Rotate(Vector3.up, horizontalRoation);
    }

    /// <summary>
    /// Enables or disables all character movement
    /// </summary>
    /// <param name="enabledStatus"></param>
    public void SetEnabledStatus(bool enabledStatus)
    {
        movementEnabled = enabledStatus;
    }
}
