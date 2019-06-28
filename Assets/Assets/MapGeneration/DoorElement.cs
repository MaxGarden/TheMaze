using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorElement
{
    public DirectionsEnum dir;
    public bool isAvailable;
    public Point accessPoint;

    public DoorElement() { }

    public DoorElement(DirectionsEnum dir, bool isAvailable, Point accessPoint)
    {
        this.dir = dir;
        this.isAvailable = isAvailable;
        this.accessPoint = accessPoint;
    }
}
