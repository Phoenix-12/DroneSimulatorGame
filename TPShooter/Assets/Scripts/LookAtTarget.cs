using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
