using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInput : InputHandler
{
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        CallMoveEvent(direction);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            CallJumpEvent();
        }
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            CallRollEvent();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        CallLookEvent(direction);
    }

    public void OnItemUse(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            CallItemUseEvent();
        }
    }
}
