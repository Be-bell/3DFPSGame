using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI itemTMPro;
    [SerializeField] private UIItems uiItems;
    public UIItems UIItems { get { return uiItems; } }

    private void Start()
    {
        uiItems = GetComponentInChildren<UIItems>();
    }
}