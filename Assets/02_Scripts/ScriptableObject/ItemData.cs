using System;
using UnityEngine;

public enum ItemType
{
    CONSUMABLE

    // 추후 추가 예정
    //EQUIPABLE
}

public enum ConsumableType
{
    HEALTH,
    STAMINA
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType Type;
    public int value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
