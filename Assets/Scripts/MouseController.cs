using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private float _sensetivityHor = 9.0f;
    [SerializeField] private float _sensetivityVer = 9.0f;
    [SerializeField] private float _minVert = -45.9f;
    [SerializeField] private float _maxVert = 45.0f;

    private float _rotationX;
    private Transform _transform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _transform = transform;
    }

    private void Update()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * _sensetivityVer;
        _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);

        float delta = Input.GetAxis("Mouse X") * _sensetivityHor;
        
        float rotationY = _transform.localEulerAngles.y + delta;
        _transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
}
