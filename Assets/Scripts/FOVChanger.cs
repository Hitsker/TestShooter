using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVChanger : MonoBehaviour
{
    [SerializeField] private List<Camera> _cameras;

    private float speed;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            foreach (var cam in _cameras)
            {
                cam.fieldOfView = 20;
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            foreach (var cam in _cameras)
            {
                cam.fieldOfView = 60;
            }
        }
    }
}
