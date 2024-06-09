using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    //[SerializeField]private GameObject prefab;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.gameObject.TryGetComponent<Drone>(out Drone player))
        {
            //Instantiate(prefab, gameObject.position);
            //Instantiate(prefab);
            //Debug.Log(gameObject.transform);
            //prefab.SetActive(true);
            //Instantiate(prefab);
            Destroy(gameObject);
            Debug.Log("BAM");
        }

    }
}
