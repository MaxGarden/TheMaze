using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door
{
    public DirectionsEnum dir;
    public bool isAvailable;
    public Point accessPoint;

    public Door() { }

    public Door(DirectionsEnum dir, bool isAvailable, Point accessPoint)
    {
        this.dir = dir;
        this.isAvailable = isAvailable;
        this.accessPoint = accessPoint;
    }
}
