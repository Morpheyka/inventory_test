using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject _itemPrefab;
    private EquipView _equip;
    private BagView _bag;

    public void EquipInit(PlayerEquipment equip)
    {
        _equip = FindObjectOfType<EquipView>();
        _equip.Initialization(equip);
    }

    public void BagInit(PlayerBag bag)
    {
        _bag = FindObjectOfType<BagView>();
        _bag.Initialization(bag, _itemPrefab);
    }
}