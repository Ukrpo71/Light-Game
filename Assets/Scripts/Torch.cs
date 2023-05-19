using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Torch : MonoBehaviour
{
    [SerializeField] private float _rateOfLosingFire;

    [SerializeField] private Light _torch;

    private void Awake()
    {
        if (TryGetComponent(out Light torch))
        {
            _torch = torch;
        }
    }

    private void Update()
    {
        _torch.spotAngle -= _rateOfLosingFire * Time.deltaTime;
    }

}
