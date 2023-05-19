using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float _damageToLight = 15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            other.gameObject.transform.GetComponentInChildren<Torch>().DecreaseLight(_damageToLight);
        }
    }
}
