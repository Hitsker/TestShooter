using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColoringMenu : MonoBehaviour
{
    [MenuItem("Coloring/Color All Black")]
    public static void ColorAllObjectsInScene()
    {
        foreach (var renderer in Object.FindObjectsOfType<Renderer>())
        {
            renderer.material.color=Color.black;
        }
    }
    
    [MenuItem("Coloring/Reset walls colors")]
    public static void ResetAllObjectsInScene()
    {
        foreach (var wall in Object.FindObjectsOfType<Wall>())
        {
            wall.GetComponent<Renderer>().material.color = wall.color;
        }
    }
}
