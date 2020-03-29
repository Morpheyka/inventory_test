using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagView : MonoBehaviour
{
    [SerializeField] private GameObject _itemPrefab;
    private Transform _content;
    private List<BagItemView> _items;

    public void Initialization(PlayerBag bag)
    {
        int bagCapacity = bag.items.Capacity;
        int bagItemsCount = bag.items.Count;

        for (int i = 0; i < bagCapacity; i++)
        {
            GameObject item = Instantiate(_itemPrefab, _content);
            BagItemView view = item.GetComponent<BagItemView>();
            bool noMoreItems = i >= bagItemsCount;

            _items.Add(view);

            if (noMoreItems)
            {
                Item empty = ScriptableObject.CreateInstance<Item>();
                view.SetItem(empty, out _);
                continue;
            }

            view.SetItem(bag.items[i], out _);
            view.OnEquipItem += bag.Add;
            view.OnRemoveItem += bag.Remove;
        }
    }

    private void Awake()
    {
        _content = GetComponentInChildren<ContentSizeFitter>().transform;
        _items = new List<BagItemView>();
    }
}