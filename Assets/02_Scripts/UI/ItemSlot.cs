using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private ItemData item;
    public ItemData Item {  get { return item; } }
    private Image icon;

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    public void Set(ItemData item)
    {
        this.item = item;
        icon.sprite = item.icon;
    }

    public void Clear()
    {
        item = null;
        icon.sprite = null;
    }
}