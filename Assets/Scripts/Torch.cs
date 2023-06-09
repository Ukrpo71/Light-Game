using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Torch : MonoBehaviour
{
    [SerializeField] Slider _fireSlider;
    [SerializeField] private float _startingFireLevel = 120f;
    [SerializeField] private float _rateOfLosingFire;
    [SerializeField] private float _timeBetweenHits = 1f;

    private Light _spotLight;

    private bool _isHit = false;
    private float _timer = 0f;

    private const float _maximumSpotAngle = 180;

    private void Awake()
    {
        if (TryGetComponent(out Light spotLight))
        {
            _spotLight = spotLight;
            _spotLight.spotAngle = _startingFireLevel;
        }
    }

    private void Update()
    {
        _spotLight.spotAngle -= _rateOfLosingFire * Time.deltaTime;
        _fireSlider.value = _spotLight.spotAngle / _maximumSpotAngle;

        //Score ��������� ������������ ���� ���������� �� 10
        GameManager.Instance.UpdateScore((int)_spotLight.spotAngle * 10);

        if (_spotLight.spotAngle < 5)
        {
            GameManager.Instance.PlayerLost();
        }

        if (_isHit)
        {
            _timer += Time.deltaTime;
            if (_timer > _timeBetweenHits )
            {
                _timer = 0f;
                _isHit = false;
            }
        }
    }

    public void IncreaseLight(float amount)
    {
        _spotLight.spotAngle += amount;
    }

    public void DecreaseLight(float amount)
    {
        if (_isHit == false)
        {
            _spotLight.spotAngle -= amount;
            _isHit = true;
        }
    }

}
