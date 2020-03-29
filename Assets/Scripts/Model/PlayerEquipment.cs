using UnityEngine;

public class PlayerEquipment
{
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

        Debug.Log($"{targetItem.itemName} - added in inventory.");
    }

    public void Remove(Item removedItem)
    {
        foreach (EquipmentSlot slot in items)
            if (slot.Item == removedItem)
                slot.Item = null;

        Debug.Log($"Item removed from inventory.");
    }
}