using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public readonly int x, y;
    public readonly Color32 color;

    public Point(int px, int py)
    {
        x = px;
        y = py;
    }
    public Point(int px, int py, Color32 color)
    {
        x = px;
        y = py;
        this.color = color; 
    }
}
