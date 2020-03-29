using UnityEngine;

public enum ItemType
{
    Helmet,
    Weapon,
    Clothes,
    Shield,
    Empty
}

[CreateAssetMenu(fileName = "Default Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName = "Empty";
    public Color color = Color.white;
    public ItemType type = ItemType.Empty;
}