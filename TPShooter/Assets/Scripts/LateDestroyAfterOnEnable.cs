using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateDestroyAfterOnEnable : MonoBehaviour
{
    [SerializeField] private float _delay;
    private void OnEnable()
    {
        Destroy(gameObject, _delay);
    }
}
