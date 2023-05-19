using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEntered " + other.gameObject);

        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            Debug.Log("Player won!");
            GameManager.Instance.PlayerWon();
        }
    }
}
