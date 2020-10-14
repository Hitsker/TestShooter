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

    private string _horizontalAxeName;
    private string _verticalAxeName;

    private void Start()
    {
        _transform = transform;
        _position = _transform.position;

        switch (_playerType)
        {
            case PlayerType.Arrows:
                _horizontalAxeName = "HorizontalArrows";
                _verticalAxeName = "VerticalArrows";
                break;
            case PlayerType.WASD:
                _horizontalAxeName = "HorizontalWasd";
                _verticalAxeName = "VerticalWasd";
                break;
        }
    }

    void Update ()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis(_horizontalAxeName) * speed;
        var deltaZ = Input.GetAxis(_verticalAxeName) * speed;

        _transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
    }
}

enum PlayerType
{
    WASD,
    Arrows
}
