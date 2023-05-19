using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _jumpingForce;

    private JumpController _jumpController;

    private Vector2 _slideStartPosition;
    private Vector2 _slideEndPosition;

    private void Awake()
    {
        _jumpController = GetComponent<JumpController>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 )
        {
            CalculateSlide();
        }
    }

    private void CalculateSlide()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            _slideStartPosition = touch.position;
        }
        else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        {
            _slideEndPosition = touch.position;
            DetectHorizontalSlide();
            DetectVerticalSlide();
        }
    }

    

    private void DetectHorizontalSlide()
    {
        float slideDistance = Vector2.Distance(_slideStartPosition, _slideEndPosition);

        if (slideDistance > 100f)
        {
            Vector2 slideDirection = _slideEndPosition - _slideStartPosition;
            slideDirection.Normalize();

            Vector3 newPosition = transform.position;

            if (slideDirection.x < 0)
            {
                newPosition = transform.position + Vector3.left * _horizontalSpeed * Time.deltaTime;
            }
            else if (slideDirection.x > 0)
            {
                newPosition = transform.position + Vector3.right * _horizontalSpeed * Time.deltaTime;
            }

            newPosition.x = Mathf.Clamp(newPosition.x, -2.9f, 2.9f);
            transform.position = newPosition;
        }
    }

    private void DetectVerticalSlide()
    {
        float slideDistance = Vector2.Distance(_slideStartPosition, _slideEndPosition);

        if (slideDistance > 150f)
        {
            Vector2 slideDirection = _slideEndPosition - _slideStartPosition;
            slideDirection.Normalize();

            if (slideDirection.y > 0.75)
            {
                _jumpController.Jump();
            }
        }
    }
}
