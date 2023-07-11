using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerControls input = null;
    public static PlayerInputManager instance;

    /// <summary>
    /// Vector2 containing the right and forward inputs
    /// </summary>
    private Vector2 movementInput = Vector2.zero;
    
    //boolean inputs
    private bool isJumping = false;
    private bool isSprinting = false;

    private void Awake()
    {
        input = new PlayerControls();

        //Implement the singleton design
        if (instance != null)
            Destroy(gameObject);

        instance = this;
    }

    // Update function for testing
    private void FixedUpdate()
    {
        //Debug.Log("Movement:\n" + movementInput);
        //Debug.Log("Jump:\n" + isJumping); 
        //Debug.Log("Sprint:\n" + isSprinting);
    }

    /// Binds all of the player movement inputs to functions
    private void OnEnable()
    {
        input.Enable();

        input.PlayerCharacter.Movement.performed += OnMovementPerformed;
        input.PlayerCharacter.Movement.canceled += OnMovementCanceled;

        input.PlayerCharacter.Jump.performed += OnJumpPerformed;
        input.PlayerCharacter.Jump.canceled += OnJumpCanceled;

        input.PlayerCharacter.Sprint.performed += OnSprintPerformed;
        input.PlayerCharacter.Sprint.canceled += OnSprintCanceled;

        input.PlayerCharacter.Interact.performed += OnInteractPerformed;
        input.PlayerCharacter.Interact.canceled += OnInteractCanceled;

        input.PlayerCharacter.Inventory.performed += OnInventoryPerformed;
        input.PlayerCharacter.Inventory.canceled += OnInventoryCanceled;
    }

    /// Unbinds all of the player movement inputs to funtions
    private void OnDisable()
    {
        input.Disable();

        input.PlayerCharacter.Movement.performed -= OnMovementPerformed;
        input.PlayerCharacter.Movement.canceled -= OnMovementCanceled;

        input.PlayerCharacter.Jump.performed -= OnJumpPerformed;
        input.PlayerCharacter.Jump.canceled -= OnJumpCanceled;

        input.PlayerCharacter.Sprint.performed -= OnSprintPerformed;
        input.PlayerCharacter.Sprint.canceled -= OnSprintCanceled;

        input.PlayerCharacter.Interact.performed -= OnInteractPerformed;
        input.PlayerCharacter.Interact.canceled -= OnInteractCanceled;

        input.PlayerCharacter.Inventory.performed -= OnInventoryPerformed;
        input.PlayerCharacter.Inventory.canceled -= OnInventoryCanceled;

        //set all input to zero when the character input is disabled
        movementInput = Vector2.zero;
        isJumping = false;
    }

    /// <summary>
    /// Called when the player presses the inventory button
    /// </summary>
    /// <param name="obj"></param>
    private void OnInventoryPerformed(InputAction.CallbackContext obj)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //call inventory functions on the player
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        
        if (!inventory.GetIsOpen()) 
        {
            inventory.OpenInventory();
            Debug.Log("open inventory");
        }
        else
        {
            inventory.CloseInventory();
            Debug.Log("close inventory");
        }
    }

    /// <summary>
    /// Called when the player lets go of the inventory button
    /// </summary>
    /// <param name="obj"></param>
    private void OnInventoryCanceled(InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
    }

    /// <summary>
    /// Called when the player presses the interact button
    /// </summary>
    /// <param name="obj"></param>
    private void OnInteractPerformed(InputAction.CallbackContext obj)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //call the interact function on the player
    }

    /// <summary>
    /// Called when the player lets go of the interact button
    /// </summary>
    /// <param name="obj"></param>
    private void OnInteractCanceled(InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
    }

    /// <summary>
    /// Called when the player inputs movement
    /// </summary>
    /// <param name="value"></param>
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        movementInput = value.ReadValue<Vector2>();
    }

    /// <summary>
    /// Called when the player stops all movement input
    /// </summary>
    /// <param name="value"></param>
    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        movementInput = Vector2.zero;
    }

    /// <summary>
    /// Called when the player inputs the jump bind
    /// </summary>
    /// <param name="value"></param>
    private void OnJumpPerformed(InputAction.CallbackContext value)
    {
        isJumping = true;
    }

    /// <summary>
    /// Called when the player stops pressing the jump bind
    /// </summary>
    /// <param name="value"></param>
    private void OnJumpCanceled(InputAction.CallbackContext value)
    {
        isJumping = false;
    }

    /// <summary>
    /// Called when the player presses the sprint bind
    /// </summary>
    /// <param name="value"></param>
    private void OnSprintPerformed(InputAction.CallbackContext value)
    {
        isSprinting = true;
    }

    /// <summary>
    /// Called when the player stops pressing the sprint bind
    /// </summary>
    /// <param name="value"></param>
    private void OnSprintCanceled(InputAction.CallbackContext value)
    {
        isSprinting = false;
    }

    /// <summary>
    /// Gets the movement input
    /// </summary>
    /// <returns>Vector2 of the right input and then the forward input</returns>
    public Vector2 GetMovementVector()
    {
        return movementInput;
    }

    /// <summary>
    /// Gets the jump input
    /// </summary>
    /// <returns>Boolean containing if the player is trying to jump</returns>
    public bool GetJumpInput()
    {
        return isJumping;
    }

    /// <summary>
    /// Gets the sprint input
    /// </summary>
    /// <returns>Boolean containing if the player is trying to sprint</returns>
    public bool GetSprintInput() 
    {
        return isSprinting;
    }
}
