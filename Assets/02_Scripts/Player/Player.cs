using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerCondition condition;
    private InputHandler input;

    public PlayerCondition Condition {  get { return condition; } }
    public InputHandler Input { get { return input; } }
    public Action addItem;

    private void Awake()
    {
        condition = GetComponent<PlayerCondition>();
        input = GetComponent<InputHandler>();
        CharacterManager.Instance.Player = this;
    }
}
