using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot
{
    public Item Item
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;
        }
    }

    public readonly ItemType type;
    private Item _item;

    public EquipmentSlot(ItemType slotType) =>
        type = slotType;
}