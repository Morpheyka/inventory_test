using System;
using UnityEngine;

public class PlayerEquipment
{
    public event Action<Item> OnItemRemove;

    public readonly EquipmentSlot[] items;

    public PlayerEquipment()
    {
        items = new EquipmentSlot[4]
        {
            new EquipmentSlot(ItemType.Helmet),
            new EquipmentSlot(ItemType.Weapon),
            new EquipmentSlot(ItemType.Clothes),
            new EquipmentSlot(ItemType.Shield)
        };

        Debug.Log("Inventory created.");
    }

    public void Equip(Item targetItem)
    {
        foreach (EquipmentSlot slot in items)
            if(slot.type == targetItem.type)
                slot.Item = targetItem;

        Debug.Log($"{targetItem.name} - added in inventory.");
    }

    public void Remove(Item targetItem)
    {
        foreach (EquipmentSlot slot in items)
            if (slot.Item == targetItem)
                slot.Item = null;

        Debug.Log($"{targetItem} - removed from inventory.");
    }
}