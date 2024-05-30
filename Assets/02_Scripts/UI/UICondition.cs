using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition[] conditions;

    private void Awake()
    {
        conditions = GetComponentsInChildren<Condition>();
    }
}