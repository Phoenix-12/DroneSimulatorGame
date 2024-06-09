using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DroneInput : MonoBehaviour
{
    private IDroneControllable _controllable;
    private GameInput _gameInput;
    private Vector3 _direction;

    private void Awake()
    {
        _gameInput = new GameInput();
        
        if (!TryGetComponent<IDroneControllable>(out _controllable))
            Debug.Log("No Controller Component");
    }

    private void OnEnable()
    {
        _gameInput.Enable();
    }

    private void OnDisable()
    {
        _gameInput.Disable();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void ReadMovement()
    {
        float pitch = _gameInput.Drone.Pitch.ReadValue<float>();
        float roll = _gameInput.Drone.Roll.ReadValue<float>();
        float yaw = _gameInput.Drone.Yaw.ReadValue<float>();
        float throttle = _gameInput.Drone.Throttle.ReadValue<float>();
        _controllable.Yaw(yaw);
        _controllable.Roll(roll);
        _controllable.Pitch(pitch);
        _controllable.Throttle(throttle);
    }
}
