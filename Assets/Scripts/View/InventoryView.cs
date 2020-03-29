using UnityEngine;

public class InventoryView : MonoBehaviour
{
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
        _bag.Initialization(bag);
    }
}