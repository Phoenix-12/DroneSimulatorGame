using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]private IControllable _controllable;
    private GameInput _gameInput;
    private Vector3 _direction;

    private void Awake()
    {
        _gameInput = new GameInput();
        

        
        _controllable = GetComponent<IControllable>();
        if (_controllable != null)
            Debug.Log("No Controller Component");
    }

    private void OnEnable()
    {
        _gameInput.Enable();
        _gameInput.Gameplay.Jump.performed += JumpOnPerformed;

    }

    

    private void OnDisable()
    {
        _gameInput.Disable();
        _gameInput.Gameplay.Jump.performed -= JumpOnPerformed;
    }


    void Update()
    {
        ReadMovement();
    }

    private void JumpOnPerformed(InputAction.CallbackContext context)
    {
        _controllable.Jump();
    }

    private void ReadMovement()
    {
        var inputDirection = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
        _direction = new Vector3(inputDirection.x, 0, inputDirection.y);
        _controllable.Move(_direction);
    }
}
