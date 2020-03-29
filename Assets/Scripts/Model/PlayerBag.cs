using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag
{
    public readonly List<Item> items;
    private const int DEFAULT_SIZE = 10;

    public PlayerBag() =>
        (items) = (new List<Item>(DEFAULT_SIZE));

    public void Add(Item targetItem)
    {
        _ = targetItem != null 
            ? targetItem 
            : throw new System.ArgumentNullException(paramName: nameof(targetItem),
            message: "Can't add in bag NULL item.");

        bool isFull = items.Count == DEFAULT_SIZE;

        if (isFull)
        {
            Debug.Log("Bag is full.");
            return;
        }

        items.Add(targetItem);
        Debug.Log($"{targetItem.name} added in bag");
    }

    public void Remove(Item removedTarget)
    {
        _ = removedTarget != null
            ? removedTarget
            : throw new System.ArgumentNullException(paramName: nameof(removedTarget),
            message: "Can't remove in bag NULL item.");

        items.Remove(removedTarget);
        Debug.Log($"{removedTarget.name} removed from bag");
    }
}
