using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private PlayerType _playerType;
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
        float deltaX = 0;
        float deltaZ = 0;
        
        if (_playerType == PlayerType.Arrows)
        {
            deltaX = Input.GetAxis("HorizontalArrows") * speed;
            deltaZ = Input.GetAxis("VerticalArrows") * speed;
        }
        else if (_playerType == PlayerType.WASD)
        {
            deltaX = Input.GetAxis("HorizontalWasd") * speed;
            deltaZ = Input.GetAxis("VerticalWasd") * speed;
        }
        

        _transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
        
    }
}

enum PlayerType
{
    WASD,
    Arrows
}
