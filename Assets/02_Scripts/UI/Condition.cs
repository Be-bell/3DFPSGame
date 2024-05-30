using TMPro;
using UnityEngine;

public class Condition : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    [Header("Stats")]
    public int curValue;
    public int maxValue;
    public int passiveValue;

    private void Awake()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        curValue = maxValue;
    }

    private void Update()
    {
        textMeshProUGUI.text = curValue.ToString();
    }

    public void AddValue(int value)
    {
        curValue = (curValue + value > maxValue) ? maxValue : curValue + value;
    }

    public void SubValue(int value)
    {
        curValue = (curValue - value < 0 ) ? 0 : curValue - value;
    }
}
