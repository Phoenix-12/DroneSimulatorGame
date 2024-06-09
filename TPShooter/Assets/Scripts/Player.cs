using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IControllable
{
    private Rigidbody _rb;
    private float _speed = 5.0f;
    private float _jumpImpulse = 5.0f;
    //[SerializeField]private CinemachineVirtualCamera _cam;
    [SerializeField]private Camera _cam;
    [SerializeField]private bool _isPlayer = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    public void Jump()
    {
        Debug.Log("Jump");
        _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        _rb.AddForce(Vector3.up * _jumpImpulse, ForceMode.Impulse);
    }

    public void Move(Vector3 direction)
    {
        //Debug.Log(direction);
        //_rb.AddForce(direction * 5);
        //_rb.velocity.Set(direction.x, _rb.velocity.y, direction.z);

        var velocity = new Vector3(direction.x, 0, direction.z) * _speed + new Vector3(0, _rb.velocity.y, 0);
        if (_isPlayer)
        {
            float angle = _cam.transform.rotation.eulerAngles.y; // угол, на который нужно повернуть вектор
            Quaternion rotation = Quaternion.Euler(0, angle, 0); // создание кватерниона поворота
            Vector3 rotatedVector = rotation * velocity; // поворот вектора
            _rb.velocity = rotatedVector;
        }
        else
        {
            _rb.velocity = velocity;
        }
        
    }

    public void Attack(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void ADS()
    {
        throw new System.NotImplementedException();
    }
}
