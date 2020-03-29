using System;
using UnityEngine;

public class BagItemView : ItemView
{
    public override event Action<Item> OnRemoveItem;
    public override event Action<Item> OnEquipItem;

    public override bool SetItem(Item targetItem, out Item previousItem)
    {
        previousItem = _item;

        _item = targetItem;
        _icon.color = targetItem.color;
        _title.text = targetItem.itemName;

        OnRemoveItem?.Invoke(previousItem);
        OnEquipItem?.Invoke(targetItem);
        Debug.Log($"{targetItem.itemName} put on.");

        return true;
    }
}