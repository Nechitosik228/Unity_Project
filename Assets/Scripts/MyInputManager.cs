using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MyInputManager : MonoBehaviour
{
    public static event Action OnSpacePressed;
    public static event Action<Vector2> OnMovePressed;


    public void OnSpaceCallback(CallbackContext input)
    {
        OnSpacePressed?.Invoke();
    }

    public void OnMoveCallback(CallbackContext input)
    {
        Vector2 move = input.ReadValue<Vector2>();
        OnMovePressed?.Invoke(move);
    }
}
