using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Wall))]
public class WallEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        var myTarget = (Wall)target;
        if (GUILayout.Button("ResetColor"))
        {
            myTarget.GetComponent<Renderer>().material.color = myTarget.color;
        }
    }
}
