using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float _jumpingForce;

    private Rigidbody _rb;

    private bool _onGround = true;
    private bool _forcedJumping = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (_onGround)
        {
            _rb.AddForce(Vector3.up * _jumpingForce);
            _onGround = false;
        }
    }

    public void ForceJump()
    {
        if (_forcedJumping == false)
        {
            _onGround = true;
            _rb.velocity = Vector3.zero;
            Jump();
            _forcedJumping=true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _onGround = true;
            _forcedJumping = false;
        }
    }
}
