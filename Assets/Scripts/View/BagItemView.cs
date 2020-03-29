using UnityEngine;

public class BagItemView : ItemView
{
    public override bool SetItem(Item targetItem, out Item previousItem)
    {
        previousItem = _item;

        _item = targetItem;
        _icon.color = targetItem.color;
        _title.text = targetItem.itemName;

        Debug.Log($"{targetItem.itemName} put on.");

        return true;
    }
}