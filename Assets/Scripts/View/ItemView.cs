using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemView : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Action<Item> OnRemoveItem;
    public Action<Item> OnEquipItem;

    protected Item _item;
    protected Image _icon;
    protected Text _title;
    protected Transform _transform;

    private Transform _parent;
    private Transform _root;
    private readonly List<RaycastResult> detectedItems 
        = new List<RaycastResult>(10);

    public abstract bool SetItem(Item targetItem, out Item previousItem);

    public void OnDrag(PointerEventData eventData)
    {
        if (IsEmpty())
            return;

        _transform.SetParent(_root);
        _transform.position = eventData.position;
    }

    private bool IsEmpty() =>
        _item.type == ItemType.Empty;

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        detectedItems.Clear();
        EventSystem.current.RaycastAll(eventData, detectedItems);

        foreach (RaycastResult item in detectedItems)
        {
            ItemView view = item.gameObject.GetComponent<ItemView>();

            if (view == null)
                continue;

            if (view == this)
                continue;

            if(view.SetItem(_item, out Item previouslyItem))
                SetItem(previouslyItem, out _);
        }

        _transform.SetParent(_parent);
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _icon = GetComponent<Image>();
        _title = GetComponentInChildren<Text>();
        _parent = _transform.parent;
        _root = _transform.root;
    }
}