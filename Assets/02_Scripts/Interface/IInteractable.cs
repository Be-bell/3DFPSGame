public interface IInteractable
{
    string GetInteractPrompt();
    void OnInteract();

    void UseItem(Player player);
}