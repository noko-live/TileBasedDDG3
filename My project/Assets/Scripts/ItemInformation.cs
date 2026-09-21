using UnityEngine;

public class ItemInformation : MonoBehaviour
{
    public enum ItemLabel
    {
        MapPart,
        Item
    }
    public enum ItemType
    {
        Wieldable,
        Headwear,
        Usable
    }

    public ItemLabel _ItemLabel = ItemLabel.Item;
    public ItemType _ItemType = ItemType.Usable;

    public int MapValue = 0;

    void setItemLabel(ItemLabel i) { _ItemLabel = i; }
    void setItemType(ItemType i) { _ItemType = i; }

    public string getItemLabel() { return _ItemLabel.ToString(); }
    public string getItemType() { return _ItemType.ToString(); }
    public int getMapValue() { return MapValue; }

}
