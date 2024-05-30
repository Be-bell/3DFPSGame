using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        if(data.type == ItemType.CONSUMABLE)
        {
            if(UIManager.Instance.UIItems.isFull())
            {
                UseItem(CharacterManager.Instance.Player);
            }
            else
            {
                UIManager.Instance.UIItems.AddItem(this);
            }
        }
        Destroy(gameObject);
    }

    public void UseItem(Player player)
    {
        for (int i = 0; i < data.consumables.Length; i++)
        {
            switch (data.consumables[i].Type)
            {
                case ConsumableType.HEALTH:
                    player.Condition.Heal(data.consumables[i].value);
                    break;
                case ConsumableType.STAMINA:
                    player.Condition.HealStamina(data.consumables[i].value);
                    break;
            }
        }
    }
}