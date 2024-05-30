using UnityEngine;

public class Behaviour : MonoBehaviour
{
    protected InputHandler inputHandler;

    protected virtual void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
    }
}