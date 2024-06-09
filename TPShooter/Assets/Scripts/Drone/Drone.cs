using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[RequireComponent(typeof(Rigidbody))]
public class Drone : MonoBehaviour, IDroneControllable
{
    [SerializeField] private float _pitchForce;
    [SerializeField] private float _rollForce;
    [SerializeField] private float _yawForce;
    [SerializeField] private float _throttleForce;
    [SerializeField] private Camera _cam;

    private float _time = 0;

    private Vector3 _velocity;
    private Vector3 _throttleVelocity;
    private Vector3 _rotate;
    
    private Rigidbody _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Tank>(out Tank tank))
        {
            //Destroy(tank.gameObject);
            //Debug.Log("BAM");
        }

    }



    public void Update()
    {
        var throttleAcceleration = _throttleVelocity * Time.deltaTime;
        var gravityAcceleration = (-1) * Vector3.up * 20 * Time.deltaTime;

        _velocity = _velocity + (throttleAcceleration + gravityAcceleration) * Time.deltaTime;
        
        //_velocity *= 0.99f;  Legacy Alternative
        if(_time > 0.022)
        {
            _velocity *= 0.991f;
        }
        _time += Time.deltaTime;


        var rot = Quaternion.Euler(_rotate);
        _rb.velocity = _velocity / Time.deltaTime;
        _rb.MoveRotation(_rb.rotation * rot);
    }

    public void Pitch(float force)
    {
        _rotate.x = force * _pitchForce * Time.deltaTime;
    }

    public void Roll(float force)
    {
        _rotate.z = force * _rollForce * Time.deltaTime;
    }

    public void Yaw(float force)
    {
        _rotate.y = _yawForce * force * Time.deltaTime;
    }

    public void Throttle(float force)
    {
        if(force >= 0)
            _throttleVelocity = transform.up * force * _throttleForce;
    }
}
