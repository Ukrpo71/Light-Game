using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedJumpTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            other.gameObject.GetComponent<JumpController>().ForceJump();
        }
    }
}
