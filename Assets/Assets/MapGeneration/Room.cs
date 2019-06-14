using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Room
{

    private const int SMALL_SIZE = 2;
    private const int MEDIUM_SIZE = 3;
    private const int LARGE_SIZE = 4;

    Point _centerPoint;
    RoomsSize _size;

    public Room(Point centerPoint, RoomsSize type)
    {
        this._centerPoint = centerPoint;
        this._size = type;
    }

    public Point getCenterPoint()
    {
        return _centerPoint;
    }

    public RoomsSize getType()
    {
        return _size;
    }

    public bool isCollision(Room other)
    {
        switch (other.getType())
        {
            case RoomsSize.Small:
                if (_size == RoomsSize.Small)
                {
                    if (Mathf.Abs(this._centerPoint.x - other._centerPoint.x) > SMALL_SIZE * 2 || Mathf.Abs(this._centerPoint.y - other._centerPoint.y) > SMALL_SIZE * 2)
                        return true;
                    else
                        return false;
                }
                break;
        }

        return false;
    }

    public bool isCollision(List<Room> rooms)
    {
        foreach (Room room in rooms)
        {
            switch (room.getType())
            {
                case RoomsSize.Small:
                    if (Mathf.Abs(this._centerPoint.x - room._centerPoint.x) > SMALL_SIZE * 2 || Mathf.Abs(this._centerPoint.y - room._centerPoint.y) > SMALL_SIZE * 2)
                        return true;
                    else
                        return false;
                    break;
            }
        }
        return false;
    }
}
