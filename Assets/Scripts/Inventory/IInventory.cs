using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IInventory
{
    List<Item> inventory { get; }
    
    /// <summary>
    /// Add a single item to the inventory
    /// </summary>
    /// <param name="item"></param>
    void AddItem(ItemSingle item);

    /// <summary>
    /// Remove a single item from the inventory
    /// </summary>
    /// <param name="item"></param>
    void RemoveItem(ItemSingle item);

    /// <summary>
    /// Add stackable items
    /// </summary>
    /// <param name="type">Pass an ItemStackable type or exception will be thrown</param>
    /// <param name="quantity">Quantity of the type you want added</param>
    void AddItem(Type type, int quantity);

    /// <summary>
    /// Remove stackable items
    /// </summary>
    /// <param name="type">Pass an ItemStackable type or exception will be thrown</param>
    /// <param name="quantity">Quantity of the type you want removed</param>
    void RemoveItem(Type type, int quantity);

    /// <summary>
    /// Returns whether or not the item is in the inventory
    /// </summary>
    /// <param name="type">The type of Item you want to look for</param>
    /// <returns></returns>
    bool HasItem(Type type);

    /// <summary>
    /// Returns whether or not there is a specified amount of items is in the inventory
    /// </summary>
    /// <param name="type">The type of Item you want to look for</param>
    /// <param name="quantity">Number of items you are searching for</param>
    /// <returns>True if inventory quantity is greater than or equal to quantity</returns>
    bool HasItem(Type type, int quantity);
}
