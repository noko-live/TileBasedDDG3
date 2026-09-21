using UnityEngine;

public class ItemInformation : MonoBehaviour
{
    enum ItemLabel
    {
        MapPart,
        Item
    }
    enum ItemType
    {
        Wieldable,
        Headwear,
        Usable
    }

    ItemLabel _ItemLabel = ItemLabel.Item;
    ItemType _ItemType = ItemType.Usable;

    void setItemLabel(ItemLabel i) { _ItemLabel = i; }
    void setItemType(ItemType i) { _ItemType = i; }

    ItemLabel getItemLabel() { return _ItemLabel; }
    ItemType getItemType() { return _ItemType; }

}
