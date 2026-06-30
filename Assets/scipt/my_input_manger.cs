using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class my_input_manger : MonoBehaviour
{
    public static event Action OnSpacePressed;



    public void OnSacePresde(CallbackContext context)
    {
        if (context.performed)
        {
            OnSpacePressed?.Invoke();
        }
    }

}
