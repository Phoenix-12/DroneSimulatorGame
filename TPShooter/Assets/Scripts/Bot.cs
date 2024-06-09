using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField]private Transform _target;
    private IControllable _controllable;
    
    private void Awake()
    {
        _controllable = GetComponent<IControllable>();
        if (_controllable != null)
            Debug.Log("No Controller Component");
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
    }

    private float _time = 0;
    
    void Update()
    {
        _time += Time.deltaTime * 1.0f;
        Vector3 pos = gameObject.transform.position;
        Vector3 target = _target.position;
        Vector3 direction = (target - pos).normalized * Random.Range(0.5f, 1.1f);
        //var direction = new Vector3((float)Math.Cos(_time), 0, (float)Math.Sin(_time));
        _controllable.Move(direction);
        if (_time > Random.Range(1f, 3.0f))
        {
            _time = 0.0f;
            _controllable.Jump();
        }
    }
}

