using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _PlayerInput;
    private PlayerInput.OnFootActions _OnFootActions;

    private PlayerMotor _PlayerMotor;
    private PlayerLook _PlayerLook;
    void Awake()
    {
        _PlayerInput = new PlayerInput();
        _OnFootActions =  _PlayerInput.OnFoot;

        _PlayerMotor = GetComponent<PlayerMotor>();
        _PlayerLook = GetComponent<PlayerLook>();

        _OnFootActions.Jump.performed += ctx => _PlayerMotor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Instructs PlayerMotor to move using the value from Movement Action
        _PlayerMotor.ProcessMove(_OnFootActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _PlayerLook.ProcessLook(_OnFootActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _OnFootActions.Enable();
    }

    private void OnDisable()
    {
        _OnFootActions.Disable();
    }
}
