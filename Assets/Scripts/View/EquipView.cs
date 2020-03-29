using UnityEngine;

public class EquipView : MonoBehaviour
{
    private EquippableItemView[] _items;

    public void Initialization(EquipmentSlot[] items)
    {
        FindItemsView();
        RenderItems(items);
    }

    private void FindItemsView() =>
        _items = GetComponentsInChildren<EquippableItemView>();

    private void RenderItems(EquipmentSlot[] items)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            for (int j = 0; j < items.Length; j++)
            {
                if (_items[i].Type != items[j].type)
                    continue;

                _items[i].SetItem(items[j].Item, out _);
            }
        }
    }
}