using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * _movingSpeed * Time.deltaTime;
    }
}
