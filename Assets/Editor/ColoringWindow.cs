using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColoringWindow : EditorWindow
{
    Color color = Color.black;

    [MenuItem("Coloring/Color All")]
    static void Init()
    {
        ColoringWindow window = (ColoringWindow)EditorWindow.GetWindow(typeof(ColoringWindow));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        color = EditorGUILayout.ColorField(color);
        if (GUILayout.Button("Color all"))
        {
            foreach (var renderer in Object.FindObjectsOfType<Renderer>())
            {
                renderer.material.color=color;
            }
        }
        EditorGUILayout.EndToggleGroup();
    }
}
