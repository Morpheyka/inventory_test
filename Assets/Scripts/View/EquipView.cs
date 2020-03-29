using UnityEngine;

public class EquipView : MonoBehaviour
{
    private EquippableItemView[] _items;

    public void Initialization(PlayerEquipment equip)
    {
        FindItemsView();
        RenderItems(equip);
    }

    private void FindItemsView() =>
        _items = GetComponentsInChildren<EquippableItemView>();

    private void RenderItems(PlayerEquipment equip)
    {
        int itemsCount = _items.Length;
        int equipCount = equip.items.Length;

        for (int i = 0; i < itemsCount; i++)
        {
            for (int j = 0; j < equipCount; j++)
            {
                bool nonRequireItemType = _items[i].Type != equip.items[j].type;

                if (nonRequireItemType)
                    continue;

                EquippableItemView view = _items[i];
                view.SetItem(equip.items[j].Item, out _);
                view.OnRemoveItem += equip.Remove;
                view.OnEquipItem += equip.Equip;
            }
        }
    }
}