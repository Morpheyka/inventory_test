using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private PlayerEquipment _equip;
    private PlayerBag _bag;
    private InventoryView _view;

    private const string BAG_ITEMS_PATH = "Bag/";
    private const string EQUIP_ITEMS_PATH = "Equip/";

    private void Awake()
    {
        _equip = new PlayerEquipment();
        _bag = new PlayerBag();

        _view = GetComponentInChildren<InventoryView>();
    }

    private void Start()
    {
        LoadEquip();
        LoadBag();

        _view.EquipInit(_equip);
        _view.BagInit(_bag);
    }

    private void LoadBag()
    {
        Item[] items = Resources.LoadAll<Item>(BAG_ITEMS_PATH);

        for (int i = 0; i < items.Length; i++)
            _bag.Add(items[i]);
    }

    private void LoadEquip()
    {
        Item[] items = Resources.LoadAll<Item>(EQUIP_ITEMS_PATH);

        for (int i = 0; i < items.Length; i++)
            _equip.Equip(items[i]);
    }
}