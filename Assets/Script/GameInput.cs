using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnPlayerShoot;
    public event EventHandler OnPlayerDash;
    public event EventHandler OnPlayerRecharge;
    public static GameInput Instance { get; private set; }
    private PlayerInput playerInput;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        playerInput.Player.Shoot.performed += Shoot_performed;
        playerInput.Player.Dash.performed += Dash_performed;
        playerInput.Player.Recharge.performed += Recharge_performed;

    }
    private void OnDestroy()
    {
        playerInput.Player.Shoot.performed -= Shoot_performed;
        playerInput.Player.Dash.performed -= Dash_performed;
        playerInput.Player.Recharge.performed -= Recharge_performed;
        playerInput.Player.Disable();
    }


    private void Recharge_performed(InputAction.CallbackContext obj)
    {
        OnPlayerRecharge?.Invoke(this, EventArgs.Empty);
    }



    private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerDash?.Invoke(this, EventArgs.Empty);
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerShoot?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 BaseVector()
    {
        Vector2 inputVector = playerInput.Player.Movement.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
    public Vector2 BaseShootVector()
    {
        Vector2 inputVector = playerInput.Player.Moveshoot.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
