public class EquipmentSlot
{
    public Item Item { get; set; }
    public readonly ItemType type;

    public EquipmentSlot(ItemType slotType) =>
        type = slotType;
}