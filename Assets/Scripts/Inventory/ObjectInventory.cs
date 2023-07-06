using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ObjectInventory : MonoBehaviour, IInventory
{
    public List<Item> inventory => inventory;
    
    public void AddItem(ItemSingle item)
    {
        inventory.Add(item);
    }

    public void RemoveItem(ItemSingle item)
    {
        inventory.Remove(item);
    }

    public void AddItem(Type type, int quantity)
    {
        if(type != typeof(ItemStackable))
            throw new System.ArgumentException();
        
        foreach (ItemStackable stack in inventory)
        {
            if(stack.GetType() == type)
            {
                stack.quantity += quantity;
                return;
            }
        }

        ItemStackable newStack = (ItemStackable)Activator.CreateInstance(type);
        newStack.quantity = quantity;
        inventory.Add(newStack);
    }
    
    public void RemoveItem(Type type, int quantity)
    {
        if (type != typeof(ItemStackable))
            throw new System.ArgumentException();

        foreach (ItemStackable stack in inventory)
        {
            if (stack.GetType() == type)
            {
                stack.quantity -= quantity;

                //remove the stack from the inventory if there is none left
                if(stack.quantity <= 0)
                {
                    inventory.Remove(stack);
                }
                return;
            }
        }
    }
    
    public bool HasItem(Type type)
    {
        foreach(Item item in inventory)
        {
            if(item.GetType() == type)
                return true;
        }

        return false;
    }

    public bool HasItem(Type type, int quantity)
    {
        //checking single items
        if(type == typeof(ItemSingle))
        {
            int itemCount = 0;

            foreach (ItemSingle item in inventory)
            {
                if (item.GetType() == type)
                {
                    itemCount++;
                    if (itemCount >= quantity)
                    {
                        return true;
                    }
                }
            }
        }

        //checking stackable items
        else
        {
            foreach(ItemStackable item in inventory)
            {
                if(item.GetType() == type && item.quantity >= quantity)
                {
                    return true;
                }
            }
        }

        return false;
        
    }
}
