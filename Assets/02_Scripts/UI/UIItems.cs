using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class UIItems : MonoBehaviour
{
    private ItemSlot[] slots;
    private Queue<ItemObject> items;

    private int maxCount;

    private void Awake()
    {
        slots = GetComponentsInChildren<ItemSlot>();
        items = new Queue<ItemObject>();
        maxCount = slots.Length;
    }

    private void Start()
    {
        CharacterManager.Instance.Player.Input.OnItemUseEvent += UseInventoryItem;
    }

    public void AddItem(ItemObject item)
    {
        items.Enqueue(item);
        slots[items.Count-1].Set(item.data);
    }

    public void UseInventoryItem()
    {
        if (items.Count == 0) 
            return;

        ItemObject item = items.Dequeue();
        item.UseItem(CharacterManager.Instance.Player);
        SlotUpdate();
    }

    public bool isFull()
    {
        return items.Count == maxCount;
    }

    public void SlotUpdate()
    {
        for(int i=0; i<slots.Length; i++)
        {
            slots[i].Clear();
        }

        for(int j=0; j<items.Count; j++)
        {
            AddItem(items.Dequeue());
        }
    }


}