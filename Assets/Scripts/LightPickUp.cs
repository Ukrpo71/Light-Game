using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPickUp : MonoBehaviour
{
    [SerializeField] private float _fireIncrease = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            other.gameObject.transform.GetComponentInChildren<Torch>().IncreaseLight(_fireIncrease);
            Destroy(gameObject);
        }
    }
}
