using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private string _horName;
    [SerializeField] private string _verName;
    private float speed = 3f;
    
    private Transform _transform;
    private Vector3 _position;

    private void Start()
    {
        _transform = transform;
        _position = _transform.position;
    }

    void Update ()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis(_horName) * speed;
        var deltaZ = Input.GetAxis(_verName) * speed;

        _transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
    }
}
