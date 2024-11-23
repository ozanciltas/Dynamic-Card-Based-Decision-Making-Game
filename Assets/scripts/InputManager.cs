using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction touchAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchAction = playerInput.actions["press"];

    }
    private void OnEnable()
    {
        touchAction.performed += Touch;

    }
    private void OnDisable()
    {
        touchAction.performed -= Touch;

    }
    private void Touch(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();
    }
}
