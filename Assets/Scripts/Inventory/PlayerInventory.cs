using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : ObjectInventory
{
    private bool isOpen;

    /// <summary>
    /// Opens the UI for only this inventory
    /// </summary>
    public void OpenInventory()
    {
        GameManager.instance.GetPlayerInventoryUI().SetActive(true);

        isOpen = true;
        
        GameManager.instance.PauseTime();
        GameManager.instance.GetPlayer().GetComponent<PlayerCharacterMovement>().SetEnabledStatus(false);
    }

    /// <summary>
    /// Closes all inventory UI
    /// </summary>
    public void CloseInventory() 
    {
        GameManager.instance.GetPlayerInventoryUI().SetActive(false);
        GameManager.instance.GetContainerInventoryUI().SetActive(false);

        isOpen = false;

        GameManager.instance.ResumeTime();
        GameManager.instance.GetPlayer().GetComponent<PlayerCharacterMovement>().SetEnabledStatus(true);
    }

    /// <summary>
    /// Opens the UI for this inventory and the other inventory passed in
    /// </summary>
    /// <param name="other">Other inventory you want to open</param>
    public void OpenInventory(ObjectInventory other)
    {
        GameManager.instance.GetPlayerInventoryUI().SetActive(true);
        GameManager.instance.GetContainerInventoryUI().SetActive(true);

        isOpen = true;

        GameManager.instance.PauseTime();
        GameManager.instance.GetPlayer().GetComponent<PlayerCharacterMovement>().SetEnabledStatus(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Whether the this inventory is open</returns>
    public bool GetIsOpen()
    {
        return isOpen;
    }
}
