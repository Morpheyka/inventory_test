using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquippableItemView : ItemView
{
    public override event Action<Item> OnRemoveItem;
    public override event Action<Item> OnEquipItem;

    public ItemType Type => _type;
    [SerializeField] private ItemType _type;

    private Sprite _defaultIcon;
    private Vector3 _defaultPosition;

    public override bool SetItem(Item targetItem, out Item previousItem)
    {
        bool nonRequireItemType = _type != targetItem.type && targetItem.type != ItemType.Empty;
        previousItem = null;

        if (nonRequireItemType)
            return false;

        previousItem = _item;
        RenderItem(targetItem);

        OnRemoveItem?.Invoke(previousItem);
        OnEquipItem?.Invoke(targetItem);
        Debug.Log($"{targetItem.itemName} put on in equip.");

        return true;
    }

    private void RenderItem(Item item)
    {
        _item = item;
        _icon.color = item.color;

        bool itemIsEmpty = item.type == ItemType.Empty;

        if (itemIsEmpty)
        {
            _icon.sprite = _defaultIcon;
            _title.text = string.Empty;
        }
        else
        {
            _icon.sprite = null;
            _title.text = item.itemName;
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        _transform.position = _defaultPosition;
    }

    private void Start()
    {
        _defaultIcon = GetComponent<Image>().sprite;
        _defaultPosition = _transform.position;
    }
}