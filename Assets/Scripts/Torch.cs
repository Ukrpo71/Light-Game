using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Torch : MonoBehaviour
{
    [SerializeField] private float _rateOfLosingFire;

    private Light _spotLight;

    private void Awake()
    {
        if (TryGetComponent(out Light spotLight))
        {
            _spotLight = spotLight;
        }
    }

    private void Update()
    {
        _spotLight.spotAngle -= _rateOfLosingFire * Time.deltaTime;
    }

    public void IncreaseLight(float amount)
    {
        _spotLight.spotAngle += amount;
    }

    public void DecreaseLight(float amount)
    {
        _spotLight.spotAngle -= amount;
    }

}
