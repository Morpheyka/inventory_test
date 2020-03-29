using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagView : MonoBehaviour
{
    private Transform _content;
    private List<ItemView> _items;

    public void Initialization(List<Item> bag, GameObject itemPrefab)
    {
        for (int i = 0; i < bag.Capacity; i++)
        {
            GameObject item = Instantiate(itemPrefab, _content);
            ItemView view = item.GetComponent<ItemView>();

            _items.Add(view);

            if (i >= bag.Count)
            {
                Item empty = ScriptableObject.CreateInstance<Item>();
                view.SetItem(empty, out _);
                continue;
            }

            view.SetItem(bag[i], out _);
        }
    }

    private void Awake()
    {
        _content = GetComponentInChildren<ContentSizeFitter>().transform;
        _items = new List<ItemView>();
    }
}