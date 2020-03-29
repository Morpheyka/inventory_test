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
            : throw new System.ArgumentNullException();

        if (IsFull())
        {
            Debug.Log("Bag is full;");
            return;
        }

        items.Add(targetItem);
        Debug.Log($"{targetItem.name} added in bag");
    }

    public bool IsFull() =>
        items.Count == DEFAULT_SIZE;
}
